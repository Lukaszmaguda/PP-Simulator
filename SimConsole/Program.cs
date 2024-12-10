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

        // Inicjalizacja mapy torusowej
        SmallTorusMap map = new(8, 6);

        // Tworzenie stworów i zwierząt
        var mappables = new List<IMappable>
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals("Rabbits", 5), // Stado królików
            new Birds("Eagles", 4, true), // Grupa orłów (latające)
            new Birds("Ostriches", 3, false) // Grupa strusi (nieloty)
        };

        // Pozycje startowe stworów i zwierząt
        var points = new List<Point>
        {
            new Point(1, 1), // Pozycja elfa
            new Point(3, 3), // Pozycja orka
            new Point(0, 4), // Pozycja królików
            new Point(6, 0), // Pozycja orłów
            new Point(2, 2)  // Pozycja strusi
        };

        // Łańcuch ruchów
        string moves = "dlruudldrulldr"; // 15 ruchów

        // Tworzenie symulacji
        Simulation simulation = new(map, mappables, points, moves);

        // Wizualizacja mapy
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("Press Enter to start simulation...");
        Console.ReadLine();

        // Pętla symulacji
        while (!simulation.Finished)
        {
            mapVisualizer.Draw(); // Rysowanie mapy

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            simulation.Turn(); // Kolejny ruch symulacji
        }

        // Koniec symulacji
        Console.WriteLine("\nSymulacja zakończona.");
    }
}
