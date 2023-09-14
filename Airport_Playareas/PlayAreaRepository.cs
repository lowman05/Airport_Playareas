using Airport_Playareas.Models;
using Dapper;
using System.Data;

namespace Airport_Playareas
{
    public class PlayAreaRepository : IPlayAreaRepository
    {
        private readonly IDbConnection _conn;

        public PlayAreaRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<PlayArea> GetPlayAreasByAirportId(int airportId)
        {
            return _conn.Query<PlayArea>("SELECT * FROM PLAYAREAS WHERE AIRPORTID = @AirportId", new { AirportId = airportId });
        }

        public void UpdatePlayArea(PlayArea playArea)
        {
            _conn.Execute("UPDATE playareas SET Terminal = @terminal, Gate = @gate, Description = @description WHERE AirportID = @id",
                new
                {
                    terminal = playArea.Terminal,
                    gate = playArea.Gate,
                    description = playArea.Description,
                    id = playArea.AirportID
                });
        }

        public void InsertPlayArea(PlayArea playAreaToInsert)
        {
            _conn.Execute("INSERT INTO playareas (AIRPORTID, TERMINAL, GATE, DESCRIPTION, PHOTOURL) VALUES (@airportid, @terminal, @gate, @description, @photourl);",
                new { airportid = playAreaToInsert.AirportID, terminal = playAreaToInsert.Terminal, gate = playAreaToInsert.Gate, description = playAreaToInsert.Description, photourl = playAreaToInsert.PhotoURL, });
        }
    }
}
