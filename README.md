# INVR-Platform-Ext-Function

HOW TO USE
1. set exitFunction script in hierachy (for example in an manager object). Make sure that it stays persistent.
2. call "ExitFunction.Instance.ExitExperience();" at the place you want to quit the application.
(i.e. by pressing a specific button or through the menu)

HOW TO USE THE XR CONTROLLER INPUT SCRIPT
1. Have the Unity Package "XR PluginManagement" installed in your project.
2. Set XRControllerInput.cs in hierachy (can be on the same object as the exitFunction script).
3. Click on the '+' for the UnityEvents "OnSecondaryButtonPress" and "OnMenuButtonPress" (these are for Oculus Devices) and "OnPrimaryButtonPress" (for Vive Devices). 
-> If possible: try to subscribe to the events via script to make a differentiation between Oculus and Vive (you could use "if(XRDevice.model.ToLower().Contains("oculus")").
5. Drag and drop the object which contains the exitFunction into the empty object slot.
6. Click on "No Function" and select "ExitFunction > ExitExperience ()"
7. Make sure that the correct hand is selected in the Inspector. It's the variable at the top ("XR Controller" > "Left Hand" and "Right Hand"). You can add the script two times and select a different hand on each of them to have it working for both hands. 
    
