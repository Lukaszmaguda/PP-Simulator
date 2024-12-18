using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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

            Simulation simulationForHistory = new(map, mappables, points, moves);
            SimulationHistory history = new(simulationForHistory);

            LogVisualizer logVisualizer = new LogVisualizer(history);

            Console.WriteLine("\nHistoria symulacji:");
            for (int i = 0; i < history.TurnLogs.Count; i++)
            {
                logVisualizer.Draw(i);
                Console.WriteLine("Naciśnij dowolny klawisz, aby przejść do następnej tury...");
                Console.ReadKey(true);
            }

            Console.WriteLine("Koniec historii.");
        }
    }
}
