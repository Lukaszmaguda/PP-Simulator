using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; }
    Map Map { get; }
    char Symbol { get; }
    void InitMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
