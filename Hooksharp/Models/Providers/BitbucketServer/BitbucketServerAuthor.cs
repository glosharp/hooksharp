using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerAuthor
    {
        [JsonProperty("user")]
        public BitbucketServerActor User;

        [JsonProperty("lastReviewedCommit")]
        public string LastReviewedCommit;

        [JsonProperty("role")]
        public string Role; 

        [JsonProperty("approved")]
        public bool Approved; 

        [JsonProperty("status")]
        public string Status; 
    }
}