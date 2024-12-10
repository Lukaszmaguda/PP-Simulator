using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public Birds() { }
    public Birds(string description, int size, bool canFly) : base(description, size)
    {
        CanFly = canFly;
    }

    public override string Info => $"{Description.Trim()} (fly{(CanFly ? "+" : "-")}) <{Size}>";

    public override void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("Ptak nie jest przypisany do mapy.");

        Point nextPosition = CanFly ? Map.Next(Map.Next(Position, direction), direction) : Position.NextDiagonal(direction);                  

        if (Map.Exist(nextPosition))
        {
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }

}
