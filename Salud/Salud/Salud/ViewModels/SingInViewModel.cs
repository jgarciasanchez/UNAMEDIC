using GalaSoft.MvvmLight.Command;
using Salud.Utils;
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
        private string _txtNombre;
        private string _txtApellidos;
        private string _txtUsuario;
        private string _txtClave;
        private string _txtEmail;
        private string _txtPeso;
        private string _txtAltura;
        private int _txtEdad;
        private string _dtpFechaNacimiento;
        private bool _swtHipertension;
        private bool _swtSangre;
        private bool _swtDiabetes;
        private bool _swtHidratacion;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
        public string txtNombre
        {
            get { return this._txtNombre; }
            set { this.SetValue(ref this._txtNombre, value); } // no solo asigna, también refresca la vista...
        }
        public string txtApellidos
        {
            get { return this._txtApellidos; }
            set { this.SetValue(ref this._txtApellidos, value); } // no solo asigna, también refresca la vista...
        }
        public string txtUsuario
        {
            get { return this._txtUsuario; }
            set { this.SetValue(ref this._txtUsuario, value); } // no solo asigna, también refresca la vista...
        }
        public string txtClave
        {
            get { return this._txtClave; }
            set { this.SetValue(ref this._txtClave, value); } // no solo asigna, también refresca la vista...
        }
        public string txtEmail
        {
            get { return this._txtEmail; }
            set { this.SetValue(ref this._txtEmail, value); } // no solo asigna, también refresca la vista...
        }
        public string txtPeso
        {
            get { return this._txtPeso; }
            set { this.SetValue(ref this._txtPeso, value); } // no solo asigna, también refresca la vista...
        }
        public string txtAltura
        {
            get { return this._txtAltura; }
            set { this.SetValue(ref this._txtAltura, value); } // no solo asigna, también refresca la vista...
        }
        public string dtpFechaNacimiento
        {
            get { return this._dtpFechaNacimiento; }
            set { this.SetValue(ref this._dtpFechaNacimiento, value); } // no solo asigna, también refresca la vista...
        }
        public int txtEdad
        {
            get { return this._txtEdad; }
            set { this.SetValue(ref this._txtEdad, value); } // no solo asigna, también refresca la vista...
        }
        public bool swtHipertension
        {
            get { return this._swtHipertension; }
            set { this.SetValue(ref this._swtHipertension, value); } // no solo asigna, también refresca la vista...
        }
        public bool swtSangre
        {
            get { return this._swtSangre; }
            set { this.SetValue(ref this._swtSangre, value); } // no solo asigna, también refresca la vista...
        }
        public bool swtDiabetes
        {
            get { return this._swtDiabetes; }
            set { this.SetValue(ref this._swtDiabetes, value); } // no solo asigna, también refresca la vista...
        }
        public bool swtHidratacion
        {
            get { return this._swtHidratacion; }
            set { this.SetValue(ref this._swtHidratacion, value); } // no solo asigna, también refresca la vista...
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
            Pacientes pac = new Pacientes();
            pac.nombre = _txtNombre;
            pac.apellidos = _txtApellidos;
            pac.usuario = _txtUsuario;
            pac.clave = _txtClave;
            pac.email = _txtEmail;
            pac.peso = _txtPeso;
            pac.altura = _txtAltura;
            pac.edad = _txtEdad;
            pac.fechaNacimiento = _dtpFechaNacimiento;
            pac.hipertension = swtHipertension;
            pac.sangre = swtSangre;
            pac.diabetes = _swtDiabetes;
            pac.hidratacion = _swtHidratacion;

            
           // Application.Current.MainPage = MainViewModel.GetInstance().appShell;
        }
        #endregion
    }
}
