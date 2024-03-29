# Module 2: Connect PI Simulator to IoT Hub

![IoT Hub](images/pi_simulator.png)

Connect a Simulator to your IoT Hub and stream data. 

### In this lab you will

* Learn to create a device using Azure Portal

* Connect the simulator to IoT Hub

* Send telemetry data to Azure

## Create a Device

Go To your IoT Hub in the portal and click on **IoT Devices**


![Resource Group](images/iot_devices.png)

Click on **+ Add** and enter a **Device ID** and click **Save**. 

![Resource Group](images/add_device.png)

Click on the device and copy the primary key connection string. 

![Resource Group](images/connection-string.png)

Right-click the link below and open the PI Simulator in a new window

[Pi Simulator](https://azure-samples.github.io/raspberry-pi-web-simulator/#GetStarted)

Replace the connection string with the primary key connection string copied in the previous steps

![Resource Group](images/pi_connection_string_before.png)

After you copy the connection string should look like below

![Resource Group](images/pi_connection_string_after.png)

Click Run and start sending messages. LED will start blinking

![Resource Group](images/pi_message.png)

Messages will start flowing into IoT Hub

![Resource Group](images/iothub_messages.png)

>**You will work with Labs in the Next Module to Visualize the Data flowing into IoT Hub**

### Continue to [Module 3: Create Azure Time Series Insights and Visualize Device Data](../timeseriesinsights/README.md), or return to the [Main](../../README.md) menu