using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw(simulation.IMappables, simulation.Positions);
        Console.WriteLine("Press Enter to start simulation...");
        Console.ReadLine();

        while (!simulation.Finished)
        {
            mapVisualizer.Draw(mappables, points);

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            simulation.Turn();
        }

        Console.WriteLine("Symulacja zakończona.");
    }
}
