using static System.Console;

namespace DesignPatterns.Builder
{

    public class Person
    {
        private string _name;
        private int _yearOfBirth;

        // cannot access outside of it
        private Person(string name, int yearOfBirth)
        {
            _name = name;
            _yearOfBirth = yearOfBirth;
        }

        public override string ToString()
        {
            return $"{_name} - {_yearOfBirth}";
        }


        // inner class
        public class PersonBuilder
        {
            private string _name;
            private int _yearOfBirth;

            public PersonBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public PersonBuilder WithYearOfBirth(int yearOfBirth)
            {
                _yearOfBirth = yearOfBirth;
                return this;
            }

            public PersonBuilder WithAge(int age)
            {
                _yearOfBirth = DateTime.Today.Year - age;
                return this;
            }

            public Person Build()
            {
                return new Person(_name, _yearOfBirth);
            }
        }
    }



    public static class BuilderDemo
    {
        public static void Demo()
        {
            // not possible - private
            //Person person = new Person("Jack", 1985);

            // using builder
            Person person1 = new Person.PersonBuilder()
                .WithName("Jack")
                .WithYearOfBirth(1985)
                .Build();

            // using builder with a different configuration
            Person person2 = new Person.PersonBuilder()
                .WithName("Jack")
                .WithAge(39)
                .Build();

            WriteLine(person1);
            WriteLine(person2);
        }
    }
}
