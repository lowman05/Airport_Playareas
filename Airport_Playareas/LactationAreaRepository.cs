using Airport_Playareas.Models;
using Dapper;
using System.Data;

namespace Airport_Playareas
{
    public class LactationAreaRepository : ILactationAreaRepository
    {
        private readonly IDbConnection _conn;   


        public LactationAreaRepository (IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<LactationArea> GetLactationAreasByAirportId(int airportId)
        {
            return _conn.Query<LactationArea>("SELECT * FROM LACTATIONAREAS WHERE AIRPORTID = @AirportId", new { AirportId = airportId });
        }

        public LactationArea GetLactationAreaById(int id)
        {
            return _conn.QuerySingle<LactationArea>("SELECT * FROM LACTATIONAREAS WHERE LACTATIONAREAID = @id",
                new { id = id });
        }

        public void UpdateLactationArea(LactationArea lactationArea)
        {
            _conn.Execute("UPDATE lactationareas SET Terminal = @terminal, Gate = @gate, Description = @description WHERE AirportID = @id",
                new { terminal = lactationArea.Terminal, gate = lactationArea.Gate, description = lactationArea.Description, id = lactationArea.AirportID });
        }

        public void InsertLactationArea(LactationArea lactationAreaToInsert)
        {
            _conn.Execute("INSERT INTO lactationareas (AIRPORTID, TERMINAL, GATE, DESCRIPTION, PHOTOURL) VALUES (@airportid, @terminal, @gate, @description, @photourl);",
                new { airportid = lactationAreaToInsert.AirportID, terminal = lactationAreaToInsert.Terminal, gate = lactationAreaToInsert.Gate, description = lactationAreaToInsert.Description, photourl = lactationAreaToInsert.PhotoURL });
        }
    }
}
