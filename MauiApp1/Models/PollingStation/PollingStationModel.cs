using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models.PollingStation
{
    public class PollingStationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TravelTime { get; set; }
        public int JourneyDistanceMiles { get; set; }
        public int? VisitCount { get; set; }
        public DateTime? LastVisitTime { get; set; }
    }
}
