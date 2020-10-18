using GalaSoft.MvvmLight.Command;
using Salud.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class DiabetesViewModel : BaseViewModel
    {


        #region  Constructors
        public DiabetesViewModel()
        {
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(OnMenuItemClicked);
            }
        }
        #endregion

        #region Methods
        //public async void OnLoginClicked()
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    Application.Current.MainPage = new AppShell();
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
        private async void OnMenuItemClicked()
        {
            //Application.Current.MainPage = new LoginPage();
            await Shell.Current.GoToAsync("//LoginPage");
        }
        #endregion
    }
}
