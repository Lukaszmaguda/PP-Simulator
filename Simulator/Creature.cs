using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    private string name = "Unknown";
    private int level = 1;

    public void InitMapAndPosition(Map map, Point position) {
        if (Map != null)
            throw new InvalidOperationException("Stwór już ma przypisaną mapę.");

        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
            name = char.ToUpper(name[0]) + name.Substring(1);
        }
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }
    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10) level++;
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    public abstract int Power { get; }
    public abstract char Symbol { get; }

    public void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("Stwór nie jest przypisany do mapy.");

        Point nextPosition = Map.Next(Position, direction);

        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
    }
}

