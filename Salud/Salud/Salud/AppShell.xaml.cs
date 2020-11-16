using System;
using System.Collections.Generic;
using Salud.ViewModels;
using Salud.Views;
using Xamarin.Forms;

namespace Salud
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HipertensionTabbedPage), typeof(HipertensionTabbedPage));
            Routing.RegisterRoute(nameof(DiabetesTabbedPage), typeof(DiabetesTabbedPage));
            Routing.RegisterRoute(nameof(Sangre), typeof(Sangre));

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
