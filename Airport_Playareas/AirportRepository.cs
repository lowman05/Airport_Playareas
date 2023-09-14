using Airport_Playareas.Models;
using Dapper;
using System.Data;
namespace Airport_Playareas
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IDbConnection _conn;

        public AirportRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            return _conn.Query<Airport>("SELECT * FROM AIRPORTS;");
        }

        public Airport GetAirportById(int id)
        {
            return _conn.QuerySingleOrDefault<Airport>("SELECT*FROM AIRPORTS WHERE AirportID = @id", new { id = id });
        }

        public IEnumerable<Airport> GetAirportByName(string airportName)
        {
            return _conn.Query<Airport>("SELECT*FROM AIRPORTS WHERE AirportName = @name", new { name = airportName });
            //if(airports.Count > 1)
            //{
            //    throw new InvalidOperationException("Multiple airports with the same name found.");
            //}
            //return airports.SingleOrDefault();
        }

        public void InsertAirport(Airport airportToInsert)
        {
            _conn.Execute("INSERT INTO airports(AIRPORTNAME, AIRPORTCODE, STATE, COUNTRY, WEBSITE) VALUES (@airportname, @airportcode, @state, @country, @website);",
                new { airportname = airportToInsert.AirportName, airportcode = airportToInsert.AirportCode, state = airportToInsert.State, country = airportToInsert.Country, website = airportToInsert.Website });
        }

    }
}
