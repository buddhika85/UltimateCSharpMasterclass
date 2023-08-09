
//var point = new Point();
//point.Display();
//point.MoveRight(2);
//point.MoveUp(4);
//point.Display();


//new Test();

using OtherTests.InheritanceAndPolymorphism;
//Console.WriteLine($"{string.Join(',', new Exercise().GetCountsOfAnimalsLegs())}");

var list = new List<string> { "bobcat", "wolverine", "grizzly" };
Console.WriteLine($"{string.Join(',', new Exercise2().ProcessAll(list))}");