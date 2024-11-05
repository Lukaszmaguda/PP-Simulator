namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;

    public int Rage
    {
        get => rage;
        set => rage = Validator.Limiter(value, 0, 10);
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
    public override string Info => $"{Name} [{Level}][{Rage}]";
}
