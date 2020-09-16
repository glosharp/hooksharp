using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerClone
    {
        [JsonProperty("href")]
        public string Href; 

        [JsonProperty("name")]
        public string Name;
    }
}