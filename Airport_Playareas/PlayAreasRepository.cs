using Airport_Playareas.Models;
using Dapper;
using System.Data;

namespace Airport_Playareas
{
    public class PlayAreasRepository : IPlayAreasRepository
    {
        private readonly IDbConnection _conn;
        public PlayAreasRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<PlayAreas> GetAllPlayAreas()
        {
            return _conn.Query<PlayAreas>("SELECT * FROM PLAYAREAS;");
        }
    }
}
