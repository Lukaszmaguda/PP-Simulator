namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = base.Next(p, d);

        if (!Exist(nextPoint))
        {
            d = d switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => d
            };

            nextPoint = base.Next(p, d);

            if (!Exist(nextPoint))
                return p;
        }

        return nextPoint;
    }
}
