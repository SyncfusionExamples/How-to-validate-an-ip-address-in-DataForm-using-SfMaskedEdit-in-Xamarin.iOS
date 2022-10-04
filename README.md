# How to validate an IP address in DataForm using SfMaskedEdit in Xamarin.iOS

This repository contains sample for how to validate an ip address in SfDataForm using the [Syncfusion Xamarin.iOS Masked Edit](https://help.syncfusion.com/xamarin-ios/sfmaskededit/getting-started) control.

## Syncfusion controls

This project used the following Syncfusion control(s):
* [SfMaskedEdit](https://www.syncfusion.com/xamarin-ios-ui-controls/masked-textbox)

## Requirements to run the sample

* [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)

Refer to the following link for more details - [System Requirements](https://help.syncfusion.com/xamarin-ios/system-requirements)

## How to run the sample

1. Clone the sample and open it in Visual Studio.

   *Note: If you download the sample using the "Download ZIP" option, right-click it, select Properties, and then select Unblock.*
   
2. Register your license key in the FinishedLaunching override method of AppDelegate.cs file as demonstrated in the following code.

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			//Register Syncfusion license
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

			// create a new window instance based on the screen size
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			// If you have defined a root view controller, set it here:
			// Window.RootViewController = myViewController;

			// make the window visible
			Window.MakeKeyAndVisible();

			return true;
		}
		
	Refer to this [link](https://help.syncfusion.com/xamarin-ios/licensing/overview) for more details.
	
3. Clean and build the application.

4. Run the application.

## License

Syncfusion has no liability for any damage or consequence that may arise by using or viewing the samples. The samples are for demonstrative purposes, and if you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage that is related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion’s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion’s samples.
