using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get; private set; }

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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new ArgumentException("Lista stworów nie może być pusta.", nameof(creatures));

        if (creatures.Count != positions.Count)
            throw new ArgumentException("Liczba stworów musi odpowiadać liczbie pozycji początkowych.", nameof(positions));

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        CurrentCreature = Creatures[0];
        CurrentMoveName = Moves[CurrentMoveIndex].ToString().ToLower();
    }
    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Symulacja już się skończyła.");
        }

        int currentCreatureIndex = CurrentMoveIndex % Creatures.Count;
        Creature currentCreature = Creatures[currentCreatureIndex];

        int moveIndexForCreature = CurrentMoveIndex % Moves.Length;
        string currentMoveName = Moves[moveIndexForCreature].ToString().ToLower();

        var directions = DirectionParser.Parse(currentMoveName);
        if (directions.Count == 0)
        {
            throw new ArgumentException($"Niepoprawny kierunek: {currentMoveName}");
        }

        var direction = directions[0];
        var currentPosition = Positions[currentCreatureIndex];

        var newPosition = Map.Next(currentPosition, direction);

        Map.Move(currentCreature, currentPosition, newPosition);
        Positions[currentCreatureIndex] = newPosition;

        CurrentMoveIndex++;
        TotalMovesDone++;

        if (TotalMovesDone >= Moves.Length)
        {
            Finished = true;
        }
    }
}