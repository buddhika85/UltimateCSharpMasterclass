using System.Text;

namespace ToDoList
{
    public class ToDos
    {
        public List<ToDo> ToDoList { get; private set; } = new();

        private int _id = 0;


        // find by id - list lookup
        public ToDo? Find(int id)
        {
            return ToDoList.FirstOrDefault(toDo => toDo.Matches(id));
        }

        // find by description - list lookup
        public ToDo? Find(string uniqueDescription)
        {
            return ToDoList.FirstOrDefault(toDo => toDo.Matches(uniqueDescription));
        }

        // add
        public void Add(string uniqueDescription)
        {
            if (string.IsNullOrWhiteSpace(uniqueDescription))
                throw new ArgumentException("The description cannot be empty");
            if (Find(uniqueDescription) != null)
                throw new ArgumentException("The description must be unique.");
            ToDoList.Add(new ToDo { Description = uniqueDescription.ToLower(), Id = ++_id });
        }

        // remove
        public void Remove(int id)
        {
            var toRemove = Find(id);
            if (toRemove == null)
                throw new ArgumentException("The given index is not valid.");
            ToDoList.Remove(toRemove);
        }

        public void Remove(ToDo? toRemove)
        {
            if (toRemove == null)
                throw new ArgumentException("The given index is not valid.");
            ToDoList.Remove(toRemove);
        }

        // isEmpty
        public bool IsEmpty()
        {
            return !ToDoList.Any();
        }

        public override string ToString()
        {
            if (!ToDoList.Any())
                return "No TODOs have been added yet.";

            StringBuilder sb = new();
            foreach (var toDo in ToDoList)
            {
                sb.AppendLine(toDo.ToString());
            }
            return sb.ToString();
        }
    }
}
