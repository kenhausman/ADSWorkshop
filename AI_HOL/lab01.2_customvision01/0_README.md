# Creating Custom Vision Applications

The goal of this lab is to create a CLI application that uses the Custom Vision API to classify images that you provide to the Custom Vision Service.

The Custom Vision Service is an Azure Cognitive Service that lets you build custom image classifiers. It makes it easy and fast to build, deploy, and improve an image classifier. The Custom Vision Service provides a REST API and a web interface to upload your images and train the classifier.  This service works well in use cases where you are working with images that cannot be identified by other services such as computer vision.

> **Note**  
> This lab will focus on creating a Custom Vision solution using C#.
> Want the see a Java solution? watch this video [here](https://channel9.msdn.com/Shows/AI-Show/Azure-Custom-Vision-How-to-Train-and-Identify-Unique-Designs-or-Image-Content), but note that we will not be maintaining the link to this video.

## Objectives

In this workshop, you will:

- Create a classification project
- Upload images.
- Add tags to images.
- Train a classification project.
- Obtain the prediction endpoint URL.
- Use the endpoint to programmatically test an image.

You can use this lab as a template for building your own app using the Custom Vision API. While there is a focus on Custom Vision, you will also leverage the following technologies:

- Data Science Virtual Machine (DSVM)
- Visual Studio

## Prerequisites

This workshop is meant for an AI Developer on Azure. Since this is a short workshop, there are certain things you need before you arrive.

## Platform requirements

Firstly, you should have experience with Visual Studio. We will be using it for everything we are building in the workshop, so you should be familiar with [how to use it](https://docs.microsoft.com/en-us/visualstudio/ide/visual-studio-ide) to create applications. Additionally, this is not a class where we teach you how to code or develop applications. We assume you know how to code in C# (you can learn [here](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949)).

Secondly, you should have experience with the portal and be able to create resources (and spend money) on Azure. We will not be providing Azure passes for this workshop.

>Note: This example has been tested using the .NET Framework using [Visual Studio 2017,
Community Edition](https://www.visualstudio.com/downloads/)

## Introduction

As mentioned earlier, the Custom Vision service works well in use cases where you are working with images that cannot be identified by other services such as computer vision.

An example could include looking for part defects in a manufacturing process. In this case you can use Custom Vision to train images for parts that are defective, and for parts that are ok. Another example could be in the classification of plants that may look very similar, but are in fact a different species. This is an example we will look at in this workshop.

## Architecture

For now, this lab **isn't** connected to the rest of the solution you are building in this training. But this may change in CY-2019.

### Continue to [1_Classification_Lab](./1_Classification_Lab.md)