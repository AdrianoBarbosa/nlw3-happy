using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Happy.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        
        [Required]
        public string Path { get; set; }

        public int OrphanageId { get; set; }

        [JsonIgnore]
        public virtual Orphanage Orphanage { get; set; }
    }
}