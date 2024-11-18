using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(10, 5, Direction.Up, 10, 6)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    public void Next_ShouldReturnNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    [InlineData(10, 5, Direction.Up, 11, 6)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    public void NextDiagonal_ShouldReturnNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextDiagonalPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextDiagonalPoint);
    }
}