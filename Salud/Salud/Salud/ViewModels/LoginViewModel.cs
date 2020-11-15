using GalaSoft.MvvmLight.Command;
using Salud.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes //Aquí van los propieades que serán modificadas en el controlador 
        //Atributos de LoginPage
        private string _edtxUsuario;
        private string _edtxClave;

        public ImageSource _ImageUrl;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
        public string edtxUsuario
        {
            get { return this._edtxUsuario; }
            set { this.SetValue(ref this._edtxUsuario, value); } // no solo asigna, también refresca la vista...
        }
        public string edtxClave
        {
            get { return this._edtxClave; }
            set { this.SetValue(ref this._edtxClave, value); } // no solo asigna, también refresca la vista...
        }
        public ImageSource ImageUrl
        {
            get
            {
                if (this._ImageUrl == null)
                {
                    return ImageSource.FromFile("xamarin_logo.png");
                }
                else
                {
                    return this._ImageUrl;
                }
            }
            set { this.SetValue(ref this._ImageUrl, value); } // no solo asigna, también refresca la vista...
        }

        #endregion

        #region  Constructors
        public LoginViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(OnLoginClicked);
            }
        }
        public ICommand SingInCommand
        {
            get
            {
                return new RelayCommand(OnSingInClicked);
            }
        }
        #endregion

        #region Methods
        public void OnLoginClicked()
        {
              Application.Current.MainPage = new AppShell();
           // Application.Current.MainPage = MainViewModel.GetInstance().appShell;
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        public async void OnSingInClicked()
        {
            MainViewModel.GetInstance().SingIn = new SingInViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SingInPage());
        }
        #endregion
    }
}