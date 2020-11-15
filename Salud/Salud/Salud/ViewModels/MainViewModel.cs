using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public SingInViewModel SingIn { get; set; }
        public DiabetesViewModel AppShell { get; set; }
        public MenuViewModel Menu { get; set; }
        public HipertensionViewModel Hipertension{ get; set;}

       // public AppShell appShell { get; set; }





        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
         //   this.appShell = new AppShell();
        }
        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
