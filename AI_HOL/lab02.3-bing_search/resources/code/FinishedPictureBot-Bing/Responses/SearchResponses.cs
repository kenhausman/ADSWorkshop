using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;

namespace PictureBot.Responses
{
    public class SearchResponses
    {
        // add a task called "ReplyWithSearchRequest"
        // it should take in the context and ask the
        // user what they want to search for
        public static async Task ReplyWithSearchRequest(ITurnContext context)
        {
            await context.SendActivityAsync($"What would you like to search for?");
        }
        public static async Task ReplyWithSearchConfirmation(ITurnContext context, string utterance)
        {
            await context.SendActivityAsync($"Ok, searching for pictures of {utterance}");
        }
        public static async Task ReplyWithNoResults(ITurnContext context, string utterance)
        {
            await context.SendActivityAsync("There were no results found for \"" + utterance + "\".");
        }
        public static async Task ReplyWithBingConfirmation(ITurnContext context, string utterance)
        {
            await context.SendActivityAsync($"Ok, searching Bing for more pictures of {utterance}");
        }
        public static async Task ReplyWithBingResults(ITurnContext context, string utterance)
        {
            await context.SendActivityAsync($"Here are the top five results from Bing Images for {utterance}");
        }
        public static async Task ReplyWithDontBing(ITurnContext context)
        {
            await context.SendActivityAsync($"OK, I won't search Bing.");
        }
    }
}