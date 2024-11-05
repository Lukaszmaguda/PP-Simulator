namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
            name = char.ToUpper(name[0]) + name.Substring(1);
        }
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }
    public abstract void SayHi();

    public void Upgrade()
    {
        if (level < 10) level++;
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }


    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    public abstract int Power { get; }



    public void Go(Direction direction)
    {
        string whatDirection = direction.ToString().ToLower();
        Console.WriteLine($"{name} goes {whatDirection}");
    }
    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }
    public void Go(string directions)
    {
        Direction[] directionParse = DirectionParser.Parse(directions);
        Go(directionParse);
    }
}


