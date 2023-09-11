using System.Security.Cryptography.X509Certificates;

namespace Airport_Playareas.Models
{
    public class Airport
    {
        //public Airport() 
        //{
       
        //}

        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public string AirportCode{ get; set; }
        public string? State { get; set; }
        public string? Country  { get; set; }
        public string? Website   { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
        public ICollection<LactationArea>? LactationAreas { get; set; }
        public ICollection<PlayArea>? PlayAreas { get; set; }
        public IEnumerable<LactationArea>LactationAreasL2 { get; set; }
        public IEnumerable<PlayArea> PlayAreasP2 { get; set; }
    }
}
