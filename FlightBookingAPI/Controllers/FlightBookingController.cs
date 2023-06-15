using FlightBookingAPI.Data;
using FlightBookingAPI.RequestObjects;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{

    [ApiController]
    [Route("api/FlightController")]
    public class FlightBookingController : ControllerBase
    {
        private readonly FlightDbContext _dbContext;

        public FlightBookingController(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("/flight/book")]
        public async Task<IActionResult> BookFlight(FlightBookingRequest req)
        {
            Guid random = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                FlightBookingModel flightBookingModel = new FlightBookingModel
                {
                    Id = random.ToString(),
                    date = req.date,
                    passengerName = req.passengerName,
                    seat = req.Seat
                };
                _dbContext.Add(flightBookingModel);
                _dbContext.SaveChanges();

                WriteRequest();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private void WriteRequest()
        {
            Console.WriteLine("amount of bookings: " + _dbContext.FlightBookings.ToList().Count.ToString());
        }
    }
}

