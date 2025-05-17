namespace Smart_Yard_Manager.Application.DTOs
{
    public class MovimentRequestDto
    {
        public string PlacaMoto { get; set; } = null!;
        public DateTime DataHora { get; set; }
        public Guid SensorId { get; set; }
    }
}
