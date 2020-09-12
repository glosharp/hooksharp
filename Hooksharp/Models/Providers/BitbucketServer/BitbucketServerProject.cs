using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerProject
    {
        [JsonProperty("key")]
        public string Key; 

        [JsonProperty("id")]
        public int Id; 

        [JsonProperty("name")]
        public string Name; 

        [JsonProperty("public")]
        public bool Public; 

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("owner")]
        public BitbucketServerActor Owner;
    }
}