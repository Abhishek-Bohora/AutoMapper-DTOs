using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
    }
}
