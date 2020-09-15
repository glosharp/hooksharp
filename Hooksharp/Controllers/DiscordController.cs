using System.Threading.Tasks;
using Hooksharp.Handlers.Discord;
using Hooksharp.Services.Discord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Controllers
{
    [ApiController]
    [Route("webhooks/discord")]
    public class DiscordController : ControllerBase
    {
        private readonly ILogger<DiscordController> _logger;
        private DiscordService DiscordService;

        public DiscordController(ILogger<DiscordController> logger, DiscordService discordService)
        {
            _logger = logger;
            DiscordService = discordService;
        }
        
        [HttpPost("bitbucket-server/{webhookId}/{webhookToken}")]
        public async Task<ActionResult> BitbucketServer(string webhookId, string webhookToken, [FromBody] JObject hook)
        {
            HttpContext.Request.Headers.TryGetValue("X-Event-Key", out var eventKey);
            
            _logger.LogInformation($"{nameof(DiscordController)} >>> {nameof(BitbucketServer)} >>> {eventKey}");

            if (string.IsNullOrEmpty(eventKey))
            {
                return BadRequest(new {message = "X-Event-Key header is missing."});
            }

            var handler = new DiscordBitbucketServerHandler();
            var body = await handler.GetPayload(hook, eventKey);

            var result = await DiscordService.PostWebhook(body, webhookId, webhookToken);

            return StatusCode((int) result);
        }
    }
}