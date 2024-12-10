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

        SmallTorusMap map = new(8, 6);

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

        string moves = "dlruudldrulldr";

        Simulation simulation = new(map, mappables, points, moves);

        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("Press Enter to start simulation...");
        Console.ReadLine();

        while (!simulation.Finished)
        {
            mapVisualizer.Draw(); 

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            simulation.Turn(); 
        }

        Console.WriteLine("\nSymulacja zakończona.");
    }
}
