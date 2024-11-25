using Simulator.Maps;
using System.Diagnostics;
using System.Text;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw(simulation.Creatures, simulation.Positions);
        Console.WriteLine("Press Enter to start simulation...");
        Console.ReadLine();

        while (!simulation.Finished)
        {
            mapVisualizer.Draw(creatures, points);

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            simulation.Turn();
        }

        Console.WriteLine("Symulacja zakończona.");
    }
}



