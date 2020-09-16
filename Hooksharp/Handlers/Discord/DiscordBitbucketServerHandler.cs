using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hooksharp.Models.Discord;
using Hooksharp.Models.Providers.BitbucketServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Handlers.Discord
{
    public class DiscordBitbucketServerHandler : DiscordBaseHandler
    {
        private readonly Embed _embed;

        public DiscordBitbucketServerHandler()
        {
            SetEmbedColor(0x205081);
            _embed = new Embed();    
        }

        public override string GetName()
        {
            return "Bitbucket Server";
        }
        
        public async Task<string> GetPayload(JObject raw, string eventKey)
        {
            await ParseData(raw, eventKey);
            return Parse();
        }

        private Task ParseData(JObject raw, string eventKey)
        {
            
            switch (eventKey)
            {
                case "diagnostics:ping":
                    DiagnosticsPing();
                    break;
                
                case "repo:refs_changed":
                    var repoChangedObject =
                        JsonConvert.DeserializeObject<BitbucketServerPayloadRefsChanged>(raw.ToString());
                    RepoRefsChanged(repoChangedObject);
                    break;

                case "repo:forked":
                    RepoForked();
                    break;
                
                case "repo:comment:added":
                    var repoCommentAdded = JsonConvert.DeserializeObject<BitbucketServerPayloadComment>(raw.ToString());
                    RepoCommentAdded(repoCommentAdded);
                    break;
                    
                case "repo:comment:edited":
                    var repoCommentEdit = JsonConvert.DeserializeObject<BitbucketServerPayloadComment>(raw.ToString());
                    RepoCommentEdited(repoCommentEdit);
                    break;
                
                case "repo:comment:deleted":
                    var repoCommentDelete = JsonConvert.DeserializeObject<BitbucketServerPayloadComment>(raw.ToString());
                    RepoCommentDeleted(repoCommentDelete);
                    break;
                
                case "mirror:repo_synchronized":
                    var repoSync = JsonConvert.DeserializeObject<BitbucketServerPayloadMirrorSync>(raw.ToString());
                    MirrorRepoSynchronized(repoSync);
                    break;
                
                case "pr:opened":
                    var prOpen = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrOpened(prOpen);
                    break;
                
                case "pr:from_ref_updated":
                    var prRefUpdate = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrFromRefUpdated(prRefUpdate);
                    break;
                
                case "pr:modified":
                    var prModified = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrModified(prModified);
                    break;
                
                case "pr:reviewer:updated":
                    var prReviewerModified = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrReviewerUpdated(prReviewerModified);
                    break;
                
                case "pr:reviewer:approved":
                    var prReviewerApproved = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrReviewerApproved(prReviewerApproved);
                    break;
                    
                case "pr:reviewer:unapproved":
                    var prReviewerUnapproved = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrReviewerUnapproved(prReviewerUnapproved);
                    break;
                
                case "pr:reviewer:needs_work":
                    var prNeedsWork = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrReviewerNeedsWork(prNeedsWork);
                    break;
                
                case "pr:merged":
                    var prMerged = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrMerged(prMerged);
                    break;
                
                case "pr:declined":
                    var prDeclined = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrDeclined(prDeclined);
                    break;
                
                case "pr:deleted":
                    var prDeleted = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrDeleted(prDeleted);
                    break;
                
                case "pr:comment:added":
                    var prCommentAdd = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrCommentAdded(prCommentAdd);
                    break;
                
                case "pr:comment:edited":
                    var prCommentEdit = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrCommentEdited(prCommentEdit);
                    break;
                
                case "pr:comment:deleted":
                    var prCommentDelete = JsonConvert.DeserializeObject<BitbucketServerPayloadPullRequest>(raw.ToString());
                    PrCommentDeleted(prCommentDelete);
                    break;
            }
            
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// Handles the Diagnostic Pings for Connection Testing.
        /// </summary>
        private void DiagnosticsPing()
        {
            _embed.Title = "Hooksharp, a Discord Parsing Engine";
            _embed.Description = "You have successfully configured Hooksharp with your Bitbucket Server Instance! " +
                                 "Happy Coding!";
            
            AddEmbed(_embed);
        }

        /// <summary>
        /// Handle New Commit Pushes
        /// </summary>
        /// <param name="payload"></param>
        private void RepoRefsChanged(BitbucketServerPayloadRefsChanged payload)
        {
            _embed.Author = ExtractAuthor(payload.Actor, payload.Repository);
            _embed.Title = "New Commit has been pushed";
            _embed.Url = ExtractCommitCommentUrl(payload);
            _embed.Description = $"**Branch**: {payload.Changes[0].Ref.Id}";
            _embed.Fields = ExtractRepoChangesField(payload.Changes);
            AddEmbed(_embed);
            
        }

        private void RepoForked()
        {
            _embed.Author = new EmbedAuthor
            {
                Name = "Hooksharp"
            };
            _embed.Title = "A new [`fork`] has been created.";
            
            AddEmbed(_embed);
        }

        private void RepoCommentAdded(BitbucketServerPayloadComment comment)
        {
            FormatCommitCommentPayload("New comment on commit", comment);
            AddEmbed(_embed);
        }

        private void RepoCommentEdited(BitbucketServerPayloadComment comment)
        {
            FormatCommitCommentPayload("Comment edited on commit", comment);
            AddEmbed(_embed);
        }

        private void RepoCommentDeleted(BitbucketServerPayloadComment comment)
        {
            FormatCommitCommentPayload("Comment deleted on commit", comment);
            AddEmbed(_embed);
        }

        private void PrOpened(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request opened", payload);
            AddEmbed(_embed);
        }

        private void PrFromRefUpdated(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request updated", payload);
            AddEmbed(_embed);
        }

        private void PrModified(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request modified", payload);
            AddEmbed(_embed);
        }

        private void PrReviewerUpdated(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("New reviewer for Pull Request", payload);
            AddEmbed(_embed);
        }

        private void PrReviewerApproved(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request approved!", payload);
            AddEmbed(_embed);
        }

        private void PrReviewerUnapproved(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Removed approval for Pull Request", payload);
            AddEmbed(_embed);
        }

        private void PrReviewerNeedsWork(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request needs work", payload);
            AddEmbed(_embed);
        }

        private void PrMerged(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request merged!", payload);
            AddEmbed(_embed);
        }

        private void PrDeleted(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request deleted", payload);
            AddEmbed(_embed);
        }

        private void PrDeclined(BitbucketServerPayloadPullRequest payload)
        {
            FormatPrPayload("Pull Request declined", payload);
            AddEmbed(_embed);
        }

        private void PrCommentAdded(BitbucketServerPayloadPullRequest payload)
        {
            FormatCommentPayload("New comment on Pull Request", payload);
            AddEmbed(_embed);
        }

        private void PrCommentEdited(BitbucketServerPayloadPullRequest payload)
        {
            FormatCommentPayload("Updated comment on Pull Request", payload);
            AddEmbed(_embed);
        }

        private void PrCommentDeleted(BitbucketServerPayloadPullRequest payload)
        {
            FormatCommentPayload("Deleted comment on Pull Request", payload);
            AddEmbed(_embed);
        }

        private void MirrorRepoSynchronized(BitbucketServerPayloadMirrorSync payload)
        {
            _embed.Title = "Mirror Synchronized";
            _embed.Description = $"Bitbucket Mirrors synced: {payload.MirrorServer.Name}";
            AddEmbed(_embed);
        }
        
        private static EmbedAuthor ExtractAuthor(BitbucketServerActor actor, BitbucketServerRepository repository)
        {
            // To keep actual names private, we have opted to go with a different approach. By default, we will 
            // return the Repository Name as the Author name. If you want this changed, set the 
            // ALLOW_REAL_NAMES environment variable to true.
            var authorName = Environment.GetEnvironmentVariable("ALLOW_REAL_NAMES") == "true" 
                ? actor.DisplayName 
                : repository.Name;

            return new EmbedAuthor
            {
                Name = authorName,
                IconUrl = "https://cdn4.iconfinder.com/data/icons/logos-and-brands/512/44_Bitbucket_logo_logos-512.png"
            };
        }
        
        
        private void FormatCommitCommentPayload(string title, BitbucketServerPayloadComment comment)
        {
            _embed.Author = ExtractAuthor(comment.Actor, comment.Repository);
            _embed.Title = $"{title}: {comment.Commit.Substring(0,10)}";
            _embed.Description = comment.Comment.Text;
        }

        private void FormatPrPayload(string title, BitbucketServerPayloadPullRequest payload)
        {
            _embed.Author = ExtractAuthor(payload.Actor, payload.PullRequest.FromRef.Repository);
            _embed.Title = $"**{title}**\n" +
                           $"{payload.PullRequest.Title}\n" +
                           $"PR-{payload.PullRequest.Id}";
            _embed.Description = payload.PullRequest.Description;
            _embed.Url = ExtractPullRequestUrl(payload.PullRequest);
            _embed.Fields = ExtractPullRequestFields(payload.PullRequest);
        }

        private void FormatCommentPayload(string title, BitbucketServerPayloadPullRequest payload)
        {
            _embed.Title = title;
            _embed.Author = ExtractAuthor(payload.Actor, payload.PullRequest.FromRef.Repository);
            _embed.Description = payload.Comment.Text;
            _embed.Url = ExtractPullRequestUrl(payload.PullRequest);
        }


        private string ExtractPullRequestUrl(BitbucketServerPullRequest pullRequest)
        {
            return $"{ExtractBaseLink(pullRequest.Author.User)}/projects/" +
                   $"{pullRequest.FromRef.Repository.Project.Key}/repos/" +
                   $"{pullRequest.FromRef.Repository.Slug}/pull-requests/" +
                   $"{pullRequest.Id}/overview";
        }

        private List<EmbedField> ExtractPullRequestFields(BitbucketServerPullRequest pullRequest)
        {
            var fieldList = new List<EmbedField>();
            var fromField = new EmbedField
            {
                Name = "From",
                Value = pullRequest.FromRef.DisplayId
            };

            var toField = new EmbedField
            {
                Name = "To",
                Value = pullRequest.ToRef.DisplayId
            };
            
            fieldList.Add(fromField);
            fieldList.Add(toField);

            var fieldCount = 0;
            foreach (var reviewer in pullRequest.Reviewers)
            {
                fieldCount++;

                if (fieldCount > 10)
                {
                    break;
                }
                if (Environment.GetEnvironmentVariable("ALLOW_REAL_NAMES") == "true")
                {
                    var reviewerField = new EmbedField
                    {
                        Name = "Reviewer",
                        Value = reviewer.User.DisplayName
                    };
                    
                    fieldList.Add(reviewerField);
                }
                else
                {
                    var reviewerField = new EmbedField
                    {
                        Name = "Reviewer Status",
                        Value = reviewer.Status
                    };
                    
                    fieldList.Add(reviewerField);
                }
            }

            return fieldList;

        }

        private static List<EmbedField> ExtractRepoChangesField(IEnumerable<BitbucketServerChange> changes)
        {
            var fieldList = new List<EmbedField>();
            var changeCount = 0;

            foreach (var change in changes)
            {
                changeCount++;

                if (changeCount > 10)
                {
                    break;
                }

                var branch = change.Ref.DisplayId;
                var hash = change.ToHash.Substring(0,10);
                var type = change.Type;

                var field = new EmbedField
                {
                    Name = "Change",
                    Value = $"**Branch**: {branch}\n" +
                            $"**New Hash**: {hash}\n" +
                            $"**Type**: {type}"
                };
                
                fieldList.Add(field);

            }

            return fieldList;
        }

        private static string ExtractCommitCommentUrl(BitbucketServerPayloadRefsChanged payload)
        {
            return $"{ExtractBaseLink(payload.Actor)}/projects/{payload.Repository.Project.Key}" +
                   $"/repos/{payload.Repository.Slug}/{payload.Changes[0].FromHash}";
        }
        
        private static string ExtractBaseLink(BitbucketServerActor actor)
        {
            return string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL")) 
                ? actor.Links.Self[0].Href 
                : Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL");
        }
    }
}