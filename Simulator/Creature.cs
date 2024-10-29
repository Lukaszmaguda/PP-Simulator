
namespace Simulator
{
    internal class Creature
    {
        private string name = "Unknown";
        private int level = 1;

        public String Name
        {
            get => name;
            init  
            {
                name = value.Trim();
                if (name.Length < 3) name = name.PadRight(3, '#');                
                if (name.Length > 25) 
                {
                    name = name.Substring(0, 25).TrimEnd();
                    if (name.Length < 3)
                    {
                        name = name.PadRight(3, '#');
                    }
                }
                name = char.ToUpper(name[0]) + name.Substring(1);

            }
        }
        public int Level
        {
            get => level;
            init
            {
                if (value < 1) level = 1;
                else if (value > 10) level = 10;
                else level = value;
            }
        }
        public void Upgrade()
        {
            if (level < 10) level++;
        }


        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }


        public Creature() { }

        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }

        public void Go(Direction direction)
        {
            string whatDirection = direction.ToString().ToLower();
            Console.WriteLine($"{name} goes {whatDirection}");
        }
        public void Go(Direction[] directions)
        {
            foreach (Direction direction in directions)
            {
                Go(direction);
            }
        }
        public void Go(string directions)
        {
            Direction[] directionParse = DirectionParser.Parse(directions);
            Go(directionParse);
        }
    }

}
