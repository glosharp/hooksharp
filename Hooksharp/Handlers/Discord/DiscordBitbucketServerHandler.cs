using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hooksharp.Models.Discord;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Handlers.Discord
{
    public class DiscordBitbucketServerHandler : DiscordBaseHandler
    {
        private readonly Embed _embed;
        private JObject _body;
        
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
            _body = raw;
            switch (eventKey)
            {
                case "diagnostics:ping":
                    DiscordPayload.Content = "Diagnostic Ping";
                    DiagnosticsPing();
                    break;
                
                case "repo:refs_changed":
                    RepoRefsChanged();
                    break;
                
                case "repo:modified":
                    RepoModified();
                    break;
                
                case "repo:forked":
                    RepoForked();
                    break;
                
                case "repo:comment:added":
                    RepoCommentAdded();
                    break;
                    
                case "repo:comment:edited":
                    RepoCommentEdited();
                    break;
                
                case "repo:comment:deleted":
                    RepoCommentDeleted();
                    break;
                
                case "mirror:repo_synchronized":
                    MirrorRepoSynchronized();
                    break;
                
                case "pr:opened":
                    PrOpened();
                    break;
                
                case "pr:from_ref_updated":
                    PrFromRefUpdated();
                    break;
                
                case "pr:modified":
                    PrModified();
                    break;
                
                case "pr:reviewer:updated":
                    PrReviewerUpdated();
                    break;
                
                case "pr:reviewer:approved":
                    PrReviewerApproved();
                    break;
                    
                case "pr:reviewer:unapproved":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrReviewerUnapproved();
                    break;
                
                case "pr:reviewer:needs_work":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrReviewerNeedsWork();
                    break;
                
                case "pr:merged":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrMerged();
                    break;
                
                case "pr:declined":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrDeclined();
                    break;
                
                case "pr:deleted":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrDeleted();
                    break;
                
                case "pr:comment:added":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrCommentAdded();
                    break;
                
                case "pr:comment:edited":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrCommentEdited();
                    break;
                
                case "pr:comment:deleted":
                    DiscordPayload.Content = "Diagnostic Ping";
                    PrCommentDeleted();
                    break;
            }
            
            return Task.CompletedTask;
        }
        
        private void DiagnosticsPing()
        {
            _embed.Title = "Test Connection from Sharphook";
            _embed.Description = "You have successfully configured #hook with your Bitbucket Server Instance.";
            
            AddEmbed(_embed);
        }

        private void RepoRefsChanged()
        {
            _embed.Author = ExtractAuthor();
            _embed.Title = "New Commit has been pushed";
            _embed.Url = ExtractCommitCommentUrl();
            _embed.Description = $"**Branch**: {(string)_body["changes"]?[0]?["ref"]?["id"]}";
            _embed.Fields = ExtractRepoChangesField();
            AddEmbed(_embed);
            
        }

        private void RepoModified()
        {
            _embed.Author = ExtractAuthor();
            _embed.Title = "Repository has been modified";

            AddEmbed(_embed);
            
        }

        private void RepoForked()
        {
            _embed.Author = ExtractAuthor();
            _embed.Title = "A new [`fork`] has been created.";
            
            AddEmbed(_embed);
        }

        private void RepoCommentAdded()
        {
            FormatCommitCommentPayload("New comment on commit");
            AddEmbed(_embed);
        }

        private void RepoCommentEdited()
        {
            FormatCommitCommentPayload("Comment edited on commit");
            AddEmbed(_embed);
        }

        private void RepoCommentDeleted()
        {
            FormatCommitCommentPayload("Comment deleted on commit");
            AddEmbed(_embed);
        }

        private void PrOpened()
        {
            FormatPrPayload("Pull Request opened");
            AddEmbed(_embed);
        }

        private void PrFromRefUpdated()
        {
            FormatPrPayload("Pull Request updated");
            AddEmbed(_embed);
        }

        private void PrModified()
        {
            FormatPrPayload("Pull Request modified");
            AddEmbed(_embed);
        }

        private void PrReviewerUpdated()
        {
            FormatPrPayload("New reviewer for Pull Request");
            AddEmbed(_embed);
        }

        private void PrReviewerApproved()
        {
            FormatPrPayload("Pull Request approved!");
            AddEmbed(_embed);
        }

        private void PrReviewerUnapproved()
        {
            FormatPrPayload("Removed approval for Pull Request");
            AddEmbed(_embed);
        }

        private void PrReviewerNeedsWork()
        {
            FormatPrPayload("Pull Request needs work");
            AddEmbed(_embed);
        }

        private void PrMerged()
        {
            FormatPrPayload("Pull Request merged!");
            AddEmbed(_embed);
        }

        private void PrDeleted()
        {
            FormatPrPayload("Pull Request deleted");
            AddEmbed(_embed);
        }

        private void PrDeclined()
        {
            FormatPrPayload("Pull Request declined");
            AddEmbed(_embed);
        }

        private void PrCommentAdded()
        {
            FormatCommentPayload("New comment on Pull Request");
            AddEmbed(_embed);
        }

        private void PrCommentEdited()
        {
            FormatCommentPayload("Updated comment on Pull Request");
            AddEmbed(_embed);
        }

        private void PrCommentDeleted()
        {
            FormatCommentPayload("Deleted comment on Pull Request");
            AddEmbed(_embed);
        }

        private void MirrorRepoSynchronized()
        {
            _embed.Author = ExtractAuthor();
            _embed.Title = "Mirror Synchronized";
            
            AddEmbed(_embed);
        }
        
        private EmbedAuthor ExtractAuthor()
        {
            var authorName = ExtractRepositoryName() ?? (string) _body["actor"]?["displayName"];

            return new EmbedAuthor
            {
                Name = authorName,
                IconUrl = "https://cdn4.iconfinder.com/data/icons/logos-and-brands/512/44_Bitbucket_logo_logos-512.png"
            };
        }

        private string ExtractRepositoryName()
        {
            return (string) _body["repository"]?["name"];
        }
        
        private void FormatCommitCommentPayload(string title)
        {
            var commit = (string) _body["commit"];
            var formattedCommit = commit?.Substring(0, 10);
            
            _embed.Author = ExtractAuthor();
            _embed.Title = $"{title}: {formattedCommit}";
            _embed.Description = (string) _body["comment"]?["text"];
        }

        private void FormatPrPayload(string title)
        {
            var pullRequestId = (string) _body["pullRequest"]?["id"];
            var pullRequestTitle = (string) _body["pullRequest"]?["title"];
            var pullRequestDescription = (string) _body["pullRequest"]?["description"];
            
            _embed.Author = ExtractAuthor();
            _embed.Title = $"{title}\n" +
                           $"{pullRequestId} - {pullRequestTitle}";
            _embed.Description = pullRequestDescription;
            _embed.Url = ExtractPullRequestUrl();
            _embed.Fields = ExtractPullRequestFields();
        }

        private void FormatCommentPayload(string title)
        {
            var pullRequestId = (string) _body["pullRequest"]?["id"];
            var pullRequestTitle = (string) _body["pullRequest"]?["title"];
            var pullRequestDescription = (string) _body["comment"]?["text"];
            
            _embed.Author = ExtractAuthor();
            _embed.Description = pullRequestDescription;
            _embed.Url = ExtractPullRequestUrl();
        }


        private string ExtractPullRequestUrl()
        {
            var projectKey = (string) _body["pullRequest"]?["fromRef"]?["repository"]?["project"]?["key"];
            var slug = (string) _body["pullRequest"]?["fromRef"]?["repository"]?["slug"];
            var pullRequestId = (string) _body["pullRequest"]?["id"];
            return $"{ExtractBaseLink()}/projects/{projectKey}/repos/{slug}/pull-requests/{pullRequestId}/overview";
        }

        private List<EmbedField> ExtractPullRequestFields()
        {
            var fieldList = new List<EmbedField>();
            var fromField = new EmbedField
            {
                Name = "From",
                Value = (string) _body["pullRequest"]?["fromRef"]?["displayId"]
            };

            var toField = new EmbedField
            {
                Name = "To",
                Value = (string) _body["pullRequest"]?["toRef"]?["displayId"]
            };
            
            fieldList.Add(fromField);
            fieldList.Add(toField);

            // ReSharper disable once PossibleInvalidOperationException
            var reviewerLength = (int) _body["pullRequest"]?["reviewers"].Count();
            
            for (var i = 0; i < Math.Min(reviewerLength, 15); i++)
            {
                var reviewerField = new EmbedField
                {
                    Name = "Reviewer",
                    Value = (string) _body["pullRequest"]["reviewers"][i]?["user"]?["displayName"]
                };
                
                fieldList.Add(reviewerField);
            }

            return fieldList;

        }

        private string ExtractPullRequestRepositoryName()
        {
            return (string) _body["pullRequest"]?["toRef"]?["repository"]?["name"];
        }
        
        private string ExtractRepoRepositoryName()
        {
            return (string) _body["repository"]?["name"];
        }

        private string ExtractRepoUrl()
        {
            var projectKey = (string) _body["repository"]?["project"]?["key"];
            var slug = (string) _body["repository"]?["slug"];

            return $"{ExtractBaseLink()}/projects/{projectKey}/repos/{slug}/browse";
        }
        
        private List<EmbedField> ExtractRepoChangesField()
        {
            var fieldList = new List<EmbedField>();
            var changesLength = _body["changes"]!.Count();
            
            for (var i = 0; i < Math.Min(changesLength, 28); i++)
            {
                var branch = (string) _body["changes"]?[i]?["ref"]?["displayId"];
                var hash = (string) _body["changes"]?[i]?["toHash"];
                var formattedHash = hash!.Substring(0, 10);
                var type = (string) _body["changes"]?[i]?["type"];

                var changesEmbed = new EmbedField
                {
                    Name = "Change",
                    Value = $"**Branch**: {branch}\n" +
                            $"**New Hash**: {formattedHash}\n" +
                            $"**Type**: {type}"
                };

                fieldList.Add(changesEmbed);
            }

            return fieldList;
        }

        private string ExtractCommitCommentUrl()
        {
            var projectKey = (string) _body["repository"]?["project"]?["key"];
            var projectSlug = (string) _body["repository"]?["slug"];
            var commit = (string) _body["commit"];
            
            return $"{ExtractBaseLink()}/projects/{projectKey}/repos/{projectSlug}/{commit}";
        }
        
        private string ExtractBaseLink()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL")))
            {
                return (string) _body["author"]?["user"]?["links"]?["self"]?[0]?["href"];
            }

            return Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL");
        }
    }
}