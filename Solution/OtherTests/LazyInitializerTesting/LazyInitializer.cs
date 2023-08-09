namespace OtherTests.LazyInitializerTesting
{
    // new() puts constrain that any class that is used to 
    // replace T has to have a parameterless constructor
    public class LazyInitializer<T> where T : new()
    {
        private T _value;

        public T Get()
        {
            if (_value == null)
            {
                _value = new T();
            }
            return _value;
        }
    }

    public class Pet
    {
        public Pet() { }
    }

    public class Dog
    {
        public Dog(string breed) { }
    }

    public class Test
    {
        public Test()
        {
            Pet pet = new LazyInitializer<Pet>().Get();

            // below do not compile because dog do not have parameterless constructor 
            ////Dog dog = new LazyInitializer<Dog>().Get();
        }
    }
}
