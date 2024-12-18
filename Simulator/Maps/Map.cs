namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }

    private readonly Dictionary<Point, List<IMappable>> _fields = new();
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentException(nameof(sizeX), "Mapa jest za mała");
        }
        SizeX = sizeX;
        SizeY = sizeY;
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d)?? p;
    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;

    public virtual void Add(IMappable mappable, Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Punkt poza granicami mapy", nameof(p));

        if (!_fields.ContainsKey(p))
            _fields[p] = new List<IMappable>();

        _fields[p].Add(mappable);
    }
    public virtual void Remove(IMappable mappable, Point p)
    {
        if (_fields.ContainsKey(p))
        {
            _fields[p].Remove(mappable);

            if (_fields[p].Count == 0)
                _fields.Remove(p);
        }
    }

    public void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public virtual List<IMappable> At(Point p)
    {
        return _fields.ContainsKey(p) ? new List<IMappable>(_fields[p]) : new List<IMappable>();
    }

    public List<IMappable> At(int x, int y) => At(new Point(x, y));

}