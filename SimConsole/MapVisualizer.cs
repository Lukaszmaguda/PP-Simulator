using Simulator.Maps;
using Simulator;
using System;

namespace Simulator;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

     public void Draw()
    {
        Console.Clear();

        int width = _map.SizeX;
        int height = _map.SizeY;

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

                var creaturesAtPosition = _map.At(new Point(x, y));

                if (creaturesAtPosition.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creaturesAtPosition.Count == 1)
                {
                    var creature = creaturesAtPosition[0];
                    Console.Write($"{creature.Symbol}");
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
