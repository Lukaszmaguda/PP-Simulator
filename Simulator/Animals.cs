
using System.Xml.Linq;

public class Animals
{
    private string description = "Unknown";
    public string Description
    {
        get => description;
        init
        {
            description = value.Trim();
            if (description.Length < 3 ) description = description.PadRight(3, '#');
            if (description.Length > 15)
            {
                description = description.Substring(0, 15).TrimEnd();
                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }
            }

            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return $"{Description}<{Size}>"; }
    }


}