using Airport_Playareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections.Generic;



namespace Airport_Playareas.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportRepository repo;
        private readonly ILactationAreaRepository _lactationAreaRepository;
        private readonly IPlayAreaRepository _playAreaRepository;

        public AirportController(IAirportRepository repo, ILactationAreaRepository lactationAreaRepository, IPlayAreaRepository playAreaRepository)
        {
            this.repo = repo;
            _lactationAreaRepository = lactationAreaRepository;
            _playAreaRepository = playAreaRepository;
        }
        
        public IActionResult Index() 
        {
            var airports = repo.GetAllAirports();          

            return View( airports);
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
        //public IActionResult AddAirport()
        //{
        //    var airport = new AirportDetailsViewModel();

        //    return View(airport);
        //}

        //public IActionResult AddAirportToDatabase(AirportDetailsViewModel airportToInsert)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        repo.InsertAirport(airportToInsert.Airport);
        //        var newAirport = repo.GetAirportByName(airportToInsert.Airport.AirportName);
        //        if (airportToInsert.LactationAreas != null)
        //        {
        //            foreach (var lactationArea in airportToInsert.LactationAreas)
        //            {
        //                lactationArea.AirportID = newAirport.AirportID;
        //                _lactationAreaRepository.InsertLactationArea(lactationArea);

        //            }
        //        }
        //        if (airportToInsert.PlayAreas != null)
        //        {
        //            foreach (var playArea in airportToInsert.PlayAreas)
        //            {

        //                playArea.AirportID = newAirport.AirportID;
        //                _playAreaRepository.InsertPlayArea(playArea);

        //            }
        //        }


        //        return RedirectToAction("Index");
        //    }
        //    return View("AddAirport", airportToInsert);
        //}
        public IActionResult AddAirport()
        {
            var airport = new AddAirportView();
            return View(airport);
        }
        public IActionResult AddAirportToDatabase(AddAirportView airportToInsert)
        {
            if (ModelState.IsValid)
            {

                var existingAirports = repo.GetAirportByName(airportToInsert.AirportName);
                if (existingAirports.Any())
                {

                    ModelState.AddModelError("AirportName", "An airport with the same name already exists.");
                    return View("AddAirport", airportToInsert);
                }
                var airport = new Airport
                {
                    AirportName = airportToInsert.AirportName,
                    AirportCode = airportToInsert.AirportCode,
                    State = airportToInsert.State,
                    Website = airportToInsert.Website
                };
                repo.InsertAirport(airport);

                //var newAirport = repo.GetAirportByName(airport.AirportName);

                
                                        
                        foreach (var lactationArea in airportToInsert.LactationAreas)
                        {
                            lactationArea.AirportID = airport.AirportID;
                            _lactationAreaRepository.InsertLactationArea(lactationArea);
                        }





                        foreach (var playArea in airportToInsert.PlayAreas)
                        {
                            playArea.AirportID = airport.AirportID;
                            _playAreaRepository.InsertPlayArea(playArea);

                        }
                    
                    return RedirectToAction("Index");
            }

                //foreach (var modelState in ModelState.Values)
                //{
                //    foreach (var error in modelState.Errors)
                //    {
                //        // Log the error message to the console
                //        Console.WriteLine(error.ErrorMessage);
                //    }
                //}

                return View("AddAirport", airportToInsert);
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
            return View (playArea);
        }

        public IActionResult InsertPlayAreaToDatabase(PlayArea playAreaToInsert)
        {
            _playAreaRepository.InsertPlayArea(playAreaToInsert);
            return RedirectToAction("Index");
        }
    }
}
