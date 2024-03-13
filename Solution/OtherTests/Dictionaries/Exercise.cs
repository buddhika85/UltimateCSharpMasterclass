namespace OtherTests.Dictionaries
{
    public static class Exercise
    {
        public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
        {
            Dictionary<PetType, double> result = new Dictionary<PetType, double>();
            foreach (var pet in pets)
            {
                if (result.ContainsKey(pet.PetType))                    
                    result[pet.PetType] = result[pet.PetType] < pet.Weight ? pet.Weight : result[pet.PetType];
                else
                    result.Add(pet.PetType, pet.Weight);                
            }
            return result;
        }
    }

    public class Pet
    {
        public PetType PetType { get; }
        public double Weight { get; }

        public Pet(PetType petType, double weight)
        {
            PetType = petType;
            Weight = weight;
        }

        public override string ToString() => $"{PetType}, {Weight} kilos";
    }

    public enum PetType { Dog, Cat, Fish }
}
