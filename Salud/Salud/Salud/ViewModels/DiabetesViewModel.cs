using GalaSoft.MvvmLight.Command;
using Salud.Models;
using Salud.Utils;
using Salud.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class DiabetesViewModel : BaseViewModel
    {
        #region Atributes
        private string fecha;
        private string hora;
        private string glucosa;
        private string peso;
        private string nota;

        private ObservableCollection<Diabetes> _diabetes;
        #endregion

        #region Properties
        public string Fecha
        {
            get { return this.fecha; }
            set { this.SetValue(ref this.fecha, value); } // no solo asigna, también refresca la vista...
        }
        public string Hora
        {
            get { return this.hora; }
            set { this.SetValue(ref this.hora, value); } // no solo asigna, también refresca la vista...
        }
        public string Glucosa
        {
            get { return this.glucosa; }
            set { this.SetValue(ref this.glucosa, value); } // no solo asigna, también refresca la vista...
        }
        public string Peso
        {
            get { return this.peso; }
            set { this.SetValue(ref this.peso, value); } // no solo asigna, también refresca la vista...
        }
        public string Nota
        {
            get { return this.nota; }
            set { this.SetValue(ref this.nota, value); } // no solo asigna, también refresca la vista...
        }
        public ObservableCollection<Diabetes> diabetes
        {
            get { return this._diabetes; }
            set { this.SetValue(ref this._diabetes, value); } // no solo asigna, también refresca la vista...
        }

        public List<Diabetes> DiabetesList { get; set; }
        #endregion

        #region  Constructors
        public DiabetesViewModel()
        {
            this.LoadDiabetes();
        }
        #endregion

        #region Commands
        public ICommand GuardarCommand
        {
            get
            {
                return new RelayCommand(Guardar);
            }
        }
        public ICommand BorrarCommand
        {
            get
            {
                return new RelayCommand(Borrar);
            }
        }
        #endregion

        #region Methods
        public async void LoadDiabetes()
        {
            try
            {
              //  this.IsRefreshing = true; // Se empieza a refrescar
                this.DiabetesList = StaticResources.dataBase.getDiabetes();
                this.RefreshList();
              //  this.IsRefreshing = false;
                return;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al cargar historial","Aceptar");
            }
        }
        private void RefreshList()
        {
            this.diabetes = new ObservableCollection<Diabetes>(DiabetesList.OrderByDescending(c => c.ID));
        }

        private async void Guardar()
        {
            if (String.IsNullOrEmpty(this.Peso) || String.IsNullOrEmpty(this.Glucosa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes llenar los campos requeridos","Aceptar");
                return;
            }
            Diabetes diabetes = new Diabetes();
            diabetes.Fecha = this.Fecha;
            diabetes.Glucosa = this.Glucosa;
            diabetes.Hora = this.Hora;
            diabetes.Peso = this.Peso;
            diabetes.Nota = this.Nota;
            //    diabetes.PacienteID = Pacientes.ID;
            bool isSave= StaticResources.dataBase.saveDiabetes(diabetes);
            this.LoadDiabetes();
        }
        private void Borrar()
        {
            this.Peso = "";
            this.Glucosa = "";
            this.Nota = "";
        }
        #endregion
    }
}
