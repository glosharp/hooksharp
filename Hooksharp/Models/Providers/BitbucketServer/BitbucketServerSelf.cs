using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerSelf
    {
        [JsonProperty("href")]
        public string Href;
    }
}