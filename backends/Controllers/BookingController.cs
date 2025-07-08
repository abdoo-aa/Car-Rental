using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

[Route("api/booking")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    // Get bookings for a specific user
    [HttpPost("user")]
    public async Task<IActionResult> GetUserBookings([FromBody] ProfileRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Username))
            return BadRequest(new { message = "Invalid request data" });

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null)
            return NotFound(new { message = "User not found" });

        var bookings = await _context.Bookings
            .Where(b => b.UserId == user.Id)
            .Include(b => b.Car)
            .Select(b => new
            {
                b.Id,
                b.CarId,
                CarName = b.Car.Make + " " + b.Car.Model,
                b.BookingDate,
                b.Status,
                b.Price,
                b.ApprovedAt,
                b.StartDate,
                b.EndDate
            })
            .ToListAsync();

        return Ok(bookings);
    }

    // Admin - Get all bookings
    [HttpGet("all")]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Car)
            .Select(b => new
            {
                b.Id,
                b.UserId,
                Username = b.User.Username,
                CarName = b.Car.Make + " " + b.Car.Model,
                b.BookingDate,
                b.Status,
                b.Price,
                b.ApprovedAt,
                b.StartDate,
                b.EndDate
            })
            .ToListAsync();

        return Ok(bookings);
    }
    [HttpPost("confirmbooking")]
    public async Task<IActionResult> ConfirmBooking([FromBody] BookingRequest request)
    {
        if (request == null || request.CarId <= 0 || request.UserId <= 0)
            return BadRequest(new { message = "Invalid booking request" });

        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == request.CarId);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (car == null) return NotFound(new { message = "Car not found" });
        if (user == null) return NotFound(new { message = "User not found" });

        if (!car.IsAvailable) return BadRequest(new { message = "Car is already booked" });

        // Save booking details
        var newBooking = new Booking
        {
            UserId = request.UserId,
            CarId = request.CarId,
            BookingDate = DateTime.UtcNow,
            Status = "Pending",
            Price = request.Price,
            StartDate = request.StartDate, // New
            EndDate = request.EndDate      // New
        };

        _context.Bookings.Add(newBooking);
        car.IsAvailable = false; // Mark car as unavailable
        await _context.SaveChangesAsync();

        return Ok(new { message = "Booking successful!", bookingId = newBooking.Id });
    }
    [HttpGet("total")]
    public async Task<IActionResult> GetTotalBookings()
    {
        var totalBookings = await _context.Bookings.CountAsync();
        return Ok(totalBookings);
    }
    [HttpGet("totaluserbooking/{username}")]
    public async Task<IActionResult> GetUserCountBookings(string username)
    {
        if (string.IsNullOrEmpty(username))
            return BadRequest(new { message = "Username is required" });

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            return NotFound(new { message = "User not found" });

        var countBookings = await _context.Bookings
            .Where(b => b.UserId == user.Id)
            .CountAsync();

        return Ok(countBookings);
    }
    // approve booking
    [HttpPut("approve/{id}")]
    public async Task<IActionResult> ApproveBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return NotFound(new { message = "Booking not found!" });

        if (booking.Status == "Approved")
        {
            return BadRequest(new { message = "Booking is already approved!" });
        }

        booking.Status = "Approved";
        booking.ApprovedAt = DateTime.UtcNow; // Set approval time
        await _context.SaveChangesAsync();

        return Ok(new { message = "Booking approved successfully!" });
    }

    // Reject Booking (Admin)
    [HttpPut("reject/{id}")]
    public async Task<IActionResult> RejectBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Car) // Include Car details
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null) return NotFound(new { message = "Booking not found!" });

        if (booking.Status == "Rejected")
        {
            return BadRequest(new { message = "Cannot reject a Rejected booking!" });
        }

        booking.Status = "Rejected";
        booking.Car.IsAvailable = true; // Make the car available again

        await _context.SaveChangesAsync();
        return Ok(new { message = " Booking Rejected & amount refunded!" });
    }

    // Cancel Booking (User)
    [HttpPut("cancel/{id}")]
    public async Task<IActionResult> CancelBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Car) // Include Car details
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null) return NotFound(new { message = "Booking not found!" });

        if (booking.Status == "Completed")
        {
            return BadRequest(new { message = "Cannot cancel a completed booking!" });
        }

        booking.Status = "Canceled";
        booking.Car.IsAvailable = true; // Make the car available again

        await _context.SaveChangesAsync();
        return Ok(new { message = " Booking canceled & amount refunded!" });
    }
    [HttpGet("cancelledBookings/{username}")]
    public async Task<IActionResult> GetUserCancelledBookingsCount(string username)
    {
        if (string.IsNullOrEmpty(username))
            return BadRequest(new { message = "Invalid username!" });

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            return NotFound(new { message = "User not found!" });

        int cancelledCount = await _context.Bookings
            .Where(b => b.UserId == user.Id && b.Status == "Canceled")
            .CountAsync();

        return Ok(cancelledCount);
    }
    [HttpGet("pendingBookings")]
    public async Task<IActionResult> GetPendingBookingsCount()
    {

        int pendingCount = await _context.Bookings
            .Where(b => b.Status == "Pending")
            .CountAsync();

        return Ok(pendingCount);
    }
    

    [HttpPut("return/{id}")]
    public async Task<IActionResult> ReturnCar(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Car) // Include Car details
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null) return NotFound(new { message = "Booking not found!" });

        // Update the status to 'Completed'
        booking.Status = "Completed";
        booking.Car.IsAvailable = true;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Car returned successfully and booking marked as completed." });
    }


}
public class BookingRequest
{
    public int UserId { get; set; }
    public int CarId { get; set; }
    public decimal Price { get; set; }
    public DateTime? StartDate { get; set; } // New
    public DateTime? EndDate { get; set; }   // New
}