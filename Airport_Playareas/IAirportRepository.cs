using Airport_Playareas.Models;

namespace Airport_Playareas
{
    public interface IAirportRepository
    {
        public IEnumerable<Airport> GetAllAirports();
        public Airport GetAirportById(int id);

        public void InsertAirport (Airport airportToInsert);

        //public Airport GetAirportByName(string airportName);
        public IEnumerable<Airport> GetAirportByName(string airportName);
    }
}
