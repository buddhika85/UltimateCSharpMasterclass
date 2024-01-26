using static System.Console;

namespace DesignPatterns.Bridge
{
    public abstract class Motor
    {
        public override string ToString() => "Motor";
    }

    public class ElectricMotor : Motor
    {
        public override string ToString() => $"Electric {base.ToString()}";
    }

    public class PetrolMotor : Motor
    {
        public override string ToString() => $"Petrol {base.ToString()}";
    }
    public abstract class Car
    {
        // Composition over Inheritance
        // Car Has-A Motor : composition
        public Motor Motor { get; set; }

        protected Car(Motor motor)
        {
            Motor = motor;
        }
        public override string ToString() => $"Car with {Motor}";
    }

    public class Pickup : Car
    {
        public Pickup(Motor motor) : base(motor)
        {
        }
        public override string ToString() => $"Pickup {base.ToString()}";
    }

    public class Sedan : Car
    {
        public Sedan(Motor motor) : base(motor)
        {
        }
        public override string ToString() => $"Sedan {base.ToString()}";
    }

    public static class BridgeDemo
    {
        public static void Demo()
        {
            List<Car> cars = new()
            {
                new Pickup(new PetrolMotor()), new Sedan(new ElectricMotor())
            };
            foreach (var car in cars)
            {
                WriteLine(car);
            }
        }
    }

}
