namespace SharedComponents.Model
{
    public class UserPollingStationVisitModel
    {
        public int? Id { get; set; }
        public int MySqlId { get; set; }
        public int UserId { get; set; }
        public int PollingStationId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int PeopleOutsideInQueue { get; set; }
        public bool DisabledAccess { get; set; }
        public string Notes { get; set; }
        public string Signature { get; set; }
    }
}
