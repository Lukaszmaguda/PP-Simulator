namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    private static readonly Dictionary<Direction, Direction> OppositeDirection = new()
    {
        { Direction.Up, Direction.Down },
        { Direction.Down, Direction.Up },
        { Direction.Left, Direction.Right },
        { Direction.Right, Direction.Left }
    };

    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);

        if (!Exist(nextPoint))
        {
            var oppositeDirection = OppositeDirection[d];
            nextPoint = p.Next(oppositeDirection);

            if (!Exist(nextPoint))
                return p;
        }

        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);

        if (!Exist(nextPoint))
        {
            var oppositeDirection = OppositeDirection[d];
            nextPoint = p.NextDiagonal(oppositeDirection);

            if (!Exist(nextPoint))
                return p;
        }

        return nextPoint;
    }
}
