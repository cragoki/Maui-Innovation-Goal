namespace Core.Entities
{
    public class PollingStation : BaseEntity
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public bool IsOpen { get; set; }

        //Coordinates
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
