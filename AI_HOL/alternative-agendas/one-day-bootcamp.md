# Azure Cognitive Services Bootcamp

Building Intelligent Apps and Agents with the Computer Vision API, Custom Vision Service, LUIS, Bing Search, and Azure Search

> Note: This is a recommended **one-day** agenda, with the goal of getting a good mix of Cognitive Services and Microsoft Bot Framework. If you're interested in the full two-day course, please refer to the main [README](../README.md).

## Welcome

Welcome to the Learn AI Bootcamp for Emerging AI Developers. We will focus on hands-on activities that develop proficiency in Azure Cognitive Services including Computer Vision, Custom Vision, LUIS, and Bing Search. You will also learn to leverage other AI-oriented services such as Azure Search and Azure Bot Services. These labs assume an introductory to intermediate knowledge of these services, and, if this is not the case, then you should spend the time working through the prerequisites.

> **!!Important note 09/28/2018!!**: The Microsoft Bot Builder SDK V4 went GA at Ignite this week. The bot labs have been updated to SDK V4, but the SDK V3 labs are located in the resources folder for the bot labs (not being maintained). Additionally, we have moved the logging and testing labs to supplementary exercises (not being maintained at the moment), and the bootcamp will focus on the addition of the Bing Search APIs to bots and other applications.  
> If you are an instructor redelivering this course and have questions, please email learnanalytics@microsoft.com.  

## Goals

Most challenges observed by customers in these realms are in stitching multiple services together. As such, where possible, we have tried to place key concepts in the context of a broader example.

At the end of this workshop, you should be able to:

- Understand how to configure your apps to call Cognitive Services
- Build an application that calls various Cognitive Services APIs (specifically Computer Vision)
- Understand how to implement Azure Search features to provide a positive search experience inside applications
- Configure an Azure Search service to extend your data to enable full-text, language-aware search
- Build, train, and publish a LUIS model to help your bot communicate effectively
- Build and publish an intelligent bot using Microsoft Bot Framework that leverages LUIS and Azure Search

## Prerequisites

This workshop is meant for an AI Developer on Azure. Since this is only a short workshop, there are certain things you need before you arrive.

Firstly, you should have some previous exposure to Visual Studio. We will be using it for everything we are building in the workshop, so you should be familiar with [how to use it](https://docs.microsoft.com/en-us/visualstudio/ide/visual-studio-ide) to create applications. Additionally, this is not a class where we teach you how to code or develop applications. We assume you have some familiarity with C# (intermediate level - you can learn [here](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949) and [here](https://docs.microsoft.com/en-us/dotnet/csharp/quick-starts/)), but you do not know how to implement solutions with Cognitive Services.

Secondly, you should have some experience developing bots with Microsoft's Bot Framework. We won't spend a lot of time discussing how to design them or how dialogs work. If you are not familiar with the Bot Framework, you should complete [this tutorial](https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-sdk-quickstart?view=azure-bot-service-4.0) prior to attending the workshop.

Thirdly, you should have experience with the portal and be able to create resources (and spend money) on Azure. We will not be providing Azure passes for this workshop.

Finally, before arriving at the workshop, we expect you to have completed [1_Setup](./lab01.1-computer_vision/1_Setup.md).

## Agenda

Please note: This is a rough agenda, and the schedule is subject to change pending class activities, breaks, and interactions.

- 8-9 (optional): Setup assistance
- 9-9:30: Introduction and Context for the Course
- 9:30-11:30: [Lab 1.1: Simplifying Cognitive Services App Development using Portable Class Libraries][lab-cogsrvc-301]
- 11:30-12:30: [Lab 1.5: Developing Intelligent Applications with LUIS][lab-cogsrvc-341]
- 12:30-1:30: Lunch
- 1:30-2:30: [Lab 2.1: Developing Intelligent Applications with Azure Search][lab-azsearch-301]
- 2:30-4:30: [Lab 2.2: Building Intelligent Bots][lab-intelbot-301]
  - Finish early? Try this: [Lab 2.3: Enhancing Applications with Bing Search](https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab02.3-bing_search/0_README.md)
- 4:30-5: Q&A and Feedback for Emerging AI Bootcamp

## Supplementary materials

Please refer to the main [README](../README.md) that has all of the materials for the two-day bootcamp.

## Related courses

Here are some related courses from the LearnAI team:

- [LearnAI: Intelligent Agents: Design and Architecture](https://aka.ms/daaia)
- [LearnAI: Building Enterprise Cognitive Search Solutions](https://aka.ms/csw)  

[lab-cogsrvc-301]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-cogsrvc-301
[lab-cogsrvc-321]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-cogsrvc-321
[lab-cogsrvc-322]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-cogsrvc-322
[lab-cogsrvc-323]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-cogsrvc-323
[lab-cogsrvc-341]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-cogsrvc-341
[lab-azsearch-301]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-azsearch-301
[lab-intelbot-301]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-intelbot-301
[lab-intelbot-311]: https://aka.ms/LearnAI-EmergingAIDevBootcamp-intelbot-311
[lab-intelbot-321]:https://aka.ms/LearnAI-EmergingAIDevBootcamp-intelbot-321
[gitter]: https://gitter.im/LearnAI-Bootcamps