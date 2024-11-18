using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    
    [Theory]
    [InlineData(5, 0, 10, 5)] 
    [InlineData(-1, 0, 10, 0)] 
    [InlineData(15, 0, 10, 10)]
    [InlineData(0, 0, 10, 0)] 
    [InlineData(10, 0, 10, 10)] 
    public void Limiter_ShouldReturnValueWithinRange(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 3, 5, '*', "hello")] 
    [InlineData("hello world", 5, 5, '*', "hello")] 
    [InlineData("hi", 5, 10, '*', "hi***")] 
    [InlineData("test", 4, 4, '*', "test")] 
    [InlineData("", 3, 5, '-', "---")] 
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}
