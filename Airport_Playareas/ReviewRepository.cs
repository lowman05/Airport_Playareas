using Airport_Playareas.Models;
using Dapper;
using System.Data;

namespace Airport_Playareas
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbConnection _conn;

        public ReviewRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            string query = @"SELECT r.*, a.AirportName AS AirportName FROM reviews r JOIN airports a ON r.AirportID = a.AirportID";
            return _conn.Query<Review>(query);
        }

        public void AddReview(Review reviewToInsert)
        {
            _conn.Execute("INSERT INTO reviews (AIRPORTID, REVIEWER, RATING, COMMENTS, DATE) VALUES (@airportid, @reviewer, @rating, @comments, @date);",
               new { airportid = reviewToInsert.AirportID, reviewer = reviewToInsert.Reviewer, rating = reviewToInsert.Rating, comments = reviewToInsert.Comments, date = reviewToInsert.Date });
        }
        public Review AssignAirport()
        {
            var airportList = GetAllAirports();
            var review = new Review();
            review.Airports = airportList;
            return review;
        }

        public IEnumerable<Models.Airport> GetAllAirports()
        {
            return _conn.Query<Models.Airport>("SELECT * FROM airports");
        }

    }
}
