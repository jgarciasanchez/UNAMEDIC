using GalaSoft.MvvmLight.Command;
using Microcharts;
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
//Especificar que los entrys son los del nuget
//Using a SkiaSharp para los colores de los gráficos
using SkiaSharp;

namespace Salud.ViewModels
{
    public class DiabetesViewModel : BaseViewModel
    {
        #region Atributes
        private string fecha;
        private TimeSpan hora;
        private string glucosa;
        private string peso;
        private string nota;
        private Chart lineCharts;
        private Chart barCharts;

        List<ChartEntry> entryList;

        private ObservableCollection<Diabetes> _diabetes;
        #endregion

        #region Properties
        public Chart LineCharts
        {
            get { return this.lineCharts; }
            set { this.SetValue(ref this.lineCharts, value); } // no solo asigna, también refresca la vista...
        }
        public Chart BarCharts
        {
            get { return this.barCharts; }
            set { this.SetValue(ref this.barCharts, value); } // no solo asigna, también refresca la vista...
        }
        public string Fecha
        {
            get { return this.fecha; }
            set { this.SetValue(ref this.fecha, value); } // no solo asigna, también refresca la vista...
        }
        public TimeSpan Hora
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
            Borrar();
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
        public void LoadChartEntries()
        {
            this.entryList = new List<ChartEntry>();
            if (this.DiabetesList.Count() < 1)
                return;
            ChartEntry e1 = new ChartEntry(int.Parse(this.DiabetesList[this.DiabetesList.Count-1].Glucosa))
            {
                Label = "A",
                ValueLabel = this.DiabetesList[this.DiabetesList.Count - 1].Glucosa,
                Color = SKColor.Parse("#00bcd4")
            };
            entryList.Add(e1);
            if (this.DiabetesList.Count() < 2)
                return;
            ChartEntry e2 = new ChartEntry(int.Parse(this.DiabetesList[this.DiabetesList.Count - 2].Glucosa))
            {
                Label = "B",
                ValueLabel = this.DiabetesList[this.DiabetesList.Count - 2].Glucosa,
                Color = SKColor.Parse("#F44336")
            };
            entryList.Add(e2);
            if (this.DiabetesList.Count() < 3)
                return;
            ChartEntry e3 = new ChartEntry(int.Parse(this.DiabetesList[this.DiabetesList.Count - 3].Glucosa))
            {
                Label = "C",
                ValueLabel = this.DiabetesList[this.DiabetesList.Count - 3].Glucosa,
                Color = SKColor.Parse("#43A047")
            };
            entryList.Add(e3);
            if (this.DiabetesList.Count() < 4)
                return;
            ChartEntry e4 = new ChartEntry(int.Parse(this.DiabetesList[this.DiabetesList.Count - 4].Glucosa))
            {
                Label = "D",
                ValueLabel = this.DiabetesList[this.DiabetesList.Count - 4].Glucosa,
                Color = SKColor.Parse("#F9A825")
            };
            entryList.Add(e4);
            if (this.DiabetesList.Count() < 5)
                return;
            ChartEntry e5 = new ChartEntry(int.Parse(this.DiabetesList[this.DiabetesList.Count - 5].Glucosa))
            {
                Label = "D",
                ValueLabel = this.DiabetesList[this.DiabetesList.Count - 5].Glucosa,
                Color = SKColor.Parse("#276090")
            };
            entryList.Add(e5);
        }
        public async void LoadDiabetes()
        {
            try
            {
              //  this.IsRefreshing = true; // Se empieza a refrescar
                this.DiabetesList = StaticResources.dataBase.getDiabetes(StaticResources.usuario.id);
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
            diabetes.Hora = this.Hora.ToString();
            diabetes.Peso = this.Peso;
            diabetes.Nota = this.Nota;
            diabetes.PacienteID = StaticResources.usuario.id;
            //    diabetes.PacienteID = Pacientes.ID;
            bool isSave= StaticResources.dataBase.saveDiabetes(diabetes);
            Borrar();
        }
        private void Borrar()
        {
            DateTime dt = DateTime.Now;
            this.Fecha = dt.ToString("MM/dd/yyyy");
            TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            this.Hora = ts;
            this.Peso = "";
            this.Glucosa = "";
            this.Nota = "";
            this.LoadDiabetes();
            this.LoadChartEntries();
            this.LineCharts = new LineChart()
            {
                Entries = entryList
            };
            this.BarCharts = new BarChart()
            {
                Entries = entryList
            };
        }
        #endregion
    }
}
