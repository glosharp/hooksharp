using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerRef
    {
        [JsonProperty("id")]
        public string Id; 

        [JsonProperty("displayId")]
        public string DisplayId; 

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("latestCommit")]
        public string LatestCommit;

        [JsonProperty("repository")]
        public BitbucketServerRepository Repository;
    }
}