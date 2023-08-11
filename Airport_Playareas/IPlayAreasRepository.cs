using Airport_Playareas.Models;

namespace Airport_Playareas
{
    public interface IPlayAreasRepository
    {
        public IEnumerable<PlayAreas> GetAllPlayAreas();
    }
}
