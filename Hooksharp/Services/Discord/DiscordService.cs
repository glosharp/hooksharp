using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace Hooksharp.Services.Discord
{
    public class DiscordService : IDiscordService
    {
        private readonly RestClient _restClient;
        public DiscordService(string discordUrl = "https://discordapp.com/api/webhooks/")
        {
            _restClient = new RestClient(discordUrl);
        }
        
        public async Task<HttpStatusCode> PostWebhook(string payload, string webhookId, string webhookToken)
        {
            var request = new RestRequest($"{webhookId}/{webhookToken}");
            request.AddJsonBody(payload);
            
            var response = await _restClient.ExecutePostAsync(request);
            return response.StatusCode;
        }
    }
}