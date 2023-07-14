
using SimpleCalculator;

TestCalculator();

void TestCalculator()
{
    var numOne = Utilities.ReadInt("\nHello!\nInput the first number:");
    var numTwo = Utilities.ReadInt("Input the second number:");
    var operation = Utilities.ReadUpperChar("What do you want to do with those numbers?\n[A]dd\n[S]ubtract\n[M]ultiply");
    var calculator = new Calculator();
    switch (operation)
    {
        case 'A':
            Utilities.DisplayMessage($"{numOne} + {numTwo} = {calculator.Add(numOne, numTwo)}");
            break;
        case 'S':
            Utilities.DisplayMessage($"{numOne} - {numTwo} = {calculator.Subtract(numOne, numTwo)}");
            break;
        case 'M':
            Utilities.DisplayMessage($"{numOne} * {numTwo} = {calculator.Multiply(numOne, numTwo)}");
            break;
        default:
            Utilities.DisplayMessage("Invalid option");
            break;
    }
    var again = Utilities.ReadUpperChar("Do again?\n[Y]es\n[N]o");
    if (again == 'Y')
        TestCalculator();
}