using GalaSoft.MvvmLight.Command;
using Salud.Utils;
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
        private string title;
        private string nombre;
        private string fechaNacimiento;
        private string sexo;
        private string imc;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
        public string Title
        {
            get { return this.title; }
            set { this.SetValue(ref this.title, value); } // no solo asigna, también refresca la vista...
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.SetValue(ref this.nombre, value); } // no solo asigna, también refresca la vista...
        }
        public string FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.SetValue(ref this.fechaNacimiento, value); } // no solo asigna, también refresca la vista...
        }
        public string Sexo
        {
            get { return this.sexo; }
            set { this.SetValue(ref this.sexo, value); } // no solo asigna, también refresca la vista...
        }
        public string IMC
        {
            get { return this.imc; }
            set { this.SetValue(ref this.imc, value); } // no solo asigna, también refresca la vista...
        }

        #endregion

        #region  Constructors
        public MenuViewModel()
        {
            this.Title = StaticResources.usuario.nombre + " " + StaticResources.usuario.apellidos;
            Nombre = StaticResources.usuario.nombre;
            FechaNacimiento = Convert.ToDateTime(StaticResources.usuario.fechaNacimiento).Date.ToString("d");
            if (StaticResources.usuario.sexo == 0)
            {
                Sexo = "Femenino";
            }
            else if (StaticResources.usuario.sexo == 1)
            {
                Sexo = "Masculino";
            }
            else
            {
                Sexo = "Otro";
            }
            
            decimal imcValor = decimal.Divide(Convert.ToDecimal(StaticResources.usuario.altura), Convert.ToDecimal(StaticResources.usuario.peso));
            IMC = (imcValor*10).ToString("##.##");
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
            MainViewModel.GetInstance().Hidratacion = new HidratacionViewModel();
            await Shell.Current.GoToAsync(nameof(HidratacionTabbedPage));
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
            MainViewModel.GetInstance().Perfil = new PerfilViewModel();
            await Shell.Current.GoToAsync(nameof(PerfilPage));
        }
        #endregion
    }
}
