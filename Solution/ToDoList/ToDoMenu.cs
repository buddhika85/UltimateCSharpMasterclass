namespace ToDoList
{
    public class ToDoMenu
    {
        private readonly ToDos _toDos = new();
        public ToDoMenu()
        {
            _toDos.Add("test 1");
            _toDos.Add("test 2");
            _toDos.Add("test 3");
            _toDos.Add("test 4");
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
                    Menu();
                    break;
            }
        }

        private char? ReadAction()
        {
            Console.WriteLine("\nWhat do you want to do? ");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");
            return Console.ReadLine()?.ToUpper()[0];
        }

        private void SeeAll()
        {
            Console.WriteLine($"{_toDos}");         // calls toString
        }

        private void Add()
        {
            try
            {
                var description = ReadDescription();
                if (IsValidDescription(description))
                {
                    _toDos.Add(description);    // if here its not null and unique
                    Console.WriteLine($"TODO successfully added: {description}");
                }
                else
                {
                    Add();  // asking for description again
                }

            }
            catch (ArgumentException e)
            {
                if (string.IsNullOrWhiteSpace(e.Message))
                {
                    DisplayUnknownErrorOccurred();
                }
                else
                {
                    Console.Write(e.Message);
                }
                Add();      // asking for description again
            }
            catch (Exception)
            {
                DisplayUnknownErrorOccurred();
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


                if (IsValidIndex(ReadToDoIndex(), out ToDo? toRemove))
                {
                    _toDos.Remove(toRemove);
                    Console.WriteLine($"TODO removed: {toRemove?.Description}");
                }
                else
                {
                    DisplayIndexInvalid();
                    Remove();   // asking for id again
                }

            }
            catch (ArgumentException e)
            {
                if (string.IsNullOrWhiteSpace(e.Message))
                {
                    DisplayUnknownErrorOccurred();
                }
                else
                {
                    Console.Write(e.Message);
                }
                Remove();      // asking for id again
            }
            catch (Exception)
            {
                DisplayUnknownErrorOccurred();
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



        #region helpers

        private bool IsValidIndex(string? idStr, out ToDo? toRemove)
        {
            toRemove = null;
            if (int.TryParse(idStr, out var id))
            {
                toRemove = _toDos.Find(id);
                return toRemove != null;
            }
            return false;
        }

        private string? ReadToDoIndex()
        {
            Console.WriteLine("Select the index of the TODO you want to remove: ");
            SeeAll();
            return Console.ReadLine();
        }

        private string? ReadDescription()
        {
            Console.WriteLine("Enter the TODO description: ");
            return Console.ReadLine();
        }

        private bool IsValidDescription(string? description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (_toDos.Find(description) == null)
                    return true;

                Console.WriteLine("The description must be unique.");
                return false;

            }

            Console.WriteLine("The description cannot be empty.");
            return false;
        }

        private void DisplayIndexInvalid()
        {
            Console.WriteLine("The given index is not valid.");
        }

        private void DisplayUnknownErrorOccurred()
        {
            Console.WriteLine("Unknown error occurred");
        }

        #endregion helpers
    }
}
