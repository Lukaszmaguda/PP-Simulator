using System;
using System.Collections.Generic;

namespace Simulator
{
    public class SimulationState
    {
        public List<Point> Positions { get; }
        public List<char> Symbols { get; }
        public char CurrentIMappableSymbol { get; }
        public string CurrentMove { get; }

        public SimulationState(List<Point> positions, List<char> symbols, char currentIMappableSymbol, string currentMove)
        {
            Positions = positions ?? throw new ArgumentNullException(nameof(positions));
            Symbols = symbols ?? throw new ArgumentNullException(nameof(symbols));
            CurrentIMappableSymbol = currentIMappableSymbol;
            CurrentMove = currentMove;
        }

        public void DisplayState()
        {
            Console.WriteLine("Current State:");
            for (int i = 0; i < Positions.Count; i++)
            {
                Console.WriteLine($"{Symbols[i]} at {Positions[i]}");
            }
            Console.WriteLine($"Current Mappable: {CurrentIMappableSymbol}, Move: {CurrentMove}");
        }
    }
}
