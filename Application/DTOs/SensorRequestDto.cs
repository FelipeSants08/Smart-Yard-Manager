namespace Smart_Yard_Manager.Application.DTOs
{
    public class SensorRequestDto
    {
        public string Name { get; set; } = null!;
        public int Section { get; set; }  
        public bool Active { get; set; }
    }
}
