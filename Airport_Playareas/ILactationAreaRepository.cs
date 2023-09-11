using Airport_Playareas.Models;

namespace Airport_Playareas
{
    public interface ILactationAreaRepository
    {
        public IEnumerable<LactationArea> GetLactationAreasByAirportId(int airportId);
        public void UpdateLactationArea(LactationArea lactationArea);
        public LactationArea GetLactationAreaById(int id);
        public void InsertLactationArea(LactationArea lactationAreaToInsert);
    }
}
