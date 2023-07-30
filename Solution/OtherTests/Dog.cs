namespace OtherTests
{
    public class Dog
    {
        private string _name;
        private string _breed;
        private int _weight;

        public Dog(string name, string breed, int weight)
        {
            _name = name;
            _breed = breed;
            _weight = weight;
        }

        public Dog(string name, int weight) : this(name, "mixed-breed", weight)
        {
        }

        public string Describe()
        {
            switch (_weight)
            {
                case < 5:
                    return
                        $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a tiny dog.";
                case >= 30:
                    return
                        $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a large dog.";
                default:
                    return
                        $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a medium dog.";
            }

        }
    }
}
