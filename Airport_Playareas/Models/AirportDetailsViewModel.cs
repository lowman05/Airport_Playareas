namespace Airport_Playareas.Models;

public class AirportDetailsViewModel
{
    //public Models.AirportDetailsViewModel Airport { get; set; }

    //public IEnumerable<LactationArea> LactationAreas { get; set; }
    //public IEnumerable<PlayArea> PlayAreas { get; set; }



    public ICollection<LactationArea>? LactationAreas { get; set; } = new List<LactationArea>();
    public ICollection<PlayArea>? PlayAreas { get; set; } = new List<PlayArea>();

    //public LactationArea? LactationArea { get; set; }
    //public PlayArea? PlayArea { get; set; }
    //public IEnumerable<Airport>Airports { get; set; }
    public Airport Airport { get; set; }
    public int AirportID { get; set; }

}
