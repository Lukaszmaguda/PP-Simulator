namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Starting Simulator!\n");
        //Lab4a();
        //Creature c = new Elf("Elandor", 5, 3);
        //Console.WriteLine(c);  // ELF: Elandor [5]
        //Lab4b();
        Lab5a();
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
            o,
            e,
            new Orc("Morgash", 3, 8),
            new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    public static void Lab5a()
    {  
            Rectangle rect1 = new Rectangle(5, 5, 10, 10);
            Console.WriteLine(rect1); // (5, 5):(10, 10)

            Rectangle rect2 = new Rectangle(10, 10, 5, 5);
            Console.WriteLine(rect2); // (5, 5):(10, 10)

            Point p1 = new Point(2, 2);
            Point p2 = new Point(8, 8);
            Rectangle rect3 = new Rectangle(p1, p2);
            Console.WriteLine(rect3); // (2, 2):(8, 8)

            try
            {
                Rectangle rect4 = new Rectangle(1, 1, 1, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Wyjątek: {ex.Message}");
            }

            Point testPoint1 = new Point(6, 6);
            Point testPoint2 = new Point(11, 11);
            Console.WriteLine($"Czy rect1 zawiera punkt (6, 6)? {rect1.Contains(testPoint1)}"); // true
            Console.WriteLine($"Czy rect1 zawiera punkt (11, 11)? {rect1.Contains(testPoint2)}"); // false
    }

}
