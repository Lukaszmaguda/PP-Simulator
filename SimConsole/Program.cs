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

        BigBounceMap map = new(8, 6);

        var mappables = new List<IMappable>
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals("Rabbits", 5),
            new Birds("Eagles", 4, true),
            new Birds("Ostriches", 3, false)
        };

        var points = new List<Point>
        {
            new Point(1, 1),
            new Point(3, 3),
            new Point(0, 4),
            new Point(6, 0),
            new Point(2, 2)
        };

        string moves = "dldruulurddllurrddll";

        Simulation simulationForVisualization = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulationForVisualization.Map);

        Console.WriteLine("Press Enter to start simulation...");
        Console.ReadLine();

        while (!simulationForVisualization.Finished)
        {
            mapVisualizer.Draw();

            Console.WriteLine($"\nObiekt: {simulationForVisualization.CurrentIMappable.Symbol}, Ruch: {simulationForVisualization.CurrentMoveName}");
            Console.WriteLine("Naciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            simulationForVisualization.Turn();
        }

        Console.WriteLine("\nSymulacja zakończona. Uruchamiam historię...");

        Simulation simulationForHistory = new(map, mappables, points, moves);
        SimulationHistory history = new(simulationForHistory);

                Console.WriteLine("\nHistoria symulacji:");
        for (int i = 0; i < history.TurnLogs.Count; i++)
        {
            var log = history.TurnLogs[i];
            Console.WriteLine($"Tura {i}:");
            Console.WriteLine($"  Obiekt: {log.Mappable}");
            Console.WriteLine($"  Ruch: {log.Move}");
            Console.WriteLine();
        }

    }
}
