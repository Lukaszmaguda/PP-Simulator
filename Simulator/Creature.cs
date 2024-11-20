
using Simulator.Maps;

namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set;}

    public void InitMapAndPosition(Map map, Point position) { }


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
    public abstract string Greeting();

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



    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        //Map.Next()
        //Map.Next() === Position -> bez ruchu

        //Map.Move()
        //out
        var result = new string[directions.Length];
        for (int i=0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public string[] Go(string directions) =>
        Go(DirectionParser.Parse(directions));


}


