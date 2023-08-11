using Microsoft.AspNetCore.Mvc;

namespace Airport_Playareas.Controllers
{
    public class PlayAreasController : Controller
    {
        private readonly IPlayAreasRepository repo;
        public PlayAreasController(IPlayAreasRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var playAreas = repo.GetAllPlayAreas();
            return View(playAreas);
        }
    }
}
