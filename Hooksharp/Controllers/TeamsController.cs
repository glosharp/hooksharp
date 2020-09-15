using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hooksharp.Controllers
{
    [ApiController]
    [Route("webhooks/teams")]
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        
        public TeamsController(ILogger<TeamsController> logger)
        {
            _logger = logger;
        }

        
        public async Task<ActionResult> BitbucketServer()
        {
            HttpContext.Request.Headers.TryGetValue("X-Event-Key", out var eventKey);
            
            _logger.LogInformation($"{nameof(TeamsController)} >>> {nameof(BitbucketServer)} >>> {eventKey}");

            if (string.IsNullOrEmpty(eventKey))
            {
                return BadRequest(new {message = "X-Event-Key header is missing."});
            }

            return Ok();

        }
    }
}