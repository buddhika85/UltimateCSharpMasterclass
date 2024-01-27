using static System.Console;
namespace DesignPatterns.StaticFactoryMethod
{
    public static class StaticFactoryMethodDemo
    {
        public static void Demo()
        {
            var forChildAccount = BankAccount.OpenAccountForChild();
            var forRegularAccount = BankAccount.OpenAccountForRegular();
            WriteLine(forChildAccount);
            WriteLine(forRegularAccount);
        }
    }

    public class BankAccount
    {
        private readonly int _maxWithdrawLimit;

        // private constructor
        private BankAccount(bool isChild)
        {
            _maxWithdrawLimit = isChild ? 200 : 2000;
        }

        // public static methods instead of public constructor
        public static BankAccount OpenAccountForChild()
        {
            return new BankAccount(true);
        }

        // public static methods instead of public constructor
        public static BankAccount OpenAccountForRegular()
        {
            return new BankAccount(false);
        }
        public override string ToString() =>
            $"BankAccount with {_maxWithdrawLimit} withdraw limit";
    }
}
