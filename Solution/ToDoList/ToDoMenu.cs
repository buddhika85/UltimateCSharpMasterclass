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
                    Menu();
                    break;
                case 'R':
                    Remove();
                    Menu();
                    break;
                case 'E':
                    Exit();
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }

        private char ReadAction()
        {
            Console.WriteLine("\nWhat do you want to do? ");
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
            try
            {
                Console.WriteLine("Enter the TODO description: ");
                var description = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(description))
                {
                    if (_toDos.Find(description) != null)
                    {
                        Console.WriteLine("The description must be unique.");
                        Add();      // asking for description again
                    }
                    else
                    {
                        _toDos.Add(description);
                        Console.WriteLine($"TODO successfully added: {description}");
                    }
                }
                else
                {
                    Console.WriteLine("The description cannot be empty.");
                    Add();      // asking for description again
                }

            }
            catch (ArgumentException e)
            {
                if (string.IsNullOrWhiteSpace(e.Message))
                {
                    Console.WriteLine("Unknown error occurred");
                }
                else
                {
                    Console.Write(e.Message);
                }
                Add();      // asking for description again
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error occurred");
                Add();      // asking for description again
            }
        }

        private void Remove()
        {
            try
            {
                if (_toDos.IsEmpty())
                {
                    Console.WriteLine("No TODOs have been added yet");
                    return;
                }

                Console.WriteLine("Select the index of the TODO you want to remove: ");
                var idStr = Console.ReadLine();
                if (int.TryParse(idStr, out var id))
                {
                    var toRemove = _toDos.Find(id);
                    if (toRemove != null)
                    {
                        _toDos.Remove(id);
                    }
                    else
                    {
                        Console.WriteLine("The given index is not valid.");
                        Remove();   // asking for id again
                    }
                }
                else
                {
                    Console.WriteLine("The given index is not valid.");
                    Remove();   // asking for id again
                }

            }
            catch (ArgumentException e)
            {
                if (string.IsNullOrWhiteSpace(e.Message))
                {
                    Console.WriteLine("Unknown error occurred");
                }
                else
                {
                    Console.Write(e.Message);
                }
                Remove();      // asking for id again
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error occurred");
                Remove();      // asking for id again
            }
        }

        private void Exit()
        {
            if (Confirm())
            {
                Console.WriteLine("Exiting");
            }
            else
            {
                Menu();
            }
        }

        private bool Confirm()
        {
            Console.WriteLine("\nAre you sure? [Y/N]");
            var sureOrNot = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(sureOrNot) && sureOrNot.ToUpper()[0] == 'Y';
        }
    }
}
