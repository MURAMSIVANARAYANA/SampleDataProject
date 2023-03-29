using SampleDataProject.Services;
using SampleDataProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleDataProject
{
    public partial class App : Application
    {

        public App()
        {
           Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU4ODk0QDMxMzkyZTM0MmUzMERwR0pXZFBGN1pvWXJ2cXg0WDZENklmZDJqR3VVajJNMDFyOFNoMTBsUG89");
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
