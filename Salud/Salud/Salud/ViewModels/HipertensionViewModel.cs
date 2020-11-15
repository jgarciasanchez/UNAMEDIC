using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Salud.ViewModels
{
    public class HipertensionViewModel : BaseViewModel
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
        public HipertensionViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand OnMenuItemConfiguracionesClicked
        {
            get
            {
                return new RelayCommand(OnMenuItemConfiguraciones);
            }
        }
        #endregion

        #region Methods
        public async void OnMenuItemConfiguraciones()
        {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage()); //Para una pantalla modal
            // await Shell.Current.GoToAsync(nameof(HipertensionTabbedPage)); //Para llamar otra vista
        }
        #endregion
    }
}
