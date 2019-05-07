## Setup:
Estimated Time: 15-30 minutes

> Note: If you have been provided an Azure environment for completing this bootcamp, you may skip ahead to **Setting up your Data Science Virual Machine**.

### Setting up your Azure Account

You may activate an Azure free trial at [https://azure.microsoft.com/en-us/free/](https://azure.microsoft.com/en-us/free/).  

If you have been given an Azure Pass to complete this lab, you may go to [http://www.microsoftazurepass.com/](http://www.microsoftazurepass.com/) to activate it.  Please follow the instructions at [https://www.microsoftazurepass.com/howto](https://www.microsoftazurepass.com/howto), which document the activation process.  A Microsoft account may have **one free trial** on Azure and one Azure Pass associated with it, so if you have already activated an Azure Pass on your Microsoft account, you will need to use the free trial or use another Microsoft account.

### Setting up your Data Science Virtual Machine

After creating an Azure account, you may access the [Azure portal](https://portal.azure.com). From the portal, [create a Resource Group for this lab](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-portal). Detailed information about the Data Science Virtual Machine can be [found online](https://docs.microsoft.com/en-us/azure/machine-learning/data-science-virtual-machine/overview), but we will just go over what's needed for this workshop. We are creating a VM and not doing it locally to ensure that we are all working from the same environment. This will make troubleshooting much easier. In your Resource Group, deploy and connect to a "Data Science Virtual Machine - Windows 2016", with a size of 2-4 vCPUs and 8-12 GB RAM, some examples include but are not limited to D4S_V3, B4MS, DS3, DS3_V2, etc. **Put in the location that is closest to you: West US 2, East US, West Europe, Southeast Asia**. All other defaults are fine. 
> Note: Testing was completed on both West US 2 D4S_V3 and Southeast Asia D4S_V3.

[Connect to your VM](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/connect-logon). Once you're connected, install your favorite web browser and go to https://portal.azure.com from here.

> Note: Be sure to turn off your DSVM **from the portal** after you have completed the Setup lab. When the workshop begins, you will need to start your DSVM from the portal to begin the labs. We recommend turning off your DSVM at the end of each day, and deleting all of the resources you create at the end of the workshop. Alternatively, you can [set up auto-shutdown for your DSVM](https://blogs.msdn.microsoft.com/devtestlab/2018/01/02/set-auto-shutdown-for-virtual-machines-in-azure/). Be sure to set the correct time zone.

## You have completed the prerequisites. 


### Continue to [Module 1: Introduction to Azure IoT Hub and Connect MXChip](../IoTHub/README.md), or return to the [Main](../README.md) menu

