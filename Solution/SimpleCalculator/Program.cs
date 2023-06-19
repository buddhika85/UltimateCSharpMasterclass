
using SimpleCalculator;

TestCalculator();

void TestCalculator()
{
    var numOne = Utitlies.ReadInt("\nHelo!\nInput the first number:");
    var numTwo = Utitlies.ReadInt("Input the second number:");
    var operation = Utitlies.ReadUpperChar("What do you want to do with those numbers?\n[A]dd\n[S]ubtract\n[M]ultiply");
    var calculator = new Calculator();
    switch (operation)
    {
        case 'A':
            Utitlies.DisplayMessage($"{numOne} + {numTwo} = {calculator.Add(numOne, numTwo)}");
            break;
        case 'S':
            Utitlies.DisplayMessage($"{numOne} - {numTwo} = {calculator.Subtract(numOne, numTwo)}");
            break;
        case 'M':
            Utitlies.DisplayMessage($"{numOne} * {numTwo} = {calculator.Multiply(numOne, numTwo)}");
            break;
        default:
            Utitlies.DisplayMessage("Invalid option");
            break;
    }
    var again = Utitlies.ReadUpperChar("Do again?\n[Y]es\n[N]o");
    if (again == 'Y')
        TestCalculator();
}