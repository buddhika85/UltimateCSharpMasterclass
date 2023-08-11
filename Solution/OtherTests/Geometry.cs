
using static System.Math;

public class Geometry
{
    public void SquareArea(double side)
    {
        var area = Pow(side, 2);
        Console.WriteLine($"Square area is: {area}");
    }

    public void CircleArea(double radius)
    {
        var area = PI * Pow(radius, 2);
        Console.WriteLine($"Circle area is: {area}");
    }
}

