namespace Airport_Playareas.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int AirportID { get; set; }
        public string Reviewer { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public string AirportName { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
    }
}
