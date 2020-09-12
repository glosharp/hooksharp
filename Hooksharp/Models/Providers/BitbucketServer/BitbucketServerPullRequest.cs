using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPullRequest
    {
        [JsonProperty("id")]
        public int Id; 

        [JsonProperty("version")]
        public int Version; 

        [JsonProperty("title")]
        public string Title; 

        [JsonProperty("state")]
        public string State; 

        [JsonProperty("open")]
        public bool Open; 

        [JsonProperty("closed")]
        public bool Closed; 

        [JsonProperty("createdDate")]
        public long CreatedDate; 

        [JsonProperty("updatedDate")]
        public long UpdatedDate; 

        [JsonProperty("fromRef")]
        public BitbucketServerRef FromRef; 

        [JsonProperty("toRef")]
        public BitbucketServerRef ToRef; 

        [JsonProperty("locked")]
        public bool Locked; 

        [JsonProperty("author")]
        public BitbucketServerAuthor Author; 

        [JsonProperty("reviewers")]
        public List<BitbucketServerAuthor> Reviewers; 

        [JsonProperty("participants")]
        public List<BitbucketServerAuthor> Participants; 

        [JsonProperty("links")]
        public BitbucketServerLinks Links;

        [JsonProperty("comment")]
        public BitbucketServerComment Comment;

        [JsonProperty("commentParentId")]
        public int CommentParentId;

        [JsonProperty("previousComment")]
        public string PreviousComment;
    }
}