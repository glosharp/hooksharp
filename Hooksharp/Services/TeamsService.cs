using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using RestSharp;

namespace Hooksharp.Services
{
    public class TeamsService
    {
        private readonly RestClient _restClient;

        public TeamsService(string teamsUrl = "https://outlook.office.com/webhook/")
        {
            _restClient = new RestClient(teamsUrl);
        }
        
        public async Task<HttpStatusCode> PostWebhook(string payload, string client, string tenant, string webhookId, string secret)
        {
            var request = new RestRequest($"{client}@{tenant}/IncomingWebhook/{webhookId}/{secret}");
            request.AddJsonBody(payload);

            var response = await _restClient.ExecutePostAsync(request);

            return response.StatusCode;
        }
    }
}