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
            name = value.Trim();
            if (name.Length < 3) name = name.PadRight(3, '#');                
            if (name.Length > 25) 
            {
                name = name.Substring(0, 25).TrimEnd();
                if (name.Length < 3)
                {
                    name = name.PadRight(3, '#');
                }
            }
            name = char.ToUpper(name[0]) + name.Substring(1);
        }
    }

    public int Level
    {
        get => level;
        init
        {
            if (value < 1) level = 1;
            else if (value > 10) level = 10;
            else level = value;
        }
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
    public string Info => $"{Name} [{Level}]";
    public abstract int Power { get; }
}
