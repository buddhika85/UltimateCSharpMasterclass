﻿
namespace GameDataParserModelAnswer.Model
{
    public class VideoGame
    {
        public string Title { get; init; } = null!;
        public int ReleaseYear { get; init; }
        public decimal Rating { get; init; }

        public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";        
    }
}
