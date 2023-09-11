using Airport_Playareas.Models;

namespace Airport_Playareas
{
    public interface IPlayAreaRepository
    {
        public IEnumerable<PlayArea> GetPlayAreasByAirportId(int airportId);
        public void UpdatePlayArea(PlayArea playArea);
        public void InsertPlayArea(PlayArea playAreaToInsert);
    }
}
