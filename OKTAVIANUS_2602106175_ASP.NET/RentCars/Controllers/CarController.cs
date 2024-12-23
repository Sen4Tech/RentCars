using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCars.Data;
using RentCars.Models;
using RentCars.Models.Request;
using RentCars.Models.Result;

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext db;

        public CarController(AppDbContext database)
        {
            db = database;
        }

      [HttpGet]
public async Task<IActionResult> GetCar()
{
    try
    {
        var cars = await db.Car
            .Include(c => c.CarImages)
            .Select(c => new
            {
                id = c.Car_id,
                name = c.name,
                price_per_day = c.price_per_day,
                image_link = c.CarImages.FirstOrDefault().image_link,
                year = c.year,
            })
            .ToListAsync();
        return Ok(new { statusCode = 200, data = cars });
    }
    catch (Exception ex)
    {
        return BadRequest(new { statusCode = 400, message = ex.Message });
    }
}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCarRequest request)
        {
            try
            {
                var isCarExists = await db.Rental.Where(x => x.Rental_id == request.Rental_id).AnyAsync();
                if(isCarExists){
                    throw new ArgumentException("Car is already exists");
                }

                var isDataExists = await db.Car.Where(x => x.Car_id == request.Rental_id).AnyAsync();
                if(!isDataExists){
                    throw new KeyNotFoundException("Car data not found");
                }

                var topCarId = await db.Car
                .OrderByDescending(x => x.Car_id)
                .Include(x => x.Rentals)
                .Select(x => x.Car_id)
                .FirstOrDefaultAsync();

                var substringId = topCarId?.Substring(2);

                var currentId = int.Parse(substringId);

                currentId += 1;

                var DataNew = currentId.ToString("D3");

                var CarData = new TrRental{
                    Rental_id = $"ST{DataNew}",
                    rental_date = request.Rental_date,
                    return_date = request.Return_date,
                };

                db.Rental.Add(CarData);
                await db.SaveChangesAsync();

                var response = new ApiResponse<string>{
                    StatusCode = StatusCodes.Status201Created,
                    RequestMethod = HttpContext.Request.Method,
                    Data = "Car data saved successfully"
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                var response = new ApiResponse<string>{
                    StatusCode = StatusCodes.Status400BadRequest,
                    RequestMethod = HttpContext.Request.Method,
                    Data = ex.Message
                };
                return BadRequest(response);
            }

        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarResultById>> GetCar(string id)
        {
            var CarData = await db.Car
            .Include(x => x.Rentals)
            .Where(x => x.Car_id == id)
            .Select(x => new GetCarResultById
            {
                car_id = x.Car_id,
                Model = x.model,
                Name = x.name,
                Transmission = x.transmission,
                Number_of_car_seats = x.number_of_car_seats,
            })
            .FirstOrDefaultAsync();

            var response = new ApiResponse<GetCarResultById>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Data = CarData
            };

            return Ok(response);
        }
    }
}
