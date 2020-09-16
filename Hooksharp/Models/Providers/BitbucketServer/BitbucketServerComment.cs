using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerComment
    {
        [JsonProperty("properties")]
        public BitbucketServerProperties Properties; 

        [JsonProperty("id")]
        public int Id; 

        [JsonProperty("version")]
        public int Version; 

        [JsonProperty("text")]
        public string Text; 

        [JsonProperty("author")]
        public BitbucketServerActor Author; 

        [JsonProperty("createdDate")]
        public long CreatedDate; 

        [JsonProperty("updatedDate")]
        public long UpdatedDate; 

        [JsonProperty("comments")]
        public List<object> Comments; 

        [JsonProperty("tasks")]
        public List<object> Tasks; 

        [JsonProperty("permittedOperations")]
        public BitbucketServerPermittedOperations PermittedOperations; 
    }
}