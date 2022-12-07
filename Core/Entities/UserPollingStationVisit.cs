namespace Core.Entities
{
    public class UserPollingStationVisit : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PollingStationId { get; set; }
        public virtual PollingStation PollingStation { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int PeopleOutsideInQueue { get; set; }
        public bool DisabledAccess { get; set; }
        public string Notes { get; set; }
        public string Signature { get; set; }
    }
}
