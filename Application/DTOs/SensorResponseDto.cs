namespace Smart_Yard_Manager.Application.DTOs
{
    public class SensorResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Section { get; set; } = null!;  
        public bool Active { get; set; }
    }
}
