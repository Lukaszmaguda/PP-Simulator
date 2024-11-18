using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTest
{
    [Fact]
    public void Constructor_ValidateSize_ShouldSetSize()
    {
        // Arrange
        int size = 10; 
        //Act
        var map = new SmallSquareMap(size);
        //Assert
        Assert.Equal(size, map.Size);
    }
    [Theory]
    [InlineData(3)]
    [InlineData(22)]
    public void Constructor_InvalidSize_ShouldThrowOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }
    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);

        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(5, 10, Direction.Down, 5, 9)]
    [InlineData(5, 10, Direction.Right, 6, 10)]
    [InlineData(5, 10, Direction.Left, 4, 10)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(19, 10, Direction.Up, 19, 11)]
    public void Next_ShouldReturnNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 10, Direction.Down, 4, 9)]
    [InlineData(5, 10, Direction.Right, 6, 9)]
    [InlineData(5, 10, Direction.Left, 4, 11)]
    [InlineData(19, 19, Direction.Down, 18, 18)]
    [InlineData(19, 0, Direction.Right, 19, 0)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

}
