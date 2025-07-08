using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;

namespace backend.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CarController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            return await _context.Cars
                .Include(c => c.CarDetails)
                .Select(car => new Car
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year,
                    Color = car.Color,
                    RentalPricePerDay = car.RentalPricePerDay,
                    IsAvailable = car.IsAvailable,
                    Picture = car.Picture != null ? $"{baseUrl}{car.Picture}" : null,
                    CarDetails = car.CarDetails != null ? new CarDetails
                    {
                        Id = car.CarDetails.Id,
                        Category = car.CarDetails.Category,
                        Mileage = car.CarDetails.Mileage,
                        Transmission = car.CarDetails.Transmission,
                        FuelType = car.CarDetails.FuelType,
                        SeatingCapacity = car.CarDetails.SeatingCapacity,
                        DiscountPercentage = car.CarDetails.DiscountPercentage
                    } : null
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound(new { message = "Car not found" });
            var carDetails = await _context.CarDetails.AsNoTracking().FirstOrDefaultAsync(cd => cd.CarId == id);
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            car.Picture = car.Picture != null ? $"{baseUrl}{car.Picture}" : null; //  FIXED
                                                                                  // Manually assign car details if available
            if (carDetails != null)
            {
                car.CarDetails = new CarDetails
                {
                    Category = carDetails.Category,
                    Mileage = carDetails.Mileage,
                    Transmission = carDetails.Transmission,
                    FuelType = carDetails.FuelType,
                    SeatingCapacity = carDetails.SeatingCapacity,
                    DiscountPercentage = carDetails.DiscountPercentage
                };
            }
            return car;
        }
        [HttpGet("getcars/{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound(new { message = "Car not found" });

            var carDetails = await _context.CarDetails.AsNoTracking().FirstOrDefaultAsync(cd => cd.CarId == id);
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            car.Picture = car.Picture != null ? $"{baseUrl}{car.Picture}" : null;
            // Manually assign car details if available
            if (carDetails != null)
            {
                car.CarDetails = new CarDetails
                {
                    Category = carDetails.Category,
                    Mileage = carDetails.Mileage,
                    Transmission = carDetails.Transmission,
                    FuelType = carDetails.FuelType,
                    SeatingCapacity = carDetails.SeatingCapacity,
                    DiscountPercentage = carDetails.DiscountPercentage
                };
            }
            return car;
        }

        // POST: api/car - Add a new car (Admin Only)
        [HttpPost]
        public async Task<IActionResult> AddCar()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("❌ ModelState is invalid!");
                    return BadRequest(new { message = "Validation failed", errors = ModelState });
                }

                Console.WriteLine("✅ ModelState is valid");

                var form = Request.Form;
                Console.WriteLine("Received form data:");
                foreach (var key in form.Keys)
                {
                    Console.WriteLine($"{key}: {form[key]}");
                }

                var file = Request.Form.Files["imageFile"];
                if (file == null || file.Length == 0)
                {
                    Console.WriteLine("❌ Image file is missing!");
                    return BadRequest(new { message = "Image file is required." });
                }

                Console.WriteLine($"✅ Image file received: {file.FileName}");

                // Save the image file
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                Console.WriteLine($"✅ Image saved at {filePath}");

                // Create a new Car object
                var car = new Car
                {
                      Make = form["Make"],
                       Model = form["Model"],
                       Year = int.Parse(form["Year"]),
                       Color = form["Color"],
                       RentalPricePerDay = decimal.Parse(form["RentalPricePerDay"]),
                       IsAvailable = bool.Parse(form["IsAvailable"]),
                       Picture = $"/pictures/{uniqueFileName}",
                       CarDetails = new CarDetails
                       {
                           Category = form["Category"],
                           Mileage = int.Parse(form["Mileage"]),
                           Transmission = form["Transmission"],
                           FuelType = form["FuelType"],
                           SeatingCapacity = int.Parse(form["SeatingCapacity"]),
                           DiscountPercentage = form.ContainsKey("DiscountPercentage") && !string.IsNullOrEmpty(form["DiscountPercentage"])
                               ? int.Parse(form["DiscountPercentage"]) : (int?)null
                       }

                };


                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                Console.WriteLine($"✅ Car added: {car.Make} {car.Model}");

                return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("❌ ModelState is invalid!");
                    return BadRequest(new { message = "Validation failed", errors = ModelState });
                }

                Console.WriteLine("✅ ModelState is valid");

                var existingCar = await _context.Cars.FindAsync(id);
                // Ensure EF tracks existing CarDetails correctly
                var existingCarDetails = await _context.CarDetails.FirstOrDefaultAsync(cd => cd.CarId == id);
                if (existingCarDetails == null)
                {
                    existingCar.CarDetails = new CarDetails();
                }
                else
                {
                    existingCar.CarDetails = existingCarDetails; // Attach existing CarDetails to avoid duplication
                }

                var form = Request.Form;
                Console.WriteLine("Received form data:");
                foreach (var key in form.Keys)
                {
                    Console.WriteLine($"{key}: {form[key]}");
                }

                // Update fields
                existingCar.Make = form["Make"];
                existingCar.Model = form["Model"];
                existingCar.Year = int.Parse(form["Year"]);
                existingCar.Color = form["Color"];
                existingCar.RentalPricePerDay = decimal.Parse(form["RentalPricePerDay"]);
                existingCar.IsAvailable = bool.Parse(form["IsAvailable"]);
                // Update CarDetails
                if (existingCar.CarDetails == null)
                    existingCar.CarDetails = new CarDetails();

                existingCar.CarDetails.Category = form["Category"];
                existingCar.CarDetails.Mileage = int.Parse(form["Mileage"]);
                existingCar.CarDetails.Transmission = form["Transmission"];
                existingCar.CarDetails.FuelType = form["FuelType"];
                existingCar.CarDetails.SeatingCapacity = int.Parse(form["SeatingCapacity"]);
                existingCar.CarDetails.DiscountPercentage = form.ContainsKey("DiscountPercentage") && !string.IsNullOrEmpty(form["DiscountPercentage"])
                    ? int.Parse(form["DiscountPercentage"]) : (int?)null;


                var file = Request.Form.Files["imageFile"];
                if (file != null && file.Length > 0)
                {
                    Console.WriteLine($"✅ New Image file received: {file.FileName}");

                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures");
                    Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                    string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    Console.WriteLine($"✅ Image saved at {filePath}");

                    // Update picture path
                    existingCar.Picture = $"/pictures/{uniqueFileName}";
                }
                else
                {
                    Console.WriteLine("⚠️ No new image uploaded, keeping existing image.");
                }
                
                await _context.SaveChangesAsync();
                Console.WriteLine($"✅ Car updated: {existingCar.Make} {existingCar.Model}");

                return Ok(new { message = "Car updated successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }


        // DELETE: api/car/{id} - Delete a car (Admin Only)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound(new { message = "Car not found" });

            // Delete the image if exists
            if (!string.IsNullOrEmpty(car.Picture))
            {
                string filePath = Path.Combine(_env.WebRootPath, car.Picture.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCarCount()
        {
            var userCount = await _context.Cars.CountAsync();
            return Ok(new { count = userCount });
        }
        [HttpGet("avalcount")]
        public async Task<IActionResult> GetCarAvalCount()
        {
            var userCount = await _context.Cars.Where(c => c.IsAvailable == true).CountAsync();
            return Ok(new { count = userCount });
        }
    }
}
