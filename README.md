# xamarin-hands-on-labs

Labs and samples for the Xamarin Hands-On-Labs workshop.

Contents:

## Lab 01: "Hello World"

Labs that let you create a new Xamarin.iOS or Xamarin.Android app from scratch, to get familiar with how Xamarin works.

Get started via [Hello iOS](./Lab01/iOS/readme.md) or [Hello Android](./Lab01/Android/readme.md).

## Lab 02, 03, 04: "Quotes"

3 Labs that lets you get familiar with Xamarin.Forms, adding behavior to your apps and adding native features to your apps.

Get started via [Lab 02](./Lab02/readme.md)

## Lab 05: app-conquerthenetwork

Lab materials and prerecorded presentation for the Resilient Connected Client chapter.

Get started via [Conquer the Network](./Lab05/README.md)

# [Getting started](#Instructions)

Install all necessary software on your Windows PC or MacBook _before coming to the workshop_. The installation packages for Visual Studio and Xamarin are quite big so we strongly recommend installing them at home or at the office instead of using conference Wifi. In our experience, the [Microsoft Docs Setup Guides](https://docs.microsoft.com/en-us/xamarin/get-started/installation/) provide a very good and comprehensive set of instructions for getting ready for the Hands On Labs.

## Important to know!

Getting everything to work well can be a hassle. Please prepare as much as possible up front.

- Our samples use the Android Support Library v7, which requires Android SDK API 27. Make sure you have this installed. From Visual Studio, go to _Tools > Android > SDK Manager_ and make sure **Android 8.1 (API 27)** > **SDK Platform** is installed, alongside  **Android 8.0 (API 26)**
- Debugging **Android** apps is easiest using an Android device (phone or tablet) that is developer unlocked. Make sure to bring a USB cable to the workshop and _unlock your device for development_. Steps: [https://www.wikihow.tech/Unlock-Developer-Options-on-Android](https://www.wikihow.tech/Unlock-Developer-Options-on-Android). You may have to install a device driver, depending on the brand and type of your device. If you don’t have an Android device, you will find setup and verification steps for an emulator in this document.
- If you still want to use an Android emulator, to increase speed of your Android emulator, installing the Hardware Accellerated Execution Manager (HAXM) enabled emulator from Google will help: [HAXM driver](https://software.intel.com/en-us/articles/intel-hardware-accelerated-execution-manager-intel-haxm). Make sure to check if your system supports  hardware accellerated virtualization.
- Debugging **iOS** apps is easiest using the iOS Simulator on your Mac because this will save you the trouble of having to create provisioning profiles.

Additionally, please clone this repo to your development laptop so you can follow along with our labs.

## Known issues / Troubleshooting

Here are some known issues we ran into with students during previous runs of our Hands On Labs:

### Error message: **File path too long** while building or running exercises

To avoid this error, please make sure to clone this repository into a directory that is close to the **C:\\** root (or other drive on your computer).

### Breakpoint not hitting shared code while debugging Android app

This may be caused by tools not being installed or configured properly. Check the following:

- Delete all Mono Shared Runtimes _from the Android emulator_: go into _Settings > Apps_ and delete all instances of **Mono Shared Runtime**; try restarting the debug session
- Uninstall your app _from the Android emulator_: go into _Settings > Apps_ and delete your app; try debugging your app again
- Check for non standard characters in your project/soluation path (try to use only letters, numbers and spaces)
- In the toolbar, change _AnyCPU_ to _x86_; try debugging again
- In the Project Properties of your Android project, switch off _Optimize Code_ (under the _Build_ tab); rebuild the project and try debugging again

### Cannot connect to Mac from Visual Studio 2017

If you cannot connect to your Mac build host because of the following error:

    One or more Xcode tools were not installed successfully. Failed tools: XcodeExtensionSupport.pkg, MobileDevice.pkg. Even if you can continue working with iOS apps, we strongly recommend you to manually open Xcode on ... and install them if asked.

Refer to [this article](https://developercommunity.visualstudio.com/content/problem/209704/vs-156-xcode-tools-installation-fails.html?childToView=211204#comment-211204) for a solution.

### More troubleshooting

You can find more troubleshooting tips on the [Xamarin University website](https://university.xamarin.com/resources/troubleshooting).

## Extra links, tips & tricks

### Recommended Xamarin plugins & components

- [Xamarin.Essentials](https://docs.microsoft.com/en-us/xamarin/essentials/) - Official Xamarin component with abstractions for the most common device capabilities
- [Xamarin Community Toolkit](https://github.com/xamarin/XamarinCommunityToolkit) - Community (open source) effects and Xamarin.Forms add ons
- [Xamarin Components](https://github.com/xamarin/XamarinComponents) - Curated lists of the most popular Xamarin libraries

### Async & Await

`Task` based programming with `async` & `await` is very prominent in mobile apps, since we need to be careful about not blocking the UI thread, which is responsible for drawing the screen and animations like scrolling. Any blocking operation, such as CPU intensive calculations or I/O (file or network) should be offloaded to background threads. `Async` & `await` has become very popular for doing this.

However! This can become quite tricky pretty fast. Here is some interesting background material to read up on:

- [Await, and UI, and deadlocks! Oh my!](https://blogs.msdn.microsoft.com/pfxteam/2011/01/13/await-and-ui-and-deadlocks-oh-my/) explains some of the pitfalls in using `async` & `await` in UI applications
- [Stephen Cleary's blog](http://blog.stephencleary.com) has excellent material on `async` & `await`; articles that are especially relevant to mobile are:
- His [A Tour of Task series](http://blog.stephencleary.com/2014/04/a-tour-of-task-part-0-overview.html)
- His [MSDN articles about async in MVVM](http://blog.stephencleary.com/2014/04/announcement-msdn-async-mvvm-articles.html)
- His [Task.Run Etiquette series](http://blog.stephencleary.com/2013/10/taskrun-etiquette-and-proper-usage.html)
- His [Async OOP series](https://blog.stephencleary.com/2013/01/async-oop-0-introduction.html)
- His [AsyncTime video series](https://vimeo.com/ondemand/asynctime)
- The creators of [NServiceBus](https://particular.net/nservicebus) have an interesting webinar on [Async/Await Best Practices](https://particular.net/webinars/async-await-best-practices) which is worth watching
- Or read up on their article about [Async/Await tips and tricks](https://particular.net/blog/async-await-tips-and-tricks)
- [Async and Await, All the Things Your Mother Never Told You](https://channel9.msdn.com/Events/Xamarin-Evolve/2016/Async-and-Await-All-the-Things-Your-Mother-Never-Told-You), a presentation by James Clancy from Xamarin

### Backgrounding techniques
As mentioned in our lecture about Mobile First Architecture, backgrounding techniques can be very helpful in retrieving and processing data without letting the user wait. Some articles that explain the different approaches:

- [Xamarin docs: iOS backgrounding](https://developer.xamarin.com/guides/ios/application_fundamentals/backgrounding/)
- [Xamarin docs: Android services](https://developer.xamarin.com/guides/android/application_fundamentals/services/)
- [Backgrounding with Xamarin.Forms](https://www.youtube.com/watch?v=Z1YzyreS4-o) - Video Lecture by Rob Gibbens
- [Microsoft docs: UWP background tasks](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/support-your-app-with-background-tasks)

### Debug with the Xamarin Android Player from Visual Studio in VMWare or Parallels
This [article by James Montemagno](https://montemagno.com/debug-with-the-xamarin-android-player-from-visual/) describes how you can setup debugging with a remote Android emulator running on your Mac, while working from Visual Studio in a virtual Windows image.

### Forms Community Toolkit
The [Forms Community Toolkit](https://github.com/FormsCommunityToolkit/FormsCommunityToolkit) is a community led open source project which contains many useful building blocks for `Xamarin.Forms` applications, such as prebuilt `Effect`s, `Converter`s and `Behavior`s. They are all available as Nuget packages.

### Secure storage
Here are some links to look at when it comes to storing secrets on your device:

- [SQLCipher](https://www.zetetic.net/sqlcipher/) is a popular library that works on top of the SQLite database, which is available out-of-the-box on iOS and Android. Zetetic offers a [paid component for SQLCipher in Xamarin](https://www.zetetic.net/sqlcipher/sqlcipher-for-xamarin/). It encrypts the database using strong encryption algorithms.
- The `Xamarin.Auth` library supports secure storage of credentials. It is described in [this article](https://github.com/xamarin/recipes/tree/master/Recipes/xamarin-forms/General/store-credentials). Under the hood, it uses the [Android KeyStore](https://developer.android.com/training/articles/keystore.html) and [iOS Keychain](https://developer.xamarin.com/samples/monotouch/Keychain/) API's. When it comes to storing private data, it pays to investigate the appropriate API's and storage locations in each platform before rolling your own solution. See [this guide for iOS](https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/security-privacy).

Two relevant presentations on the topic of security:

- [Is Your App Secure](https://channel9.msdn.com/Events/Xamarin-Evolve/2016/Is-Your-App-Secure) by Kerry Lothrop
- [Addressing the OWASP Mobile Security Threats Using Xamarin](https://channel9.msdn.com/Events/Xamarin-Evolve/2016/Addressing-the-OWASP-Mobile-Security-Threats-Using-Xamarin)

### Performance
With `Xamarin.Forms`, questions about performance often pop up. As your UI becomes more complex, there are certainly pitfalls in `Xamarin.Forms` when it comes to performance. Some resources that are worth checking out:

- [Optimizing App Performance with Xamarin.Forms](https://channel9.msdn.com/Events/Xamarin-Evolve/2016/Optimizing-App-Performance-with-XamarinForms), a presentation by Jason Smith from Xamarin.
- [Improving Xamarin.Forms Startup Performance](https://xamarinhelp.com/improving-xamarin-forms-startup-performance/)
- [ListView Performance](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/performance)
- A [breakdown of the improvements](https://blog.xamarin.com/glimpse-future-xamarin-forms-3-0/) in the Xamarin.Forms 3.0 release

### ESRI in Xamarin apps
Some material about using ESRI ArcGIS mapping components in Xamarin apps:

- [Developer: ArcGIS Runtime SDK for Xamarin: An Introduction](https://www.youtube.com/watch?v=IDPnUZgAK5w)
- [ArcGIS Runtime SDK for .NET product page](https://developers.arcgis.com/net/)
