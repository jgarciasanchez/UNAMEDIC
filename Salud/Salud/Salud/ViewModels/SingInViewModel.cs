using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class SingInViewModel : BaseViewModel
    {
        #region Attributes //Aquí van los propieades que serán modificadas en el controlador 
        //Atributos de LoginPage
        private string _edtxUsuario;
        private string _edtxClave;

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

        #endregion

        #region  Constructors
        public SingInViewModel()
        {
        }
        #endregion

        #region Commands
        public ICommand SingInCommand
        {
            get
            {
                return new RelayCommand(OnSingInClicked);
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(OnCancelClicked);
            }
        }
        #endregion

        #region Methods

        public async void OnCancelClicked()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public void OnSingInClicked()
        {
           // Application.Current.MainPage = MainViewModel.GetInstance().appShell;
        }
        #endregion
    }
}
