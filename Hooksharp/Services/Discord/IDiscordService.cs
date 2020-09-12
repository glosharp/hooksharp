using System.Net;
using System.Threading.Tasks;

namespace Hooksharp.Services.Discord
{
    public interface IDiscordService
    {
        Task<HttpStatusCode> PostWebhook(string payload, string webhookId, string webhookToken);
    }
}