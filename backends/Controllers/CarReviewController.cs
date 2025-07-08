using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using backend.Data;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarReviewController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserReviews(int userId)
        {
            var reviews = await _context.CarReviews
                .Where(r => r.UserId == userId)
                .Select(r => new { r.CarId, r.Rating, r.Review })
                .ToListAsync();

            return Ok(reviews);
        }

        // 1. GET: api/CarReview/Car/{carId} - Get all reviews for a specific car
        [HttpGet("Car/{carId}")]
        public async Task<IActionResult> GetReviewsByCar(int carId)
        {
            var reviews = await _context.CarReviews
                .Where(r => r.CarId == carId)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found for this car.");

            var result = reviews.Select(r => new
            {
                r.Id,
                UserName = r.User.Username,
                r.Rating,
                r.Review,
                r.CreatedAt
            });

            return Ok(result);
        }

        // 2. GET: api/CarReview/AverageRating/{carId} - Get average rating of a car
        [HttpGet("AverageRating/{carId}")]
        public async Task<IActionResult> GetAverageRating(int carId)
        {
            var ratings = await _context.CarReviews
                .Where(r => r.CarId == carId)
                .Select(r => r.Rating)
                .ToListAsync();

            if (!ratings.Any())
                return Ok(new { AverageRating = 0 });

            double averageRating = ratings.Average();
            return Ok(new { AverageRating = Math.Round(averageRating, 1) });
        }

        // 3. POST: api/CarReview - Add a new review (Only booked users can review)
       
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] CarReview model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var hasBooked = await _context.Bookings.AnyAsync(b =>
                b.Id == model.Id && b.Status == "Completed");
            var dataBook = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == model.Id);
            
            if (!hasBooked)
                return BadRequest("You can only review cars you have booked and completed.");

            
            var existingReview = await _context.CarReviews.FirstOrDefaultAsync(r =>
                r.UserId == dataBook.UserId && r.CarId == dataBook.CarId);
            Console.WriteLine(existingReview);
            if (existingReview != null)
                return BadRequest("You have already reviewed this car.");
            // Save the review using UserId and CarId from booking
            var newReview = new CarReview
            {
                UserId = dataBook.UserId,
                CarId = dataBook.CarId,
                Rating = model.Rating,
                Review = model.Review,
                CreatedAt = DateTime.UtcNow
            };
            _context.CarReviews.Add(newReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewsByCar), new { carId = dataBook.CarId }, newReview);
        }

        // 4. PUT: api/CarReview/{id} - Edit an existing review (Only the user who posted can edit)

        [HttpPut("{id}")]
        public async Task<IActionResult> EditReview(int id, [FromBody] CarReview model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = await _context.CarReviews.FindAsync(id);

            if (review == null)
                return NotFound("Review not found.");

            // User validation without Authorize
            if (review.UserId != model.UserId) // Use UserId from request body
                return Forbid("You are not allowed to edit this review.");

            review.Rating = model.Rating;
            review.Review = model.Review;
            review.CreatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(review);
        }


        // 5. DELETE: api/CarReview/{id} - Delete a review (Only the user who posted or admin can delete)

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id, [FromBody] CarReview model)
        {
            var review = await _context.CarReviews.FindAsync(id);

            if (review == null)
                return NotFound("Review not found.");

            // User validation without Authorize
            if (review.UserId != model.UserId) // Use UserId from request body
                return Forbid("You are not allowed to delete this review.");

            _context.CarReviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
