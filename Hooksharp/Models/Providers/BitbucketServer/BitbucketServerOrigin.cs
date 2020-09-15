using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerOrigin
    {
        [JsonProperty("slug")]
        public string Slug; 

        [JsonProperty("id")]
        public int Id; 

        [JsonProperty("name")]
        public string Name; 

        [JsonProperty("scmId")]
        public string ScmId; 

        [JsonProperty("state")]
        public string State; 

        [JsonProperty("statusMessage")]
        public string StatusMessage; 

        [JsonProperty("forkable")]
        public bool Forkable; 

        [JsonProperty("project")]
        public BitbucketServerProject Project; 

        [JsonProperty("public")]
        public bool Public; 
    }
}