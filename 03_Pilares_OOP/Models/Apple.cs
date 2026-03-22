public class Apple : Fruit
{
    public int NumberOfSeeds { get; set; }

    // public string DescribeMe() => $"Hi, my name is {Name}, I'm color {Color} and I have {NumberOfSeeds} seed(s)."; función de tipo flecha
    public string DescribeMe => $"Hi, my name is {Name}, I'm color {Color} and I have {NumberOfSeeds} seed(s).";
}