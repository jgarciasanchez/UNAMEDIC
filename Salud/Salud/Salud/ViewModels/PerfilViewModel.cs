using GalaSoft.MvvmLight.Command;
using Salud.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class PerfilViewModel : BaseViewModel
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
        private int _sexo;
        private string _dtpFechaNacimiento;

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
        public int Sexo
        {
            get { return this._sexo; }
            set { this.SetValue(ref this._sexo, value); } // no solo asigna, también refresca la vista...
        }


        #endregion

        #region  Constructors
        public PerfilViewModel()
        {
            Pacientes pac = StaticResources.usuario;
            txtNombre = pac.nombre;
            txtApellidos = pac.apellidos;
            txtUsuario = pac.usuario;
            txtClave = pac.clave;
            txtEmail = pac.email;
            txtPeso = pac.peso;
            txtAltura = pac.altura;
            Sexo = pac.sexo;
            dtpFechaNacimiento = pac.fechaNacimiento;
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
        public async void OnSingInClicked()
        {
            Pacientes pac = StaticResources.usuario;
            pac.nombre = txtNombre;
            pac.apellidos = txtApellidos;
            pac.usuario = txtUsuario;
            pac.clave = txtClave;
            pac.email = txtEmail;
            pac.peso = txtPeso;
            pac.altura = txtAltura;
            pac.sexo = Sexo;
            pac.fechaNacimiento = dtpFechaNacimiento;

            List<String> isAnyEmpty = new List<string>();
            if (String.IsNullOrEmpty(txtAltura) || String.IsNullOrEmpty(txtNombre) || String.IsNullOrEmpty(txtApellidos) || String.IsNullOrEmpty(txtUsuario)
                || String.IsNullOrEmpty(txtClave) || String.IsNullOrEmpty(txtEmail) || String.IsNullOrEmpty(txtPeso) || String.IsNullOrEmpty(dtpFechaNacimiento))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes llenar todos los campos", "Aceptar");
                return;
            }
            
            if (StaticResources.dataBase.getPacienteByUsuario(txtUsuario) != null)
            {
                if (StaticResources.dataBase.getPacienteByUsuario(txtUsuario).id != StaticResources.usuario.id)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Nombre de usuario ocupado", "Aceptar");
                    return;
                }
            }
            bool isSave = StaticResources.dataBase.updatePacientes(pac);

            StaticResources.usuario = StaticResources.dataBase.getPacienteByUsuario(txtUsuario);

            if (isSave)
            {
                await Application.Current.MainPage.DisplayAlert("Info", "Informacion Actualizada", "Aceptar");
                return;
            }
        }
        #endregion
    }
}
