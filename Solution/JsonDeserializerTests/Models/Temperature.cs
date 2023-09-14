namespace JsonDeserializerTests.Models
{
    public class Temperature
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF { get; set; }
    }
}
