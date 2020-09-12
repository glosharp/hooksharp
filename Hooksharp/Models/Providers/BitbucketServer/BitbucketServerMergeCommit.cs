using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerMergeCommit
    {
        [JsonProperty("displayId")]
        public string DisplayId;

        [JsonProperty("id")]
        public string Id;
    }
}