namespace Smart_Yard_Manager.Application.DTOs
{
    public class MovimentResponseDto
    {
        public Guid Id { get; set; }
        public string PlacaMoto { get; set; } = null!;
        public DateTime DataHora { get; set; }

        public Guid SensorId { get; set; }
        public string SensorName { get; set; } = null!;
        public string SensorSection { get; set; } = null!;
    }
}
