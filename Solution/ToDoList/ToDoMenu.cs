namespace ToDoList
{
    public class ToDoMenu
    {
        private const char Invalid = 'z';
        private readonly ToDos _toDos = new();
        public ToDoMenu()
        {
            Console.WriteLine("Hello");
            Menu();
        }

        private void Menu()
        {
            var input = ReadAction();
            switch (input)
            {
                case 'S':
                    SeeAll();
                    Menu();
                    break;
                case 'A':
                    Add();
                    break;
                case 'R':
                    break;
                case 'X':
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }

        private char ReadAction()
        {
            Console.WriteLine("What do you want to do? ");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");
            var str = Console.ReadLine();
            return str == null ? Invalid : str.ToUpper()[0];
        }

        private void SeeAll()
        {
            Console.WriteLine($"{_toDos}");         // calls toString
        }

        private void Add()
        {
            // Console.WriteLine("Enter the TODO description: ");
            // if ()
        }

    }
}
