using GalaSoft.MvvmLight.Command;
using Salud.Models;
using Salud.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public class HidratacionViewModel : BaseViewModel
    {
        #region Attributes //Aquí van los propieades que serán modificadas en el controlador 
        //Atributos de LoginPage
        private string fecha;
        private int consumoDiario;
        private int consumoIdeal;
        private string gota;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
        public string Fecha
        {
            get { return this.fecha; }
            set { this.SetValue(ref this.fecha, value); } // no solo asigna, también refresca la vista...
        }
        public string Gota
        {
            get { return this.gota; }
            set { this.SetValue(ref this.gota, value); } // no solo asigna, también refresca la vista...
        }
        public int ConsumoIdeal
        {
            get { return this.consumoIdeal; }
            set { this.SetValue(ref this.consumoIdeal, value); } // no solo asigna, también refresca la vista...
        }
        public int ConsumoDiario
        {
            get { return this.consumoDiario; }
            set { this.SetValue(ref this.consumoDiario, value); } // no solo asigna, también refresca la vista...
        }


        public List<Hidratacion> HidratacionList { get; set; }

        #endregion

        #region  Constructors
        public HidratacionViewModel()
        {
            decimal peso = Convert.ToDecimal(StaticResources.usuario.peso);
            decimal canti = peso / 7;
            consumoIdeal = Convert.ToInt32(canti * 250);
            Gota = "gota";
            loadHidratacion();
        }
        #endregion

        #region Commands

        public ICommand Agregar100
        {
            get
            {
                return new RelayCommand(agregarAgua100);
            }
        }

        public ICommand Agregar300
        {
            get
            {
                return new RelayCommand(agregarAgua300);
            }
        }
        public ICommand Agregar600
        {
            get
            {
                return new RelayCommand(agregarAgua600);
            }
        }

        public ICommand Agregar800
        {
            get
            {
                return new RelayCommand(agregarAgua800);
            }
        }


        #endregion

        #region Methods

        public void agregarAgua100()
        {
            agregarAgua(100);
        }
        public void agregarAgua300()
        {
            agregarAgua(300);
        }
        public void agregarAgua600()
        {
            agregarAgua(600);
        }
        public void agregarAgua800()
        {
            agregarAgua(800);
        }


        public void agregarAgua(int agua)
        {
            if (HidratacionList != null)
            {
                foreach (Hidratacion item in HidratacionList)
                {
                    DateTime date = Convert.ToDateTime(item.Fecha);
                    if (date.Date == DateTime.Now.Date)
                    {
                        item.Total = item.Total + agua;
                        if (StaticResources.dataBase.updateHidratacion(item))
                        {
                            this.HidratacionList.Clear();
                            loadHidratacion();
                            return;
                        }
                    }
                }
            }

            Hidratacion h = new Hidratacion();
            h.Fecha = DateTime.Now.ToString();
            h.Total = agua;
            h.PacienteID = StaticResources.usuario.id;
            StaticResources.dataBase.saveHidratacion(h);
            loadHidratacion();
        }


        public async void loadHidratacion()
        {
            bool band = true;
            try
            {
                this.HidratacionList = StaticResources.dataBase.getHidratacion(StaticResources.usuario.id);

                foreach (Hidratacion item in HidratacionList)
                {
                    DateTime date = Convert.ToDateTime(item.Fecha);
                    if (date != null)
                    {
                        if (date.Date == DateTime.Now.Date)
                        {
                            ConsumoDiario = item.Total;

                            decimal a = decimal.Divide(100, ConsumoIdeal);
                            int porc = Convert.ToInt32(a*ConsumoDiario);
                            if (porc == 0)
                            {
                                Gota = "gota";
                            } else if(porc < 25)
                            {
                                Gota = "gota1";
                            }
                            else if (porc < 50)
                            {
                                Gota = "gota2";
                            }
                            else if (porc < 75)
                            {
                                Gota = "gota3";
                            } else
                            {
                                Gota = "gota4";
                            }
                        }

                        if (CalendarViewModel.CalendarInlineEventsWater.Count > 0 && band)
                        {
                            CalendarViewModel.CalendarInlineEventsWater.Clear();
                            band = false;
                        }
                        CalendarViewModel.AgregarAgua(date.Year, date.Day, date.Month, item.Total);
                    }
                }

                return;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al cargar historial", "Aceptar");
            }
        }


        #endregion
    }
}
