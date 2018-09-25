mg src="Screenshots/icon.png" alt="icon" width="64px" >

# Plugin.Localization
Build cross-platform multilingual applications with Xamarin.Forms using the built-in .NET localization framework.

# Setup

- `Plugin.Localization` Available on NuGet: https://www.nuget.org/packages/Plugin.Localization
- Install into your platform-specific projects (iOS/Android), and any .NET Standard 2.0 projects required for your app.

## Platform Support

|Platform|Supported|Version|Notes|
| ------------------- | :-----------: | :------------------: | :------------------: |
|Xamarin.iOS|Yes|iOS 7+| |
|Xamarin.Android|Yes|API 16+|Project should [target Android framework 8.1+](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/android-api-levels?tabs=vswin#framework)|

# Usage

### Getting Started

Add Resource file



Add Resource per language.



### Localizing XAML

Set the Resource to Public



How to use in XAML


### Code Change.

Android and IOS projects automatically sets the resource's culture correctly to the CultureInfo.InstalledUICulture. Also set the Culture in all the resource's in all the assemblies. Only need to reference this package if that is not the case.

```csharp
using System;
using System.Globalization;
using Plugin.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

//translateManager only set Culture in resource's, only when Attribute is set.
[assembly: ResxLocalize]

namespace Local.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var localizeHelper = DependencyService.Resolve<ILocalizeHelper>();
            var languageConvertor = new LanguageConvertor();
            var translateManager = new TranslateManager(localizeHelper, languageConvertor);

            // Set Culture in all the resource's in all the assemblies that has ResxLocalize Attribute.
            translateManager.SetCulture();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
```

# Limitations

Only support iOS and Android for the moment. 

# Contributing

Contributions are welcome.  Feel free to file issues and pull requests on the repo and they'll be reviewed as time permits.

## Icon

Thank you for the Icon by Juliia Osadcha (https://www.iconfinder.com/Juliia_Os)
