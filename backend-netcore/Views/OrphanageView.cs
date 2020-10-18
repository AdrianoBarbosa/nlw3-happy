using System.Collections.Generic;
using Happy.Models;

namespace Happy.Views
{
    public class OrphanageView
    {
        public int OrphanageId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string About { get; set; }
        public string Instructions { get; set; }
        public string OpeningHours { get; set; }
        public bool OpenOnWeekends { get; set; }
        public List<Image> Images { get; set; }
    }
}