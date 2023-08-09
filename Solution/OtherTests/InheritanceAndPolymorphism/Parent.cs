namespace OtherTests.InheritanceAndPolymorphism
{
    public class Parent
    {
        public int X { get; set; }
        public virtual int Y { get; set; }
        public virtual int Z { get; set; }
    }

    public class Child : Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override int Z { get; set; }
    }

    public class Test
    {
        public Test()
        {
            var parent = new Parent { X = 1, Y = 2, Z = 3 };
            var child = new Child { X = 10, Y = 20, Z = 30 };
            Parent childTwo = new Child { X = 10, Y = 20, Z = 30 };

            Console.WriteLine($"Parent X = {parent.X}, Y = {parent.Y}, Z = {parent.Z}");
            Console.WriteLine($"Child X = {child.X}, Y = {child.Y}, Z = {child.Z}");
            Console.WriteLine($"ChildTwo X = {childTwo.X}, Y = {childTwo.Y}, Z = {childTwo.Z}");
        }
    }
}
