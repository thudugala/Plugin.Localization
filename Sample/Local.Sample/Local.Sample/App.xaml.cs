using System;
using System.Globalization;
using Plugin.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

//translateManager only set Culture in resource's, if only this Attribute is set.
[assembly: ResxLocalize]

namespace Local.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Android and IOS projects automatically sets the resource's culture correctly to the CultureInfo.InstalledUICulture
            // Also set the Culture in all the resource's in all the assemblies. 
            // Only need to reference this package if that is not the case.

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
