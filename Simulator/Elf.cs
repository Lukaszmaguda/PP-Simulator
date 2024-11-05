namespace Simulator;

public class Elf : Creature
{
    private int agility;

    public int Agility
    {
        get => agility;
        private set{
            if (value < 0) agility = 0;
            else if (value > 10) agility = 10;
            else agility = value;
        }
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );

    public override int Power => Level * 8 + Agility * 2;

    private int singCount = 0;

    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (singCount % 3 == 0)
        {
            Agility += 1;
        }
    }
}
