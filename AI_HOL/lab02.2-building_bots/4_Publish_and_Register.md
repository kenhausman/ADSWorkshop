## 4_Publish_and_Register:
Estimated Time: 10-15 minutes

### Lab 4.1: Re-publish your bot

As you may recall, in the first section of this lab, you deployed a simple Echo Bot using Azure Bot Service. You've since changed the code quite substantially to create your PictureBot. What you'll do next is re-publish your bot to the same Azure Web App Bot.

First, you need to locate your user password for publishing which can be found in **PostDeployScripts > _web_app_name_.PublishSettings > userPWD**. Copy password value.

Next, right-click on your project and select "Publish...". Your Publish Profile should appear, configured with all your application's settings. When you select "Publish", you'll be prompted for the user password you just copied. Paste it in and select OK.  

> Alternatively, you can select the "Configure" button and save your password, so you don't have to enter it every time you want to publish.

Once your Web App Bot has successfully republished to Azure Bot Service, you'll get a pop-up web page, similar to that of when you run the bot locally. The difference is that the URL should match your bot's published URL. You can close this window.  


### Lab 4.2: Testing the published bot

#### Using the Emulator

Open your emulator and open the same ".bot" file you used to test your bot locally. However, instead of using the "development" endpoint, select the "production" endpoint. Test it out and confirm that you're PictureBot was successfully published.  

In your future bot endeavors, being able to compare the published and the local bot side-by-side easily is an awesome feature. 


#### Using the portal

Return to the portal to your Web App Bot resource. Under Bot Management, select "Test in Web Chat" to test if your bot has been published and is working accordingly. If it is not, review the previous lab, because you may have skipped a step. Re-publish and return here.

After you've confirmed your bot is published and working, check out some of the other features under Bot Management. Select "Channels" and notice there are many channels, and when you select one, you are instructed on how to configure it. 

Want to learn more about the various aspects related to bots? Spend some time reading the [how to's and design principles](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-design-principles?view=azure-bot-service-4.0). You can also check out [this course on designing and architecting intelligent agents](https://aka.ms/daaia).  

For more information on testing bots or using the Direct Line channel, we recommend you review the supplementary materials in [lab02.6-testing_bots](../lab02.6-testing_bots/0_README.md).

### Continue to [5_Closing](./5_Closing.md)  
Back to [README](./0_README.md)
