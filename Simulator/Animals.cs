using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";

    public Animals(string description, int size)
    {
        this.description = description;
        Size = size;
    }
    public Animals() { }

    public Map? Map { get; private set; }
    public Point Position { get; set; }
    public virtual char Symbol => 'A';


    public string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value.Trim(), 3, 15, '#');
            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (Map != null)
            throw new InvalidOperationException("Zwierzę jest już przypisane do mapy.");

        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public virtual void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("Zwierzę nie jest przypisane do mapy.");

        Point nextPosition = Map.Next(Position, direction);
        if (Map.Exist(nextPosition))
        {
            Map.Move((IMappable)this, Position, nextPosition);
            Position = nextPosition;
        }
    }

    public int Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}