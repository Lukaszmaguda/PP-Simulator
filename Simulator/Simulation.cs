using Simulator.Maps;
using Simulator;

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
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable { get; private set; }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get; private set; }

    /// <summary>
    /// Index of the current move in the moves string.
    /// </summary>
    private int CurrentMoveIndex = 0;

    private int TotalMovesDone = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
            throw new ArgumentException("Lista stworów nie może być pusta.", nameof(mappables));

        if (mappables.Count != positions.Count)
            throw new ArgumentException("Liczba stworów musi odpowiadać liczbie pozycji początkowych.", nameof(positions));

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        CurrentIMappable = IMappables[0];
        CurrentMoveName = Moves[CurrentMoveIndex].ToString().ToLower();
    }
    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
public void Turn()
{
    if (Finished)
    {
        throw new InvalidOperationException("Symulacja już się skończyła.");
    }

    int currentIMappableIndex = TotalMovesDone % IMappables.Count; 
    IMappable currentIMappable = IMappables[currentIMappableIndex];

    int moveIndexForIMappable = TotalMovesDone % Moves.Length;
    string currentMoveName = Moves[moveIndexForIMappable].ToString().ToLower();

    var directions = DirectionParser.Parse(currentMoveName);
    if (directions.Count == 0)
    {
        Console.WriteLine($"Ignoruję niepoprawny kierunek: {currentMoveName}");
        TotalMovesDone++;
        return;
    }

    var direction = directions[0];
    var currentPosition = Positions[currentIMappableIndex];

    var newPosition = Map.Next(currentPosition, direction);

    Map.Move(currentIMappable, currentPosition, newPosition);
    Positions[currentIMappableIndex] = newPosition;

    CurrentMoveIndex = (CurrentMoveIndex + 1) % Moves.Length;
    TotalMovesDone++;

    if (TotalMovesDone >= Moves.Length)
    {
        Finished = true;
    }

    CurrentIMappable = IMappables[currentIMappableIndex];
    CurrentMoveName = currentMoveName;
    }
}