using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator
{
    internal class Creature
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature() { }

        public void sayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }
    }
}
