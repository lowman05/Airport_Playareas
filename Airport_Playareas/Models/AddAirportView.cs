using System.ComponentModel.DataAnnotations;

namespace Airport_Playareas.Models
{
    public class AddAirportView
    {
        [Required(ErrorMessage = "Airport Name is Required.")]
        public string AirportName { get; set; }

        [Required(ErrorMessage = "Three Letter Airport Identifier is required.")]
        [StringLength(3, ErrorMessage = "The Airport Code must be 3 characters long.")]
        public string AirportCode { get; set; }

        public string State { get; set; }
        [NormalizeUrl]
        public string? Website { get; set; }
        public Airport Airport { get; set; }

        public List<LactationArea>? LactationAreas { get; set; } = new List<LactationArea>();
        public List<PlayArea>? PlayAreas { get; set; } = new List<PlayArea>();

        public LactationArea? LactationArea { get; set; }   
        public PlayArea? PlayArea { get; set; }
      
    }

}
