using Dapper;
using System.Data;
using Airport_Playareas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airport_Playareas.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository repo;
        public ReviewController(IReviewRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var reviews = repo.GetAllReviews();
            return View(reviews);
        }

        public IActionResult AddReview()
        {
            var review = repo.AssignAirport();
            return View(review);
        }

        public IActionResult AddReviewToDatabase(Review reviewToInsert)
        {
            repo.AddReview(reviewToInsert);
            return RedirectToAction("Index");
        }

    }
}
