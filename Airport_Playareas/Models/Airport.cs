using System.ComponentModel.DataAnnotations;

namespace Airport_Playareas.Models
{
    public class Airport
    {
        public Airport() 
        {

        }

        public int AirportID { get; set; }
        [Required(ErrorMessage = "Airport Name is Required.")]
        public string AirportName { get; set; }
        [Required(ErrorMessage = "Three Letter Airport Identifier is required.")]
        [StringLength(3, ErrorMessage = "The Airport Code must be 3 characters long.")]
        public string AirportCode { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        [NormalizeUrl]
        public string? Website { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
        //public ICollection<LactationArea>? LactationAreas { get; set; }
        //public ICollection<PlayArea>? PlayAreas { get; set; }

        public List<LactationArea> LactationAreas { get; set; } = new List<LactationArea>();
        public List<PlayArea> PlayAreas { get; set; } = new List<PlayArea>();

    }
}
