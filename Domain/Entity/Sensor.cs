using Smart_Yard_Manager.Domain.Enum;

namespace Smart_Yard_Manager.Domain.Entity
{
    public class Sensor
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public SensorSection Section { get; set; }
        public bool Active { get; set; }

        public List<Moviment> Moviments { get; set; } = new();

    }
}
