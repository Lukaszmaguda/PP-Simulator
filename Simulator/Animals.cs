using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value.Trim(), 3, 15, '#');
            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}