namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string enter)
    {
        var directionList = new List<Direction>();

        foreach(char letter in enter.ToUpper())
        {
            switch (letter) 
            {
                case 'U':
                    directionList.Add(Direction.Up);
                    break;
                case 'R':
                    directionList.Add(Direction.Right);
                    break;
                case 'D':
                    directionList.Add(Direction.Down);
                    break;
                case 'L':
                    directionList.Add(Direction.Left);
                    break;
            }
        }
        return directionList.ToArray();
    }
}
