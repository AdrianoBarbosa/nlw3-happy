using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Happy.Models
{
    public class Orphanage
    {
        public int OrphanageId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Latitude { get; set; }
        
        [Required]
        public decimal Longitude { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string About { get; set; }
        
        [Required]
        public string Instructions { get; set; }
        
        [Required]
        public string OpeningHours { get; set; }
        
        [Required]
        public bool OpenOnWeekends { get; set; }

        public List<Image> Images { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<IFormFile> Files { get; set; }
    }
}