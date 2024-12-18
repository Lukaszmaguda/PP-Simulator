using Simulator;
using Simulator.Maps;
using System;

namespace SimConsole
{
    internal class LogVisualizer
    {
        private readonly SimulationHistory _log;

        public LogVisualizer(SimulationHistory log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Draw(int turnIndex)
        {
            Console.Clear();
            var turnLog = _log.TurnLogs[turnIndex];

            int width = _log.SizeX;
            int height = _log.SizeY;

            Console.Write(Box.TopLeft);
            for (int x = 0; x < width; x++)
            {
                Console.Write(Box.Horizontal);
                if (x < width - 1) Console.Write(Box.TopMid);
            }
            Console.WriteLine(Box.TopRight);

            for (int y = 0; y < height; y++)
            {
                Console.Write(Box.Vertical);
                for (int x = 0; x < width; x++)
                {
                    var position = new Point(x, y);
                    if (turnLog.Symbols.ContainsKey(position))
                    {
                        var creaturesAtPosition = turnLog.Symbols[position];
                        if (creaturesAtPosition.Count > 1)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(creaturesAtPosition[0]);
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.Write(Box.Vertical);
                }
                Console.WriteLine();

                if (y < height - 1)
                {
                    Console.Write(Box.MidLeft);
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write(Box.Horizontal);
                        if (x < width - 1) Console.Write(Box.Cross);
                    }
                    Console.WriteLine(Box.MidRight);
                }
            }
            Console.Write(Box.BottomLeft);
            for (int x = 0; x < width; x++)
            {
                Console.Write(Box.Horizontal);
                if (x < width - 1) Console.Write(Box.BottomMid);
            }
            Console.WriteLine(Box.BottomRight);

            Console.WriteLine($"\nTura: {turnIndex + 1}");
            Console.WriteLine($"Ruch: {turnLog.Move}");
            Console.WriteLine($"Obiekt: {turnLog.Mappable}");
        }
    }
}
//do poprawy

