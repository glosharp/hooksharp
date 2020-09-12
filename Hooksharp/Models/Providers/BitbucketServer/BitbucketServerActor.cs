using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerActor
    {
        [JsonProperty("name")]
        public string Name; 

        [JsonProperty("emailAddress")]
        public string EmailAddress; 

        [JsonProperty("id")]
        public int Id; 

        [JsonProperty("displayName")]
        public string DisplayName; 

        [JsonProperty("active")]
        public bool Active; 

        [JsonProperty("slug")]
        public string Slug; 

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("links")]
        public BitbucketServerLinks Links;
    }
}