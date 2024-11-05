namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value > max) return max;
        if (value < min) return min;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value.Length > max) return value.Substring(0, max).TrimEnd() + placeholder;
        if (value.Length < min) return value.PadRight(min, placeholder);
        return value.Trim();
    }
}
