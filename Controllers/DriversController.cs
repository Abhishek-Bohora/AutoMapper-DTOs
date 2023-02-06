using MapperApp.Models;
using MapperApp.Models.DTOs.Incoming;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private static List<Driver> drivers = new List<Driver>();

        [HttpGet]
        public IActionResult GetDrivers()
        {
            var allDrivers = drivers.Where(x => x.Status == 1).ToList();
            return Ok(allDrivers);
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverForCreationDto data) 
         //Instead of using our Driver model which is the table of our database we use Dto.
         //in this case DriverCreationDto

        {
            if (ModelState.IsValid)
            {
                var _driver = new Driver() {
                    // we have created a _driver object and manually mapped from the incoming Dto
                    Id = new Guid(),
                    DateAdded= DateTime.Now,
                    DateUpdated= DateTime.Now,
                    Status = 1,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    DriverNumber = data.DriverNumber,
                    WorldChampionships = data.WorldChampionships
                };
                drivers.Add(_driver);
                return CreatedAtAction("GetDriver", new { _driver.Id }, _driver);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public IActionResult GetDriver(Guid id)
        {
            var driver = drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDriver(Guid id, Driver data) {
            if (id == data.Id)
            {
                return BadRequest();
            }

            var existingDriver = drivers.FirstOrDefault(x => x.Id == data.Id);
            if (existingDriver == null) {
                return NotFound();
            }

            existingDriver.DriverNumber = data.DriverNumber;
            existingDriver.FirstName = data.FirstName;
            existingDriver.LastName = data.LastName;
            existingDriver.WorldChampionships = data.WorldChampionships;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {
            var existingDriver = drivers.FirstOrDefault(x =>x.Id == id);
            if (existingDriver == null)
            {
                return NotFound();
            }
            existingDriver.Status = 0;
            return NoContent();
        }
    }
}
