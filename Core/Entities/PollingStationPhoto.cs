namespace Core.Entities
{
    public class PollingStationPhoto :BaseEntity
    {
        public int PollingStationId { get; set; }
        public virtual PollingStation PollingStation { get; set; }
        public string Photo { get; set; }
        public DateTime Date { get; set; }
    }
}
