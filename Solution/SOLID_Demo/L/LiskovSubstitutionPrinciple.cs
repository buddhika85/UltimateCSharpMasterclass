using static System.Console;

namespace SOLID_Demo.L
{
    public class LiskovSubstitutionPrinciple
    {
        public static void Demo()
        {
            KingFisher kingFisher = new KingFisher();
            Drone drone = new Drone();

            AllIFlyables allIFlyables = new AllIFlyables();

            allIFlyables.Fly(kingFisher);

            // I can do the same method call using a Drone also
            allIFlyables.Fly(drone);
        }
    }

    public class AllIFlyables
    {
        public void Fly(IFlyable flyable)
        {
            flyable.Fly();
        }
    }

    public interface IFlyable
    {
        void Fly();
    }

    public class KingFisher : IFlyable
    {
        public void Fly()
        {
            WriteLine("King Fisher Flies");
        }
    }

    public class Crow : IFlyable
    {
        public void Fly()
        {
            WriteLine("Crow Flies");
        }
    }

    public class Kite : IFlyable
    {
        public void Fly()
        {
            WriteLine("Kite Flying");
        }
    }

    public class Drone : IFlyable
    {
        public void Fly()
        {
            WriteLine("Drone Flying");
        }
    }
}
