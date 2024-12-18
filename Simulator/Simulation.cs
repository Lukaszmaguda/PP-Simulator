using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private List<Direction> FilteredMoves { get; }
    private int _currentMoveIndex = 0;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable => IMappables[_currentMoveIndex % IMappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => FilteredMoves.Count > _currentMoveIndex
        ? FilteredMoves[_currentMoveIndex].ToString().ToLower()
        : string.Empty;

    /// <summary>
    /// Simulation constructor.
    /// </summary>
    /// <param name="map">The simulation map.</param>
    /// <param name="mappables">List of IMappables to simulate.</param>
    /// <param name="positions">Starting positions for IMappables.</param>
    /// <param name="moves">String containing the cyclic moves.</param>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
            throw new ArgumentException("List of mappables cannot be empty.");

        if (mappables.Count != positions.Count)
            throw new ArgumentException("Number of mappables must match the number of starting positions.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        FilteredMoves = Moves
            .Select(c => DirectionParser.Parse(c.ToString().ToLower()))
            .Where(d => d != null && d.Count > 0)
            .Select(d => d[0])
            .ToList();

        if (FilteredMoves.Count == 0)
            throw new ArgumentException("Moves must contain at least one valid direction.");

        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");

            mappable.InitMapAndPosition(map, position);
            map.Add(mappable, position);
        }
    }

    /// <summary>
    /// Makes one move of the current mappable in the current direction.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("The simulation is already finished.");

        if (_currentMoveIndex >= FilteredMoves.Count)
        {
            Finished = true;
            return;
        }

        Direction direction = FilteredMoves[_currentMoveIndex];
        CurrentIMappable.Go(direction);
        _currentMoveIndex++;

        if (_currentMoveIndex >= FilteredMoves.Count)
            Finished = true;
    }
}
