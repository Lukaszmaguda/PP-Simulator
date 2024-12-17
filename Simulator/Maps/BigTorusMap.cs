namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newY = (p.Y + 1) % SizeY;
                break;
            case Direction.Down:
                newY = (p.Y - 1 + SizeY) % SizeY;
                break;
            case Direction.Left:
                newX = (p.X - 1 + SizeX) % SizeX;
                break;
            case Direction.Right:
                newX = (p.X + 1) % SizeX;
                break;
        }
        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newX = (p.X + 1) % SizeX;
                newY = (p.Y + 1) % SizeY;
                break;
            case Direction.Down:
                newX = (p.X - 1 + SizeX) % SizeX;
                newY = (p.Y - 1 + SizeY) % SizeY;
                break;
            case Direction.Left:
                newX = (p.X - 1 + SizeX) % SizeX;
                newY = (p.Y + 1) % SizeY;
                break;
            case Direction.Right:
                newX = (p.X + 1) % SizeX;
                newY = (p.Y - 1 + SizeY) % SizeY;
                break;
        }
        return new Point(newX, newY);
    }
}
