using Airport_Playareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Airport_Playareas.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportRepository repo;
        private readonly ILactationAreaRepository _lactationAreaRepository;
        private readonly IPlayAreaRepository _playAreaRepository;
        private readonly IDbConnection _conn;

        public AirportController(IAirportRepository repo, ILactationAreaRepository lactationAreaRepository, IPlayAreaRepository playAreaRepository, IDbConnection conn)
        {
            this.repo = repo;
            _lactationAreaRepository = lactationAreaRepository;
            _playAreaRepository = playAreaRepository;
            _conn = conn;
        }

        public IActionResult Index()
        {
            var airports = repo.GetAllAirports();

            return View(airports);
        }


        public IActionResult AirportView(int airportId)
        {
            var airport = repo.GetAirportById(airportId);
            if (airport == null)
            {
                return NotFound();
            }
            ICollection<LactationArea> lactationAreas = _lactationAreaRepository.GetLactationAreasByAirportId(airportId).ToList();
            ICollection<PlayArea> playAreas = _playAreaRepository.GetPlayAreasByAirportId(airportId).ToList();

            var viewModel = new AirportDetailsViewModel
            {
                Airport = airport,
                LactationAreas = lactationAreas,
                PlayAreas = playAreas
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult AddAirport()
        {
            var airport = new Airport();
            return View(airport);
        }
       
       


        public IActionResult InsertLactationArea()
        {
            var lactationArea = new LactationArea();
            return View(lactationArea);
        }

        public IActionResult InsertLactationAreaToDatabase(LactationArea lactationAreaToInsert)
        {
            _lactationAreaRepository.InsertLactationArea(lactationAreaToInsert);
            return RedirectToAction("Index");
        }


        public IActionResult InsertPlayArea()
        {
            var playArea = new PlayArea();
            return View(playArea);
        }

        public IActionResult InsertPlayAreaToDatabase(PlayArea playAreaToInsert)
        {
            _playAreaRepository.InsertPlayArea(playAreaToInsert);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult AddAirportToDatabase(Airport airport, List<string> LactationAreas, List<string> LactationTerminal, List<string> LactationGate, List<string> LactationDescription,
                                    List<string> PlayAreas, List<string> PlayTerminal, List<string> PlayGate, List<string> PlayDescription)
        {
            if (ModelState.IsValid)
            {
                // Insert the airport into the database
                repo.InsertAirport(airport);

                // Insert lactation areas
                for (int i = 0; i < LactationAreas.Count; i++)
                {
                    var lactationArea = new LactationArea
                    {
                        AirportID = airport.AirportID,
                        
                        Terminal = LactationTerminal[i],
                        Gate = LactationGate[i],
                        Description = LactationDescription[i]
                    };
                    _lactationAreaRepository.InsertLactationArea(lactationArea);
                }

                // Insert play areas
                for (int i = 0; i < PlayAreas.Count; i++)
                {
                    var playArea = new PlayArea
                    {
                        AirportID = airport.AirportID,
                        
                        Terminal = PlayTerminal[i],
                        Gate = PlayGate[i],
                        Description = PlayDescription[i]
                    };
                    _playAreaRepository.InsertPlayArea(playArea);
                }

                return RedirectToAction("Index"); // Redirect to a success page or another appropriate action
            }

            // If ModelState is not valid, return to the form with validation errors
            return View("AddAirportToDatabase", airport);
        }


    }
}
