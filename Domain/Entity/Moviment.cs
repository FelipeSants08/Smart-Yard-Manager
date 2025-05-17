namespace Smart_Yard_Manager.Domain.Entity
{
    public class Moviment
    {
        public Guid Id { get; set; }
        public string PlacaMoto { get; set; } = null!;
        public DateTime DataHora { get; set; }

        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; } = null!;
    }
}
