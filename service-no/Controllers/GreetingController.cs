using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace service_nl.Controllers
{
    [ApiController]
    [Route("greeting")]
    public class GreetingController : ControllerBase
    {
        private readonly ILogger<GreetingController> _logger;

        public GreetingController(ILogger<GreetingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Greet()
        {
            return "Hei, alle fra ITUMX !";
        }
    }
}
