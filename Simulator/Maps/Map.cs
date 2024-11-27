namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    protected abstract List<IMappable>?[,] Fields { get; }
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
    public abstract Point Next(Point p, Direction d);
    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(IMappable mappable, Point p)
    {
        if (Exist(p))
        {
            Fields[p.X, p.Y] ??= new List<IMappable>();
            Fields[p.X, p.Y]?.Add(mappable);
        }
        else
        {
            throw new ArgumentException("Punkt poza granicami mapy", nameof(p));
        }
    }
    public void Remove(IMappable mappable, Point p)
    {
        var field = Fields[p.X, p.Y];

        if (field != null)
        {
            field.Remove(mappable);

            if (field.Count == 0)
            {
                Fields[p.X, p.Y] = null;
            }
        }
    }

    public void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public List<IMappable> At(Point p)
    {
        if (Exist(p))
        {
            return Fields[p.X, p.Y] ?? new List<IMappable>();
        }
        else {
            throw new ArgumentException("Punkt poza granicami mapy", nameof(p));
        }
    }
    public List<IMappable> At(int x, int y) => At(new Point(x, y));
}