using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerMirrorServer
    {
        [JsonProperty("id")]
        public string Id; 

        [JsonProperty("name")]
        public string Name; 
    }
}