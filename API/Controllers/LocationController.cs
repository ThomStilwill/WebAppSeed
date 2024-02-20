using System.Collections.Generic;
using System.Threading.Tasks;
using API.Orchestrators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationOrchestrator orchestrator;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger, ILocationOrchestrator orchestrator)
        {
            this.orchestrator = orchestrator;
            _logger = logger;
        }

        [HttpGet(Name = "GetStatesByRegion/{region}")]
        public async Task<IEnumerable<string>> Get(string region = null)
        {
            return await orchestrator.GetStatesByRegion(region);
        }
    }
}
