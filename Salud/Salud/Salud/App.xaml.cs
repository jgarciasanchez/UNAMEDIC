using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Salud.Services;
using Salud.Views;

namespace Salud
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUyMzUzQDMxMzgyZTMzMmUzMFV6bldhdXNpb0FXZEg2T2E2WkwveTQyQWV1dkI0bHBIOXUvZW9TRVNTNVk9");
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //MainPage = new NavigationPage(new LoginPage());
            ToLogin();
        }
        public async void ToLogin()
        {
            await Shell.Current.GoToAsync("//LoginPage");
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
