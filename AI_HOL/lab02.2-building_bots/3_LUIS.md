## 3_LUIS

Estimated Time: 10-15 minutes

Our bot is now capable of taking in a user's input, calling Azure Search, and returning the results in a carousel of Hero cards. Unfortunately, our bot's communication skills are brittle. One typo, or a rephrasing of words, and the bot will not understand. This can cause frustration for the user. We can greatly increase the bot's conversational abilities by enabling it to understand natural language with the LUIS model we built yesterday in "lab01.5-luis."  

We will have to update our bot in order to use LUIS.  We can do this by modifying "Startup.cs" and "PictureBot.cs."

### Lab 3.1: Adding LUIS to Startup.cs

Open "Startup.cs" and locate the `ConfigureServices` method. We'll add LUIS here by adding an additional service for LUIS after creating and registering the state accessors.  

Below:
```csharp
            services.AddSingleton((Func<IServiceProvider, PictureBotAccessors>)(sp =>
            {
                .
                .
                .
                return accessors;
            });
```

Add:
```csharp
            // Create and register a LUIS recognizer.
            services.AddSingleton(sp =>
            {
                // Get LUIS information
                var luisApp = new LuisApplication( "YourLuisAppId", "YourLuisKey", "YourLuisEndpoint");

                // Specify LUIS options. These may vary for your bot.
                var luisPredictionOptions = new LuisPredictionOptions
                {
                    IncludeAllIntents = true,
                };

                // Create the recognizer
                var recognizer = new LuisRecognizer(luisApp, luisPredictionOptions, true,null);
                return recognizer;
            });
```

Use the app ID, subscription key, and base URI for your LUIS model. The base URI will be "https://region.api.cognitive.microsoft.com/" (do include the final forward slash, and URL protocol specification), where region is the region associated with the key you are using. Some examples of regions are, `westus`, `westcentralus`, `eastus2`, and `southeastasia`.  

You can find your base URL by logging into www.luis.ai, going to the **Publish** tab, and looking at the **Endpoint** column under **Resources and Keys**. The base URL is the portion of the **Endpoint URL** before 'luis' and the other parameters.  

**Hint**: The LUIS App ID will have hyphens in it, and the LUIS subscription key will not.  

### Lab 3.2: Adding LUIS to PictureBot's MainDialog

Open "PictureBot.cs." The first thing you'll need to do is initialize the LUIS recognizer, similar to how you did for `PictureBotAccessors`. Below the commented line `// Lab 2.2.3 Initialize LUIS Recognizer`, add the following:
```csharp
private LuisRecognizer _recognizer { get; } = null;
```  
Next, navigate to where you initialize a new instance of the PictureBot class. The first line will look like this in your code:
```csharp
public PictureBot(PictureBotAccessors accessors, ILoggerFactory loggerFactory /*, LuisRecognizer recognizer*/)
```  
Now, maybe you noticed we had this commented out in your previous labs, maybe you didn't. You have it commented out now, because up until now, you weren't calling LUIS, so a LUIS recognizer didn't need to be an input to PictureBot. But now that you are, you need to uncomment the input requirement, and the following line below `// Lab 2.2.3 Add instance of LUIS Recognizer`:
```csharp
_recognizer = recognizer ?? throw new ArgumentNullException(nameof(recognizer));
```
Again, this should look very similar to how we initialized the instance of `_accessors`.  

As far as updating our `MainDialog` goes, there's no need for us to add anything to the initial `GreetingAsync` step, because regardless of user input, we want to greet the user when the conversation starts.  

In `MainMenuAsync`, we do want to start by trying Regex, so we'll leave most of that. However, if Regex doesn't find an intent, we want the `default` action to be different. That's when we want to call LUIS.  

Replace:
```csharp
                default:
                    {
                        await MainResponses.ReplyWithConfused(stepContext.Context);
                        return await stepContext.EndDialogAsync();
                    }
```
With:
```csharp
                default:
                    {
                        // Call LUIS recognizer
                        var result = await _recognizer.RecognizeAsync(stepContext.Context, cancellationToken);
                        // Get the top intent from the results
                        var topIntent = result?.GetTopScoringIntent();
                        // Based on the intent, switch the conversation, similar concept as with Regex above
                        switch ((topIntent != null) ? topIntent.Value.intent : null)
                        {
                            case null:
                                // Add app logic when there is no result.
                                await MainResponses.ReplyWithConfused(stepContext.Context);
                                break;
                            case "None":
                                await MainResponses.ReplyWithConfused(stepContext.Context);
                                // with each statement, we're adding the LuisScore, purely to test, so we know whether LUIS was called or not
                                await MainResponses.ReplyWithLuisScore(stepContext.Context, topIntent.Value.intent, topIntent.Value.score);
                                break;
                            case "Greeting":
                                await MainResponses.ReplyWithGreeting(stepContext.Context);
                                await MainResponses.ReplyWithHelp(stepContext.Context);
                                await MainResponses.ReplyWithLuisScore(stepContext.Context, topIntent.Value.intent, topIntent.Value.score);
                                break;
                            case "OrderPic":
                                await MainResponses.ReplyWithOrderConfirmation(stepContext.Context);
                                await MainResponses.ReplyWithLuisScore(stepContext.Context, topIntent.Value.intent, topIntent.Value.score);
                                break;
                            case "SharePic":
                                await MainResponses.ReplyWithShareConfirmation(stepContext.Context);
                                await MainResponses.ReplyWithLuisScore(stepContext.Context, topIntent.Value.intent, topIntent.Value.score);
                                break;
                            case "SearchPics":
                                // Check if LUIS has identified the search term that we should look for.  
                                // Note: you should have stored the search term as "facet", but if you did not,
                                // you will need to update.
                                var entity = result?.Entities;
                                var obj = JObject.Parse(JsonConvert.SerializeObject(entity)).SelectToken("facet");

                                // If entities are picked up on by LUIS, store them in state.Search
                                // Also, update state.Searching to "yes", so you don't ask the user
                                // what they want to search for, they've already told you
                                if (obj != null)
                                {                                 
                                    // format "facet", update state, and save save
                                    state.Search = obj.ToString().Replace("\"", "").Trim(']', '[').Trim();
                                    state.Searching = "yes";
                                    await _accessors.ConversationState.SaveChangesAsync(stepContext.Context);                                   
                                }
                                // Begin the search dialog
                                await MainResponses.ReplyWithLuisScore(stepContext.Context, topIntent.Value.intent, topIntent.Value.score);
                                return await stepContext.BeginDialogAsync("searchDialog", null, cancellationToken);                               
                            default:
                                await MainResponses.ReplyWithConfused(stepContext.Context);
                                break;
                        }
                        return await stepContext.EndDialogAsync();
                    }
```
Let's briefly go through what we're doing in the new code additions. First, instead of responding saying we don't understand, we're going to call LUIS. So we call LUIS using the LUIS Recognizer, and we store the Top Intent in a variable. We then use `switch` to respond in different ways, depending on which intent is picked up. This is almost identical to what we did with Regex.  

> Note: If you named your intents differently in LUIS than instructed in "lab01.5-luis", you need to modify the `case` statements accordingly.  

Another thing to note is that after every response that called LUIS, we're adding the LUIS intent value and score. The reason is just to show you when LUIS is being called as opposed to Regex (you would remove these responses from the final product, but it's a good indicator for us as we test the bot).  

Bring your attention to `case "SearchPics"`. Here, we check if LUIS also returned an entity, specifically the "facet" entity that we created in "lab01.5-luis." If LUIS doesn't locate the "facet" entity, we take the user through the searchDialog, so we can determine what they want to search for and give them the results.   

If LUIS does determine a "facet" entity from the utterance, we don't want to take the users through the whole search dialog. We want to be efficient so the user has a good experience, so we store "facet" in `state.Search`, and we update `state.Searching` to "yes", meaning we won't ask them what they want to search for, we'll skip to `SearchAsync`.  

Scroll down to `SearchRequestAsync` and locate where you ask the user what they want to search for. The `if` statement works similarly to that of the Greeting. If we know what they want to search for, skip to the next step (using `stepContext.NextAsync()`), but if we don't know, ask. This is also why we'll clear out `state.SearchTerm` at the end of `SearchAsync`. Discuss with a neighbor to confirm you understand how you're flowing from LUIS through the searchDialog steps.   

Hit F5 to run the app. In the Bot Emulator, try sending the bots different ways of searching pictures. What happens when you say "search pics" or "send me pictures of water" or "show me dog pics"? Try some other ways of searching, sharing and ordering pictures.  

If you have extra time, see if there are things LUIS isn't picking up on that you expected it to. Maybe now is a good time to go to luis.ai, [review your endpoint utterances](https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/label-suggested-utterances), and retrain/republish your model.  

You can also review the documentation guidance for adding LUIS to bots [here](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-v4-luis?view=azure-bot-service-4.0&tabs=cs).


> Fun Aside: Reviewing the endpoint utterances can be extremely powerful.  LUIS makes smart decisions about which utterances to surface.  It chooses the ones that will help it improve the most to have manually labeled by a human-in-the-loop.  For example, if the LUIS model predicted that a given utterance mapped to Intent1 with 47% confidence and predicted that it mapped to Intent2 with 48% confidence, that is a strong candidate to surface to a human to manually map, since the model is very close between two intents.  


**Extra credit (to complete later):** Configure a BotServices class to store your search service and LUIS information. Here are [some samples to use as a reference](https://github.com/Microsoft/BotBuilder-Samples/tree/master/samples/csharp_dotnetcore).

**Extra credit (to complete later)**: Create a process for ordering prints with the bot using dialogs, responses, and models.  Your bot will need to collect the following information: Photo size (8x10, 5x7, wallet, etc.), number of prints, glossy or matte finish, user's phone number, and user's email. The bot will then want to send you a confirmation before submitting the request.


Get stuck? You can find the solution for this lab under **resources > code**. We recommend using this as a reference, not as a solution to run, but if you choose to run it, be sure to add the necessary keys. The readme file within the solution (once you open it) will tell you what keys you need to add in order to run the solution.   


### Continue to [4_Publish_and_Register](./4_Publish_and_Register.md)  
Back to [README](./0_README.md)
