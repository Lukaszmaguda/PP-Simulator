namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{

    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY){}


    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }
    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    }
}
