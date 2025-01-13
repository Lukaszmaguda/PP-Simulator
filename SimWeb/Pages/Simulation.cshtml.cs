using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using System.Linq;
using System.Collections.Generic;
using Simulator.Maps;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        private static Simulation simulation;
        private static SimulationHistory history;
        private static int _currentTurn = 0;

        public Dictionary<Point, List<char>>? Symbols { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public int CurrentTurn => _currentTurn;

        public List<List<CreatureAtPoint>> MapGrid { get; set; } = new();

        public void OnGet()
        {
            if (simulation == null)
            {
                BigTorusMap map = new BigTorusMap(5, 7);

                List<IMappable> creatures = new List<IMappable>
                {
                    new Orc("Gorbag"),
                    new Elf("Elandor"),
                    new Animals("Rabbits", 5),
                    new Birds("Eagles", 4, true),
                    new Birds("Ostriches", 3, false)
                };

                List<Point> points = new List<Point>
                {
                    new Point(2, 2),
                    new Point(3, 1),
                    new Point(4, 4),
                    new Point(2, 5),
                    new Point(0, 0)
                };

                string moves = "dlrludluddlrulr";

                simulation = new Simulation(map, creatures, points, moves);
                history = new SimulationHistory(simulation);
                SizeX = map.SizeX;
                SizeY = map.SizeY;
            }

            UpdateSymbols();
            GenerateMapGrid();
        }

        public IActionResult OnPostNext()
        {
            if (_currentTurn < history.TurnLogs.Count - 1)
            {

                _currentTurn++;
                UpdateSymbols();
                GenerateMapGrid();
            }
            return Page();
        }

        public IActionResult OnPostPrevious()
        {
            if (_currentTurn > 0)
            {
                _currentTurn--;
                UpdateSymbols();
                GenerateMapGrid();
            }

            return Page();
        }
        public string CurrentMoveDetails { get; private set; } = string.Empty;

        private void UpdateSymbols()
        {
            Symbols = history.TurnLogs[_currentTurn].Symbols;
            SizeX = history.SizeX;
            SizeY = history.SizeY;

            var log = history.TurnLogs[_currentTurn];
            string mappableName = log.Mappable.Split(':').Last().Trim();

            CurrentMoveDetails = $"Tura: {_currentTurn}, Ruch: {log.Move}, Obiekt: {mappableName}";
        }



        private void GenerateMapGrid()
        {
            MapGrid.Clear();

            for (int row = 4; row >= 0; row--) 
            {
                var rowGrid = new List<CreatureAtPoint>();

                for (int col = 0; col < 7; col++) 
                {
                    var point = new Point(col, row);
                    var creaturesAtPoint = Symbols?.FirstOrDefault(s => s.Key.Equals(point)).Value;

                    rowGrid.Add(new CreatureAtPoint
                    {
                        Point = point,
                        Creatures = creaturesAtPoint
                    });
                }

                MapGrid.Add(rowGrid);
            }
        }

        public string GetImageSource(List<char> creatures)
        {
            if (creatures.Contains('A'))
                return "<img src='/obrazy/rabbit.png' alt='Rabbit' />";
            if (creatures.Contains('E'))
                return "<img src='/obrazy/elf.png' alt='Elf' />";
            if (creatures.Contains('O'))
                return "<img src='/obrazy/orc.png' alt='Orc' />";
            if (creatures.Contains('B'))
                return "<img src='/obrazy/bird.png' alt='Bird' />";
            if (creatures.Contains('b'))
                return "<img src='/obrazy/ostrich.png' alt='Ostrich' />";
            if (creatures.Contains('x'))
                return "<img src='/obrazy/fight.png' alt='fight' />";

            return "";
        }

        public class CreatureAtPoint
        {
            public Point Point { get; set; }
            public List<char>? Creatures { get; set; }
        }
    }
}
