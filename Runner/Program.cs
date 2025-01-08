using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simulator;

internal class Program
{
    public static void Main(string[] args)
    {
        //var creatures = new List<Creature>
        //    {
        //        new Elf("Elf 1", 10, 10),
        //        new Orc("Orc 1", 7, 10),
        //        new Elf("Elf 2", 10, 7),
        //        new Orc("Orc 2", 3, 3),
        //        new Elf("Elf 3", 2, 2),
        //        new Orc("Orc 3", 1, 1),
        //    };

        //creatures.Sort((c1, c2) => c1.Power.CompareTo(c2.Power));

        //Console.WriteLine("Creatures sorted by Power:");
        //foreach (var creature in creatures)
        //{
        //    Console.WriteLine($"{creature.Info} -> Power: {creature.Power}");
        //}

        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
    new Elf("Elandor", 2, 7),
    new Animals { Description = "Rasbbits", Size = 10 },
    new Birds { Description = "Eagles", Size = 15 },
    new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;




    }
}