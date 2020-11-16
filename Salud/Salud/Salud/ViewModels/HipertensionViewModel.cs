using GalaSoft.MvvmLight.Command;
using Microcharts;
using Salud.Models;
using Salud.Utils;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class HipertensionViewModel : BaseViewModel
    {
        #region Attributes //Aquí van los propieades que serán modificadas en el controlador 
        //Atributos de LoginPage
        private string _diastolica;
        private string _sistolica;
        private string _pulso;
        private TimeSpan hora;
        private string fecha;
        private string nota;
        private Chart lineCharts;
        private Chart barCharts;

        List<ChartEntry> entryList;

        private ObservableCollection<Hipertension> _hipertension;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
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
        public string picSistolico
        {
            get { return this._sistolica; }
            set
            {
                calcular(int.Parse(value), int.Parse(this.picDiastolico));
                this.SetValue(ref this._sistolica, value);
            } // no solo asigna, también refresca la vista...
        }
        public string picDiastolico
        {
            get { return this._diastolica; }
            set { this.SetValue(ref this._diastolica, value); } // no solo asigna, también refresca la vista...
        }
        public string picPulso
        {
            get { return this._pulso; }
            set { this.SetValue(ref this._pulso, value); } // no solo asigna, también refresca la vista...
        }
        public TimeSpan Hora
        {
            get { return this.hora; }
            set { this.SetValue(ref this.hora, value); } // no solo asigna, también refresca la vista...
        }
        public string Fecha
        {
            get { return this.fecha; }
            set { this.SetValue(ref this.fecha, value); } // no solo asigna, también refresca la vista...
        }
        public string Nota
        {
            get { return this.nota; }
            set { this.SetValue(ref this.nota, value); } // no solo asigna, también refresca la vista...
        }

        public ObservableCollection<Hipertension> hipertension
        {
            get { return this._hipertension; }
            set { this.SetValue(ref this._hipertension, value); } // no solo asigna, también refresca la vista...
        }

        public List<Hipertension> HipertensionList { get; set; }

        #endregion

        #region  Constructors
        public HipertensionViewModel()
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
            if (this.HipertensionList.Count() < 1)
                return;
            ChartEntry e1 = new ChartEntry(int.Parse(this.HipertensionList[this.HipertensionList.Count - 1].picDiastolico))
            {
                Label = "A",
                ValueLabel = this.HipertensionList[this.HipertensionList.Count - 1].picDiastolico,
                Color = SKColor.Parse("#00bcd4")
            };
            entryList.Add(e1);
            if (this.HipertensionList.Count() < 2)
                return;
            ChartEntry e2 = new ChartEntry(int.Parse(this.HipertensionList[this.HipertensionList.Count - 2].picDiastolico))
            {
                Label = "B",
                ValueLabel = this.HipertensionList[this.HipertensionList.Count - 2].picDiastolico,
                Color = SKColor.Parse("#F44336")
            };
            entryList.Add(e2);
            if (this.HipertensionList.Count() < 3)
                return;
            ChartEntry e3 = new ChartEntry(int.Parse(this.HipertensionList[this.HipertensionList.Count - 3].picDiastolico))
            {
                Label = "C",
                ValueLabel = this.HipertensionList[this.HipertensionList.Count - 3].picDiastolico,
                Color = SKColor.Parse("#43A047")
            };
            entryList.Add(e3);
            if (this.HipertensionList.Count() < 4)
                return;
            ChartEntry e4 = new ChartEntry(int.Parse(this.HipertensionList[this.HipertensionList.Count - 4].picDiastolico))
            {
                Label = "D",
                ValueLabel = this.HipertensionList[this.HipertensionList.Count - 4].picDiastolico,
                Color = SKColor.Parse("#F9A825")
            };
            entryList.Add(e4);
            if (this.HipertensionList.Count() < 5)
                return;
            ChartEntry e5 = new ChartEntry(int.Parse(this.HipertensionList[this.HipertensionList.Count - 5].picDiastolico))
            {
                Label = "D",
                ValueLabel = this.HipertensionList[this.HipertensionList.Count - 5].picDiastolico,
                Color = SKColor.Parse("#276090")
            };
            entryList.Add(e5);
        }
        public async void LoadHipertension()
        {
            try
            {
                this.HipertensionList = StaticResources.dataBase.getHipertension(StaticResources.usuario.id);
                this.RefreshList();
                return;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al cargar historial", "Aceptar");
            }
        }
        private void RefreshList()
        {
            this.hipertension = new ObservableCollection<Hipertension>(HipertensionList.OrderByDescending(c => c.ID));
        }

        public string calcular(int sis, int dis)
        {
            if (sis > 160 || dis > 100)
            {
                return "Red";
            }
            else if (sis >= 141 || dis >= 91)
            {
                return "Orange";
            }
            else if (sis >= 121 || dis >= 81)
            {
                return "Yellow";
            }
            else if (sis >= 91 || dis >= 61)
            {
                return "Green";
            }
            else 
            {
                return "LightBlue";
            }
        }
        private async void Guardar()
        {
            
            Hipertension hipertension = new Hipertension();
            hipertension.Fecha = this.Fecha;
            hipertension.Hora = this.Hora.ToString();
            hipertension.Nota = this.Nota;
            hipertension.picSistolico = this.picSistolico;
            hipertension.picDiastolico = this.picDiastolico;
            hipertension.picPulso = this.picPulso;
            hipertension.Color = calcular(int.Parse(this.picSistolico), int.Parse(this.picDiastolico));
            hipertension.PacienteID = StaticResources.usuario.id;
            //    diabetes.PacienteID = Pacientes.ID;
            bool isSave = StaticResources.dataBase.saveHipertension(hipertension);
            Borrar();
        }

        private void Borrar()
        {
            DateTime dt = DateTime.Now;
            this.Fecha = dt.ToString("MM/dd/yyyy");
            TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            this.Hora = ts;
            this.picDiastolico = "60";
            this.picSistolico = "100";
            this.picPulso = "60";
            this.LoadHipertension();
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
