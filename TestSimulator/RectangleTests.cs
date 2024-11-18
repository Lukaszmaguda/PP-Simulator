using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        var rectangle = new Rectangle(5, 5, 10, 10);
        Assert.Equal(5, rectangle.X1);
        Assert.Equal(5, rectangle.Y1);
        Assert.Equal(10, rectangle.X2);
        Assert.Equal(10, rectangle.Y2);
    }

    [Fact]
    public void Constructor_ShouldSwapCoordinatesIfInWrongOrder()
    {
        var rectangle = new Rectangle(10, 10, 5, 5);
        Assert.Equal(5, rectangle.X1);
        Assert.Equal(5, rectangle.Y1);
        Assert.Equal(10, rectangle.X2);
        Assert.Equal(10, rectangle.Y2);
    }

    [Theory]
    [InlineData(1, 1, 5, 5, 3, 3, true)]
    [InlineData(1, 1, 5, 5, 6, 6, false)]
    [InlineData(0, 0, 10, 10, 10, 10, true)] 
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        var result = rectangle.Contains(point);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenPointsAreCollinear()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 5, 1));
    }
}
