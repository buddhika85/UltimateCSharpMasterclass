namespace GenericsTest
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public int CompareTo(Person? other)
        {
            // Date Of Birth Ascending order
            // Older people come first, then younder people
            if (other == null) return 1;
            if (this == other) return 0;
            if (DateOfBirth <  other.DateOfBirth) return -1;
            return 1;
        }

        public override string ToString()
        {
            return $"{Name} - {DateOfBirth.ToShortDateString()}";
        }
    }

    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
    }
}
