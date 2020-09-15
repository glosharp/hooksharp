using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerChange
    {
        [JsonProperty("ref")]
        public BitbucketServerRef Ref; 

        [JsonProperty("refId")]
        public string RefId; 

        [JsonProperty("fromHash")]
        public string FromHash; 

        [JsonProperty("toHash")]
        public string ToHash; 

        [JsonProperty("type")]
        public string Type; 
    }
}