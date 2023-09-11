using Airport_Playareas.Models;

namespace Airport_Playareas
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAllReviews();
        public void AddReview(Review reviewToInsert);
        public Review AssignAirport();
        public IEnumerable<Models.Airport> GetAllAirports();
    }
}
