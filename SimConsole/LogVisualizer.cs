using Simulator;
using System;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationHistory _log;

    public LogVisualizer(SimulationHistory log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Nieprawidłowy numer tury.");
        }

        var turnLog = _log.TurnLogs[turnIndex];
        var symbols = turnLog.Symbols;

        Console.Clear();

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

                if (symbols.ContainsKey(position))
                {
                    Console.Write(symbols[position]);
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
    }
}
