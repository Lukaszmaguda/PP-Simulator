namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MoveLogic.WallNext;
        FNextDiagonal = MoveLogic.WallNextDiagonal;
    }
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY){ }

}
