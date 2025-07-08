using backend.Data;
using backend.Models;
using backend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    //  Get logged-in user's profile
    [HttpPost("profile")]
    public async Task<IActionResult> GetUserProfile([FromBody] ProfileRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Username))
        {
            return BadRequest(new { message = "Invalid request data" });
        }

        // Simulate fetching user details from the database
        var userProfile = new
        {
            username = request.Username,
            role = request.Role, // Sent from frontend
            email = request.Email,
            createdAt = request.CreatedAt,
            message = "Success"
        };

        return Ok(userProfile);
    }

    [HttpGet("getUserByUsername")]
    public async Task<IActionResult> GetUserByUsername([FromQuery] string request)
    {
        if (string.IsNullOrEmpty(request))
        {
            return BadRequest(new { message = "Invalid request data" });
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new { userId = user.Id, username = user.Username, role = user.Role });
    }

    [HttpPost("getusername")]
    public async Task<IActionResult> GetUsername([FromBody] UsernameRequest request)
    {
        if (string.IsNullOrEmpty(request.Username))
        {
            return BadRequest(new { message = "Invalid request data" });
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new { userId = user.Id, username = user.Username, role = user.Role, email = user.Email, createdAt = user.DateCreated });
    }

    [HttpGet("getUserByUserId")]
    public async Task<IActionResult> GetUserByUserId([FromQuery] int userId)
    {
        if (userId <= 0)
        {
            return BadRequest(new { message = "Invalid userId" });
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new { username = user.Username });
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users
            .Select(u => new
            {
                u.Id,
                u.Email,
                u.Username,
                u.Role,
                u.Report,
                u.DateCreated
            })
            .ToListAsync();

        return Ok(users);
    }
    [HttpGet("count")]
    public async Task<IActionResult> GetUserCount()
    {
        var userCount = await _context.Users.CountAsync();
        return Ok(new { count = userCount });
    }
    [HttpGet("unblockcount")]
    public async Task<IActionResult> GetUserUnblockCount()
    {
        var userCount = await _context.Users.Where(u => u.Report == false).CountAsync();
        return Ok(new { count = userCount });
    }
    [HttpPost("block-unblock/{id}")]
    public async Task<IActionResult> BlockUnblockUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        user.Report = !user.Report; // Toggle block status
        await _context.SaveChangesAsync();

        string status = user.Report ? "blocked" : "unblocked";
        return Ok(new { message = $"User {status} successfully.", Report = user.Report });
    }


}
public class ProfileRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime? CreatedAt { get; set; }
}
public class ProfileId
{
    public int Id { get; set; }
}
public class UsernameRequest
{
    public string Username { get; set; }
}

