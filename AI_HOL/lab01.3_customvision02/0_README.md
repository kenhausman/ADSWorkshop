### Module 1.3

# Lab: Creating an Object Detection Application using the Custom Vision API

The goal of this tutorial is to explore a basic Windows application that uses
the Custom Vision API to create an object detection project, add tags to it,
upload images, train the project, obtain the default prediction endpoint URL
for the project, and use the endpoint to programmatically test an image. You
can use this open source example as a template for building your own app for
Windows using the Custom Vision API.

## Important Note should you receive a Nuget Package Error

Long files name can cause Nuget package failures. Should you receive this error,
it is recommended that you place the solution files in a folder you have created
to reduce the number of characters in the filepath.

If you receive the following error

>NuGet Package restore failed for project ObjectDetection:
>The specified path, file name, or both are too long. The fully qualified file name must be less than 260 characters,
>and the directory name must be less than 248 characters.. Please see Error List window for detailed warnings and errors.
Perform the following steps

1. Create a folder in the C:\ named Temp2
2. In Windows Explorer, browse to the folder C:\LearnAI-Bootcamp\lab01.3_customvision02\
3. Copy the Resources folder
4. Browse to C:\Temp2, right click and click Paste
5. Wait until the copy completes

## Prerequisites

### Platform requirements

This example has been tested using the .NET Framework using [Visual Studio 2017,
Community Edition](https://www.visualstudio.com/downloads/)

### The Training API key

You also need to have a training API key. The training API key allows you to
create, manage, and train Custom Vision projects programmatically. All operations
on <https://customvision.ai> are exposed through this library, allowing you to
automate all aspects of the Custom Vision Service. You can obtain a key by
creating a new project at <https://customvision.ai> and then clicking on the
"setting" gear in the top right.

### The Images used for Training and Predicting

In the Resources\Starter\CustomVision.Sample\Images folder are three folders:

- fork
- scissors
- test

The fork and scissors folders contain images of these types of kitchen utensils from different perspectives. The test folder contains an image that will be used to perform the test prediction.

### Step 1: Create a console application and prepare the training key and the images needed for the example

Start Visual Studio 2017, Community Edition, open the Visual Studio solution
named **CustomVision.Sample.sln** from the following location:

```bash
Resources/Starter/CustomVision.Sample/CustomVision.Sample.sln
```

Should a "trust" message appear click "Yes".

Once opened, rebuild the solution. Then, within Solution Explorer, double click on Program.cs to open the file

The following (incomplete) code is shown.

```c#
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ObjectDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add your training & prediction key from the settings page of the portal


            // Create the Api, passing in the training key
            TrainingApi trainingApi = new TrainingApi() { ApiKey = trainingKey };

            // Find the object detection domain

            var objDetectionDomain = domains.FirstOrDefault(d => d.Type == "ObjectDetection");

            // Create a new project
            Console._("Creating new project:");
            var project = trainingApi._("Object Detection Project", null, objDetectionDomain.Id);

            // Make two tags in the new project
            var forkTag = trainingApi.CreateTag(project.Id, "fork");
            var scissorsTag = trainingApi.CreateTag(project.Id, "scissors");

            Dictionary<string, double[]> fileToRegionMap = new Dictionary<string, double[]>()
            {
                // FileName, Left, Top, Width, Height
                {"scissors_1", new double[] { 0.4007353, 0.194068655, 0.259803921, 0.6617647 } },
                {"scissors_2", new double[] { 0.426470578, 0.185898721, 0.172794119, 0.5539216 } },
                {"scissors_3", new double[] { 0.289215684, 0.259428144, 0.403186262, 0.421568632 } },
                {"scissors_4", new double[] { 0.343137264, 0.105833367, 0.332107842, 0.8055556 } },
                {"scissors_5", new double[] { 0.3125, 0.09766343, 0.435049027, 0.71405226 } },
                {"scissors_6", new double[] { 0.379901975, 0.24308826, 0.32107842, 0.5718954 } },
                {"scissors_7", new double[] { 0.341911763, 0.20714055, 0.3137255, 0.6356209 } },
                {"scissors_8", new double[] { 0.231617644, 0.08459154, 0.504901946, 0.8480392 } },
                {"scissors_9", new double[] { 0.170343131, 0.332957536, 0.767156839, 0.403594762 } },
                {"scissors_10", new double[] { 0.204656869, 0.120539248, 0.5245098, 0.743464053 } },
                {"scissors_11", new double[] { 0.05514706, 0.159754932, 0.799019635, 0.730392158 } },
                {"scissors_12", new double[] { 0.265931368, 0.169558853, 0.5061275, 0.606209159 } },
                {"scissors_13", new double[] { 0.241421565, 0.184264734, 0.448529422, 0.6830065 } },
                {"scissors_14", new double[] { 0.05759804, 0.05027781, 0.75, 0.882352948 } },
                {"scissors_15", new double[] { 0.191176474, 0.169558853, 0.6936275, 0.6748366 } },
                {"scissors_16", new double[] { 0.1004902, 0.279036, 0.6911765, 0.477124184 } },
                {"scissors_17", new double[] { 0.2720588, 0.131977156, 0.4987745, 0.6911765 } },
                {"scissors_18", new double[] { 0.180147052, 0.112369314, 0.6262255, 0.6666667 } },
                {"scissors_19", new double[] { 0.333333343, 0.0274019931, 0.443627447, 0.852941155 } },
                {"scissors_20", new double[] { 0.158088237, 0.04047389, 0.6691176, 0.843137264 } },
                {"fork_1", new double[] { 0.145833328, 0.3509314, 0.5894608, 0.238562092 } },
                {"fork_2", new double[] { 0.294117659, 0.216944471, 0.534313738, 0.5980392 } },
                {"fork_3", new double[] { 0.09191177, 0.0682516545, 0.757352948, 0.6143791 } },
                {"fork_4", new double[] { 0.254901975, 0.185898721, 0.5232843, 0.594771266 } },
                {"fork_5", new double[] { 0.2365196, 0.128709182, 0.5845588, 0.71405226 } },
                {"fork_6", new double[] { 0.115196079, 0.133611143, 0.676470637, 0.6993464 } },
                {"fork_7", new double[] { 0.164215669, 0.31008172, 0.767156839, 0.410130739 } },
                {"fork_8", new double[] { 0.118872553, 0.318251669, 0.817401946, 0.225490168 } },
                {"fork_9", new double[] { 0.18259804, 0.2136765, 0.6335784, 0.643790841 } },
                {"fork_10", new double[] { 0.05269608, 0.282303959, 0.8088235, 0.452614367 } },
                {"fork_11", new double[] { 0.05759804, 0.0894935, 0.9007353, 0.3251634 } },
                {"fork_12", new double[] { 0.3345588, 0.07315363, 0.375, 0.9150327 } },
                {"fork_13", new double[] { 0.269607842, 0.194068655, 0.4093137, 0.6732026 } },
                {"fork_14", new double[] { 0.143382356, 0.218578458, 0.7977941, 0.295751631 } },
                {"fork_15", new double[] { 0.19240196, 0.0633497, 0.5710784, 0.8398692 } },
                {"fork_16", new double[] { 0.140931368, 0.480016381, 0.6838235, 0.240196079 } },
                {"fork_17", new double[] { 0.305147052, 0.2512582, 0.4791667, 0.5408496 } },
                {"fork_18", new double[] { 0.234068632, 0.445702642, 0.6127451, 0.344771236 } },
                {"fork_19", new double[] { 0.219362751, 0.141781077, 0.5919118, 0.6683006 } },
                {"fork_20", new double[] { 0.180147052, 0.239820287, 0.6887255, 0.235294119 } }
            };

            // Add all images for fork
            var imagePath = Path.Combine("Images", "fork");
            var imageFileEntries = new List<ImageFileCreateEntry>();
            foreach (var fileName in Directory.EnumerateFiles(imagePath))
            {
                var region = fileToRegionMap[Path.GetFileNameWithoutExtension(fileName)];
                imageFileEntries.Add(new ImageFileCreateEntry(fileName, File.ReadAllBytes(fileName), null, new List<Region>(new Region[] { new Region(forkTag.Id, region[0], region[1], region[2], region[3]) })));
            }
            trainingApi.CreateImagesFromFiles(project.Id, new ImageFileCreateBatch(imageFileEntries));

            // Add all images for scissors


            // Now there are images with tags start training the project
            Console.WriteLine("\tTraining");
            var iteration = trainingApi.TrainProject(project.Id);

            // The returned iteration will be in progress, and can be queried periodically to see when it has completed
            while (iteration.Status == "Training")
            {
                Thread.Sleep(1000);

                // Re-query the iteration to get its updated status
                iteration = trainingApi.GetIteration(project.Id, iteration.Id);
            }

            // The iteration is now trained. Make it the default project endpoint
            iteration.IsDefault = true;
            trainingApi.UpdateIteration(project.Id, iteration.Id, iteration);
            Console.WriteLine("Done!\n");

            // Now there is a trained endpoint, it can be used to make a prediction

            // Create a prediction endpoint, passing in the obtained prediction key
            PredictionEndpoint endpoint = new PredictionEndpoint() { ApiKey = predictionKey };

            // Make a prediction against the new project
            Console.WriteLine("Making a prediction:");
            var imageFile = Path.Combine("Images", "test", "test_image.jpg");
            using (var stream = File.OpenRead(imageFile))
            {
                var result = endpoint.PredictImage(project.Id, File.OpenRead(imageFile));

                // Loop over each prediction and write out the results
                foreach (var c in result.Predictions)
                {
                    Console.WriteLine($"\t{c.TagName}: {c.Probability:P1} [ {c.BoundingBox.Left}, {c.BoundingBox.Top}, {c.BoundingBox.Width}, {c.BoundingBox.Height} ]");
                }
            }
            Console.ReadKey();
        }
    }
}
```

### Step 2: Add references to the to the two Custom Vision nuget packages

At the very top of the Program.cs file, use the correct syntax to add references to the two nuget packages:

```c#
   Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training
   Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction
```

### Step 3: Add your training and prediction key into the Program.cs file

Under the comment "// Add your training & prediction key from the settings page of the portal"
type in the following code to add the training and prediction key to enable access to the
Custom Vision services

```c#
            string trainingKey = "<enter your training key here>";
            string predictionKey = "<enter your prediction key here>";
```

### Step 4: Create code that will enable the application to use the object detection domain

To set the application to make use of the objection domain, under the line "// Find the object detection domain"
write code that will create a variable named "domains" using the GetDomains method of the trainingApi

### Step 5: Create a project named Object Detection Project

Under the line "// Create a new project", create a project named Object Detection project and display in the application that a project is being created.

In the second line below, what method will replace the _ to create the project named Object Detection Project?

```c#
            Console.WriteLine("Creating new project:");
            var project = trainingApi._("Object Detection Project", null, objDetectionDomain.Id);
```

Replace the _ after "trainingApi." with a method that will display a message in the application that a project is being created.

### Step 6: Create a tag for the scissor images named scissorsTag

Under the lines:

```c#
           // Make two tags in the new project

           var forkTag = trainingApi.CreateTag(project.Id, "fork");
```

Write code that create a variable named scissorsTag that creates a tag named scissors against the current project.

### Step 7: Upload the scissor images and map them to the scissorsTag

Under the line "// Add all images for scissors" add code that will upload the scissors image and assign the images
to the tag of scissorsTag. Hint. Use the code under "// Add all images for fork" as a template for creating the code
to upload the scissor images and map them to the scissorsTag.

### Step 8: train a project named Object Detection Project

Under the line "// Now there are images with tags start training the project", the next step is to train the project and have the application display that the project is being trained.

>Q. In the second line below, what method will replace the _ to train the project?

```c#
            Console.WriteLine("\tTraining");
            var iteration = trainingApi._(project.Id);
```

Replace the _ with a method that will display a message in the application that a project is being trained.

### Step 9: Run the example

Build and run the solution. The training and prediction of the images can take 2 minutes. The prediction results
appear on the console.

### Need help

Start Visual Studio 2017, Community Edition, open the Visual Studio solution
named **CustomVision.Sample.sln** in the solution sub-directory of where this lab is
located:

```c#
Resources/Solution/CustomVision.Sample/CustomVision.Sample.sln
```

### Further Reading

The source code for this client application is available on
[github](https://github.com/Azure-Samples/cognitive-services-dotnet-sdk-samples/tree/master/CustomVision).

The client library includes multiple sample applications, and this tutorial is
based on the `CustomVision.Sample` demo within that repository.

### Continue to [Module 1.4](../lab01.5-luis/0_README.md), or return to the [Main](../../README.md) menu