using static System.Console;

namespace SOLID_Demo.I
{
    public class InterfaceSegregationPrincipleDemo
    {
    }

    public interface IBike
    {
        void Ride();
        void InflateTheTyre();
    }

    public interface IChargeable
    {
        void Charge();
    }

    public class Bike : IBike
    {
        public void Ride()
        {
            WriteLine("Use your muscles to move forward");
        }

        public void InflateTheTyre()
        {
            WriteLine("Use the pump to inflate the tyre.");
        }
    }

    public class ElectricBike : IBike, IChargeable
    {
        public void Ride()
        {
            WriteLine("Use the electric motor to move forward");
        }

        public void InflateTheTyre()
        {
            WriteLine("Use the pump to inflate the tyre.");
        }

        public void Charge()
        {
            WriteLine("Charging the battery of electric bike.");
        }
    }
}
