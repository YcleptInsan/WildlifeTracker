using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildlifeTracker.Models
{
    [Table("Sighting")]
    public class Sighting
    {
        [Key]
        public int SightingId { get; set; }
        public string Date { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int SpeciesId { get; set; }
        public virtual Species Species { get; set; }
    }
}
