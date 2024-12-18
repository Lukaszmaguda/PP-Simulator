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
    
}
