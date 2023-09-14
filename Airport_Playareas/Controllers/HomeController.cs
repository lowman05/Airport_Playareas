using Airport_Playareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Airport_Playareas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAirportRepository _airportRepository;



        public HomeController(ILogger<HomeController> logger, IAirportRepository airportRepository)
        {
            _logger = logger;

            _airportRepository = airportRepository;

        }


        public IActionResult Index()
        {
            var airports = _airportRepository.GetAllAirports();
            return View(airports);
        }
        public IActionResult AirportView(int airportId)
        {
            var airport = _airportRepository.GetAirportById(airportId);
            return View(airport);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}