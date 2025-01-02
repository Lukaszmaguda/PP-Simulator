namespace Simulator
{
    public class SimulationHistory
    {
        private readonly Simulation _simulation;

        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = new();

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {
            while (!_simulation.Finished)
            {
                _simulation.Turn();
                var symbols = new Dictionary<Point, List<char>>();

                foreach (var mappable in _simulation.IMappables)
                {
                    if (!symbols.ContainsKey(mappable.Position))
                    {
                        symbols[mappable.Position] = new List<char>();
                    }
                    symbols[mappable.Position].Add(mappable.Symbol);
                }

                var log = new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentIMappable.ToString(),
                    Move = _simulation.CurrentMoveName,
                    Symbols = symbols
                };
                TurnLogs.Add(log);
            }
        }

        public IEnumerable<SimulationState> GetStates()
        {
            return TurnLogs.Select(log => new SimulationState(
                log.Symbols.Keys.ToList(),
                log.Symbols.Values.SelectMany(s => s).ToList(),
                log.Mappable.FirstOrDefault(),
                log.Move
            ));
        }
    }
}
