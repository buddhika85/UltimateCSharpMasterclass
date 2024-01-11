namespace GameDataParser.model
{
    //{
    //    "Title": "Stardew Valley",
    //    "ReleaseYear": 2016,
    //    "Rating": 4.9
    //},
    public class Game
    {
        public string Title { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public float Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
        }
    }
}
