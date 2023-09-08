using static System.Console;

namespace OtherTests.ShallowVsDeepCopy
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;

        public Employee GetShallowCopy()
        {
            return (Employee)MemberwiseClone();
        }

        public Employee GetDeepCopy()
        {
            return new Employee
            {
                Id = Id,
                Name = Name,
                Address = new Address
                {
                    Number = Address.Number,
                    City = Address.City,
                    Lane = Address.Lane
                }
            };
        }

        public override string ToString()
        {
            return $"Employee ID {Id} Name {Name} {Address}";
        }
    }

    public class Address
    {
        public int Number { get; set; }
        public string Lane { get; set; } = null!;
        public string City { get; set; } = null!;

        public override string ToString()
        {
            return $"Address {Number},{Lane},{City}";
        }
    }

    public class TestShallowVsDeep
    {
        public void TestShallowCopy()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "John",
                Address = new Address
                {
                    Number = 100,
                    Lane = "1st Lane",
                    City = "SunCity"
                }
            };

            var employeeShallowCopy = employee.GetShallowCopy();

            // changing reference members values in shallow copy
            // this change should reflect on original object also
            // because both original and shallow reuse same address object
            employeeShallowCopy.Address.Number = 200;
            employeeShallowCopy.Address.Lane = "2nd Lane";
            employeeShallowCopy.Address.City = "RainCity";

            WriteLine($"Original     - {employee}");
            WriteLine($"Shallow Copy - {employeeShallowCopy}");
        }

        public void TestDeepCopy()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "John",
                Address = new Address
                {
                    Number = 100,
                    Lane = "1st Lane",
                    City = "SunCity"
                }
            };

            var employeeShallowCopy = employee.GetDeepCopy();

            // changing reference members values in deep copy
            // this change should not reflect on original object 
            // because original and deep copy use different address objects
            employeeShallowCopy.Address.Number = 200;
            employeeShallowCopy.Address.Lane = "2nd Lane";
            employeeShallowCopy.Address.City = "RainCity";

            WriteLine($"Original     - {employee}");
            WriteLine($"Deep Copy    - {employeeShallowCopy}");
        }
    }
}

