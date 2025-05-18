# Battery Monitor App V1

## About

The battery monitor app is a simple application that allows you to `monitor` the battery status  and `control` the AC power of your laptop device via Bluetooth or serial communication. It provides information such as the current battery percentage, charging status,
and send message to arduino ESP32 DEV module to control the AC power if `High` or `Low` threshold's reached .


![CI](https://github.com/github/visualstudio/workflows/CI/badge.svg)


## Documentation
There is no documentation available for this project at this moment.

## Build requirements

* Visual Studio 2019 or newer
  * `.NET desktop development` workload
  * `.NET Core cross platform development` workload
  * `32 feet module package` workload

The built Apllication tested on Windows 10 and Windows 11.

## Build

Clone the repository and its submodules.


## Visual Studio Build

Build `BatteryMonitorApp.sln` using Visual Studio 2022.


## Screenshots
![Alt text](screenshots/bmimg.jpg?raw=true "Optional Title")

## Arduino ESP32 DEV module Code

Visit the [ESP32 DEV MODULE PROJECT](CONTRIBUTING.md) for details on how to code the ESP32 module.

## features
- Monitor battery status
- Control AC power
- Send messages to ESP32 module
- bluetooth and serial communication
- Low and High Threshold settings

## troubleshooting
* If you want to use the app with ESP32 module, make sure you have the following:
  * ESP32 module connected to your laptop via USB or Bluetooth
  * ESP32 module powered on
  * ESP32 module configured with the correct code and settings

* if you want send the Level of battery to the ESP32 module, make sure you have the following:
  
  * go to the `BatteryMonitorApp` project and open the `Form1.cs` file go to `CheckBatteryThresholds` function and change the value to the desired message you want to send to the ESP32 module.
```bash
     //uncomment this code if you want to send the level of battery to the ESP32 modulewithin a complete message. 
     //use %LEVEL% to replace the level of battery
     _notificationService.ShowNotification(
         "Battery Low",
          txtLowMessage.Text.Replace("%LEVEL%", status.BatteryLevel.ToString())
     );
     //delete this 
     if (_communicationHandler != null) _communicationHandler.SendMessage("c");
     // add this
     if (_communicationHandler != null) _communicationHandler.SendMessage(txtLowMessage.Text);
```
  * and do the same for high threshold. 

## Copyright

Copyright 2019 - 2022 GitHub, Inc.

Licensed under the [MIT License](LICENSE.md)