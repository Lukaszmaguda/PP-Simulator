namespace Simulator.Maps;

public static class MoveLogic
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }
    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    }
    ///zrobić do bounce i do torusa jeszcze
    public static Point TorusNext(Map m, Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newY = (p.Y + 1) % m.SizeY;
                break;
            case Direction.Down:
                newY = (p.Y - 1 + m.SizeY) % m.SizeY;
                break;
            case Direction.Left:
                newX = (p.X - 1 + m.SizeX) % m.SizeX;
                break;
            case Direction.Right:
                newX = (p.X + 1) % m.SizeX;
                break;
        }
        return new Point(newX, newY);
    }

    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newX = (p.X + 1) % m.SizeX;
                newY = (p.Y + 1) % m.SizeY;
                break;
            case Direction.Down:
                newX = (p.X - 1 + m.SizeX) % m.SizeX;
                newY = (p.Y - 1 + m.SizeY) % m.SizeY;
                break;
            case Direction.Left:
                newX = (p.X - 1 + m.SizeX) % m.SizeX;
                newY = (p.Y + 1) % m.SizeY;
                break;
            case Direction.Right:
                newX = (p.X + 1) % m.SizeX;
                newY = (p.Y - 1 + m.SizeY) % m.SizeY;
                break;
        }
        return new Point(newX, newY);
    }

    public static Point BounceNext(Map m, Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (!m.Exist(nextPoint))
        {
            Direction oppositeDirection = OppositeDirection[d];
            nextPoint = p.Next(oppositeDirection);

            if (!m.Exist(nextPoint))
                return p;
        }
        return nextPoint;
    }

    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);
        if (!m.Exist(nextPoint))
        {
            Direction oppositeDirection = OppositeDirection[d];
            nextPoint = p.NextDiagonal(oppositeDirection);

            if (!m.Exist(nextPoint))
                return p;
        }
        return nextPoint;
    }

    private static readonly Dictionary<Direction, Direction> OppositeDirection = new()
    {
        { Direction.Up, Direction.Down },
        { Direction.Down, Direction.Up },
        { Direction.Left, Direction.Right },
        { Direction.Right, Direction.Left }
    };

}
