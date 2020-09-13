# Hooksharp
Webhook parsing engine for Microsoft Teams and Discord.

[![Build status](https://ci.appveyor.com/api/projects/status/q39ensom1braxp97?svg=true)](https://ci.appveyor.com/project/glosharp/hooksharp)

*We are still actively building this young project!*

## Terminology

**Provider**: These are the services that will be providing the webhook that needs to be parsed. Example, BitBucket Server.

**Handler**: These are the services that will handle the parsed webhook. Example, Microsoft Teams or Discord.

## Accepting Requests
If there is a particular Provider that you want add please open up an issue! Typically if you request a provider they will become available for both Discord and 
Microsoft Teams.

## TODOs

- [x] Create models for Bitbucket Server requests for strong typing
- [ ] Figure out what other Handlers to implement
- [ ] Expand Microsoft Teams

## Inspiration

The inspiration of this project stems from Skyhook, an amazing project located at https://github.com/Commit451/skyhook. 
The major difference between Sharphook and Skyhook is that Sharphook not only integrates Discord, but Microsoft Teams 
as well. 

Make sure you check out Skyhook too!