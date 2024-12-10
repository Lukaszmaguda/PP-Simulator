using Simulator;
namespace Simulator;

public class SimulationHistory
{
    private readonly List<SimulationState> _history;
    private readonly Simulation _simulation;

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation;
        _history = new List<SimulationState>();

        SaveState();
    }

    public void RunSimulation()
    {
        while (!_simulation.Finished)
        {
            _simulation.Turn();
            SaveState();
        }
    }

    public SimulationState GetStateAtTurn(int turn)
    {
        if (turn < 1 || turn > _history.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turn), "Invalid turn number.");
        }

        return _history[turn - 1];
    }

    public void SaveState()
    {
        var currentIMappableSymbol = _simulation.CurrentIMappable.Symbol; 
        var currentMove = _simulation.CurrentMoveName;

        var state = new SimulationState(
            _simulation.Positions.Select(p => new Point(p.X, p.Y)).ToList(),
            _simulation.IMappables.Select(m => m.Symbol).ToList(),
            currentIMappableSymbol,  
            currentMove           
        );

        _history.Add(state);
    }

}
