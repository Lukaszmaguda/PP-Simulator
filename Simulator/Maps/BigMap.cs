namespace Simulator.Maps;

public class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;

    protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000 || sizeY > 1000)
            throw new ArgumentOutOfRangeException("Wymiary mapy są zbyt duże.");

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, p.Y - 1),
            Direction.Down => new Point(p.X, p.Y + 1),
            Direction.Left => new Point(p.X - 1, p.Y),
            Direction.Right => new Point(p.X + 1, p.Y),
            _ => p
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X + 1, p.Y - 1),
            Direction.Down => new Point(p.X - 1, p.Y + 1),
            Direction.Left => new Point(p.X - 1, p.Y - 1),
            Direction.Right => new Point(p.X + 1, p.Y + 1),
            _ => p
        };
    }

    public override bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    public override void Add(IMappable mappable, Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Punkt poza granicami mapy", nameof(p));

        if (!_fields.ContainsKey(p))
        {
            _fields[p] = new List<IMappable>();
        }
        _fields[p].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point p)
    {
        if (_fields.ContainsKey(p))
        {
            _fields[p].Remove(mappable);
            if (_fields[p].Count == 0)
            {
                _fields.Remove(p);
            }
        }
    }

    public override List<IMappable> At(Point p)
    {
        if (Exist(p) && _fields.TryGetValue(p, out var mappables))
        {
            return new List<IMappable>(mappables);
        }
        return new List<IMappable>();
    }
}
