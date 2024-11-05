namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;

    public int Rage
    {
        get => rage;
        set
        {
            if (value < 0) rage = 0;
            else if (value > 10) rage = 10;
            else rage = value;
        }
    }

    public Orc() { }
    public Orc(string name = "Unknown", int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );

    public override int Power => Level * 7 + Rage * 3;

    private int huntCount = 0;
    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");
        if (huntCount % 2 == 0)
        {
            if (rage < 10) rage++;
        }
    }
}
