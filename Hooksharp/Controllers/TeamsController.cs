using System.Threading.Tasks;
using Hooksharp.Handlers.Teams;
using Hooksharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Controllers
{
    [ApiController]
    [Route("webhooks/teams")]
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        private TeamsService _teamsService;
        public TeamsController(ILogger<TeamsController> logger, TeamsService teamsService)
        {
            _logger = logger;
            _teamsService = teamsService;
        }

        [HttpPost("bitbucket-server/{client}@{tenant}/IncomingWebhook/{webhookId}/{secret}")]
        public async Task<ActionResult> BitbucketServer(string client, string tenant, string webhookId, string secret, 
            [FromBody] JObject hook)
        {
            HttpContext.Request.Headers.TryGetValue("X-Event-Key", out var eventKey);
            
            _logger.LogInformation($"{nameof(TeamsController)} >>> {nameof(BitbucketServer)} >>> {eventKey}");

            if (string.IsNullOrEmpty(eventKey))
            {
                return BadRequest(new {message = "X-Event-Key header is missing."});
            }
            
            var handler = new TeamsBitbucketServerHandler();
            var body = await handler.GetPayload(hook, eventKey);

            var result = await _teamsService.PostWebhook(body, client, tenant, webhookId, secret);

            return StatusCode((int) result);

        }
    }
}