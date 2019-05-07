# Lab: Creating Image Classification Applications using the Custom Vision API

In this lab, you will create an application that deals with the classification of plants.

In the Resources\Images folder are three folders:

- Hemlock
- Japanese Cherry
- Test

The Hemlock and Japanese Cherry folders contain images of these types of plants that
will be classified by tagging and training the images. The Test folder contains an image that will be used to
perform the test prediction

## Important Note should you receive a Nuget Package Error

Long files name can cause Nuget package failures. Should you receive this error,
it is recommended that you place the solution files in a folder you have created
to reduce the number of characters in the filepath.

If you receive the following error

>NuGet Package restore failed for project ObjectDetection:
>The specified path, file name, or both are too long. The fully qualified file name must be less than 260 characters,
>and the directory name must be less than 248 characters.. Please see Error List window for detailed warnings and errors.

Peform the following steps

1. Create a folder in the C:\ named Temp1
2. In Windows Explorer, browse to the folder C:\LearnAI-Bootcamp\lab01.2_customvision01\
3. Copy the Resources folder
4. Browse to C:\Temp1, right click and click Paste
5. Wait until the copy completes

## Step 0: The API keys

You also need to have a training and prediction API key. The training API key allows you to
create, manage, and train Custom Vision projects programatically. All operations
on <https://customvision.ai> are exposed through this library, allowing you to
automate all aspects of the Custom Vision Service. You can obtain a key by
accessing <https://customvision.ai> and then clicking on the
"setting" gear in the top right.

> Note: Internet Explorer is not supported. We recommend using Edge, Firefox, or Chrome.

## Step 1: Create a console application and prepare the training key and the images needed for the example

Start Visual Studio 2017, Community Edition, open the Visual Studio solution
named **CustomVision.Sample.sln** located in the following sub-directory:

>Resources/Starter/CustomVision.Sample/CustomVision.Sample.sln

Once opened, rebuild the solution. Then, within Solution Explorer, double click on Program.cs to open the file

At the bottom of the Progam.cs file are  methods called `TrainingApiCredentials` and `PredictionEndpointCredentials` which instantiates the training and prediction key respectively. Finally, there is one called `LoadImagesFromDisk` that loads two sets of images that this used to train the project, and one that performs the prediction test with a test image using the default prediction endpoint. On opening the project the following code should be displayed from line 35:

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;

namespace CustomVision.Sample
{
    class Program
    {
        private static List<MemoryStream> hemlockImages;

        private static List<MemoryStream> japaneseCherryImages;

        private static MemoryStream testImage;

        static void Main(string[] args)
        {
            // Add your training and prediction key from the settings page of the portal
            string trainingKey = "<add your training key here>";
            string predictionKey = "<add your prediction key here>";

            // Create the Api, passing in the training key

            TrainingApi trainingApi = new TrainingApi() { ApiKey = trainingKey };

            ...
            ...
            ...
            ...
            ...

        }

        private static void LoadImagesFromDisk()
        {
            // this loads the images to be uploaded from disk into memory
            hemlockImages = Directory.GetFiles(@"..\..\..\..\Images\Hemlock").Select(f => new MemoryStream(File.ReadAllBytes(f))).ToList();
            japaneseCherryImages = Directory.GetFiles(@"..\..\..\..\Images\Japanese Cherry").Select(f => new MemoryStream(File.ReadAllBytes(f))).ToList();
            testImage = new MemoryStream(File.ReadAllBytes(@"..\..\..\..\Images\Test\test_image.jpg"));

        }
    }

    internal class PredictionEndpointCredentials
    {
        private string predictionKey;

        public PredictionEndpointCredentials(string predictionKey)
        {
            this.predictionKey = predictionKey;
        }
    }

    internal class TrainingApiCredentials
    {
        private string trainingKey;

        public TrainingApiCredentials(string trainingKey)
        {
            this.trainingKey = trainingKey;
        }
    }
}
```

### Step 2: Add your training and prediction key into the Program.cs file

Under the comment "// Add your training & prediction key from the settings page of the portal"
type in the following code to add the training and prediction key to enable access to the
Custom Vision services

```c#
string trainingKey = "<enter your training key here>";
string predictionKey = "<enter your prediction key here>";
```

## Step 3: Create a Custom Vision Service project

To create a new Custom Vision Service project, add the following code in the body of the `Main()` method after the call to `new TrainingApi().`

```c#
// Create a new project
Console.WriteLine("Creating new project:");
var project = trainingApi._("My New Project");
```

>Q. What method should you replace the _ with to create a new Custom Vision Service project?

## Step 4: Add tags to your project

To add tags to your project, insert the following code after the call to
`("My New Project");`.

```c#
// Make two tags in the new project
var hemlockTag = trainingApi.CreateTag(project.Id, "Hemlock");
var japaneseCherryTag = trainingApi._(project.Id, "Japanese Cherry");
```

>Q. What method should you replace the _ with to create a tag for Japanese Cherry?

## Step 5: Upload images to the project

To add the images we have in memory to the project, insert the following code
after the call to `(project.Id, "Japanese Cherry")` method.

```c#
// Add some images to the tags
Console.WriteLine("\tUploading images");
LoadImagesFromDisk();

// Images can be uploaded one at a time
foreach (var image in hemlockImages)
{
   trainingApi.CreateImagesFromData(project.Id, image, new List<string>() { hemlockTag.Id.ToString() });
}

foreach (var image in japaneseCherryImages)
{
   trainingApi.CreateImagesFromData(project.Id, image, new List<string>() { japaneseCherryTag.Id.ToString() });
}
```

## Step 6: Train the project

Now that we have added tags and images to the project, we can train it. Insert
the following code after the end of code that you added in the prior step. This
creates the first iteration in the project. We can then mark this iteration as
the default iteration.

>Q. What method should you replace the _ with to train the project?

```c#
// Now there are images with tags start training the project
Console.WriteLine("\tTraining");
var iteration = trainingApi._(project.Id);

// The returned iteration will be in progress, and can be queried periodically to see when it has completed
while (iteration.Status == "Training")
{
    Thread.Sleep(1000);

    // Re-query the iteration to get it's updated status
    iteration = trainingApi.GetIteration(project.Id, iteration.Id);
}

// The iteration is now trained. Make it the default project endpoint
iteration.IsDefault = true;
trainingApi.UpdateIteration(project.Id, iteration.Id, iteration);
Console.WriteLine("Done!\n");
```

## Step 7: Get and use the default prediction endpoint

We are now ready to use the model for prediction. First we obtain the endpoint
associated with the default iteration. Then we send a test image to the project
using that endpoint. Insert the code after the training code you have just
entered.

```c#
// Now there is a trained endpoint, it can be used to make a prediction  
PredictionEndpoint endpoint = new PredictionEndpoint() { ApiKey = predictionKey };

// Make a prediction against the new project  
Console.WriteLine("Making a prediction:");
var result = endpoint.PredictImage(project.Id, testImage);

// Loop over each prediction and write out the results  
foreach (var c in result.Predictions)
{
    Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
}
Console.ReadKey();
```

## Step 8: Run the example

Build and run the solution. The training and prediction of the images can take 2 minutes.
The prediction results appear on the console.

## Help

Start Visual Studio 2017, Community Edition, open the Visual Studio solution
named **CustomVision.Sample.sln** in the solution following sub-directory below:

>Resources/Solution/CustomVision.Sample/CustomVision.Sample.sln

### Further Reading

The source code for the Windows client library is available on
[github](https://github.com/Microsoft/Cognitive-CustomVision-Windows/).

The client library includes multiple sample applications, and this tutorial is based on the `CustomVision.Sample` demo within that repository.