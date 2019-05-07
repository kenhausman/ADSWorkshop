# Enhancing Applications with Bing Search

This hands-on lab guides you through enhancing a published bot (through Azure Bot Service) with one of the Bing Search APIs (part of Azure Cognitive Services).

## Objectives

In this lab, you will:

- Understand how adding Bing Search capabilities can enhance applications
- Integrate a Bing Search API (specifically Bing Image Search) into an existing bot application

## Prerequisites

### Lab02.2-building_bots

This lab starts from the assumption that you have built and published the bot from `lab02.2-building_bots`. It is recommended that you do that lab in order to be successful in the one that follows. If you have not, reading carefully through all the exercises and looking at some of the code or using it in your own applications may be sufficient, depending on your needs.  

#### Have access to Azure

You will need to have access to portal and be able to create resources on Azure.

>Note: This workshop was developed and tested with Visual Studio Community 2017

## Architecture

By this point, you should be familiar with the architecture diagram we've used to build our PictureBot. In the next lab, we'll talk about ways we might enhance our bot and implement one of those options.  

![Architecture Diagram](./resources/assets/AI_Immersion_Arch.png)

### Navigating the GitHub

There are several directories in the [resources](./resources) folder:

- **assets**, **instructor**: You can ignore these folders for the purposes of this lab.
- **code**: In here, there is one directory you might use:
  - **FinishedPictureBot-Bing**: This solution file here contains the code used to call the Bing Search API. If you get stuck in the lab, you can refer here.

> You need Visual Studio to run these labs. If you have already deployed a Windows Data Science Virtual Machine for one of the labs, we recommend using that.

## Collecting the Keys

You should already have a list of keys, we'll just be adding one more for this lab. We recommend storing the new keys in the same text file you created earlier.

>_Keys_
>
>- Bing Search V7 key

### Continue to [1_Overview](./1_Overview.md)