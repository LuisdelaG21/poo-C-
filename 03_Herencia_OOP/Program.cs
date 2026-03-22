// See https://aka.ms/new-console-template for more information
Apple redApple = new()
{
  Name = "Red Apple",
  Color = "Red",
  NumberOfSeeds = 4 
};

Apple greenApple = new()
{
  Name = "Green Apple",
  Color = "Green",
  NumberOfSeeds = 6  
};

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(redApple.DescribeMe);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(greenApple.DescribeMe);



