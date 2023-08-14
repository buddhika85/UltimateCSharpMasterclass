using static System.Console;

namespace OtherTests.ConstructorsTest
{
    public class Animal
    {
        // feature shared with all child classes
        public string Name { get; set; }

        // feature shared with all child classes, and may be overridden
        public virtual string Habitat => "Land";

        public Animal(string name)
        {
            Name = name;
            WriteLine($"Animal constructor called - {name}");
        }

        public override string ToString() => $"{Name}, Lives in {Habitat}";
    }

    public class Dog : Animal
    {
        // unique fields for this child
        public string Breed { get; set; }

        // constants - implicitly static, do not change from Dog object to object
        public const int Legs = 4;
        public const bool HasTail = true;

        // override bases
        public override string Habitat => $"{base.Habitat}, but more with places where humans live";

        // constructor of child calls parent using base(name)
        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
            WriteLine($"Dog constructor called - {breed}");
        }

        public override string ToString() => $"{base.ToString()}, has {Legs} legs and a tail";
    }

    public class Test
    {
        public Test()
        {
            var child = new Dog("Dog", "Labrador Retriever");

            //Child child = null;
            //if (child is not null)
            //    WriteLine(child.ToString());
        }
    }
}
