using GalaSoft.MvvmLight.Command;
using Salud.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class MenuViewModel : BaseViewModel
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
        public MenuViewModel()
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
        public ICommand OnDiabetesClicked
        {
            get
            {
                return new RelayCommand(OnDiabetes);
            }
        }
        public ICommand OnHipertensionClicked
        {
            get
            {
                return new RelayCommand(OnHipertension);
            }
        }
        public ICommand OnAguaClicked
        {
            get
            {
                return new RelayCommand(OnAgua);
            }
        }
        public ICommand OnSangreClicked
        {
            get
            {
                return new RelayCommand(OnSangre);
            }
        }
        #endregion

        #region Methods
        public async void OnSangre()
        {
            MainViewModel.GetInstance().Sangre = new SangreViewModel();
            await Shell.Current.GoToAsync(nameof(Sangre));
        }
        public async void OnAgua()
        {
            await Shell.Current.GoToAsync(nameof(Hidratacion));
        }
        public async void OnHipertension()
        {
            MainViewModel.GetInstance().Hipertension = new HipertensionViewModel();
            await Shell.Current.GoToAsync(nameof(HipertensionTabbedPage));
        }
        public async void OnDiabetes()
        {
            MainViewModel.GetInstance().Diabetes = new DiabetesViewModel();
            await Shell.Current.GoToAsync(nameof(DiabetesTabbedPage));
        }
        public async void OnMenuItemConfiguraciones()
        {
            // Application.Current.MainPage = new AppShell();
           // Application.Current.MainPage = MainViewModel.GetInstance().appShell;
            //await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());

            await Shell.Current.GoToAsync(nameof(HipertensionTabbedPage));
        }
        #endregion
    }
}
