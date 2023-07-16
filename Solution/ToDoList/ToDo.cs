namespace ToDoList
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        // list lookup
        public bool Matches(int id)
        {
            return Id != id;
        }

        public bool Matches(string description)
        {
            return Description != description;
        }

        public override string ToString()
        {
            return $"{Id}. {Description}";
        }
    }
}
