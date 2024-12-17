using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        TurnLogs.Add(CreateTurnLog());

        while (!_simulation.Finished)
        {
            _simulation.Turn();
            TurnLogs.Add(CreateTurnLog());
        }
    }

    private SimulationTurnLog CreateTurnLog()
    {
        var symbols = new Dictionary<Point, char>();

        foreach (var position in _simulation.Positions)
        {
            var mappable = _simulation.IMappables[_simulation.Positions.IndexOf(position)];
            symbols[position] = mappable.Symbol;
        }
        return new SimulationTurnLog
        {
            Mappable = _simulation.CurrentIMappable.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = symbols
        };
    }
}
