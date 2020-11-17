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
    public class SangreViewModel : BaseViewModel
    {
        #region Attributes //Aquí van los propieades que serán modificadas en el controlador 
        //Atributos de LoginPage
        private string fecha;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
        public string Fecha
        {
            get { return this.fecha; }
            set { this.SetValue(ref this.fecha, value); } // no solo asigna, también refresca la vista...
        }
        public List<Sangre> DonacionesList { get; set; }

        #endregion

        #region  Constructors
        public SangreViewModel()
        {
            loadDonaciones();
        }
        #endregion

        #region Commands
        public ICommand AgregarDonacion
        {
            get
            {
                return new RelayCommand(OnMenuItemConfiguraciones);
            }
        }
        #endregion

        #region Methods

        public async void loadDonaciones()
        {
            bool band = true;
            try
            {
                DonacionesList = StaticResources.dataBase.getDonaciones(StaticResources.usuario.id);

                foreach (Sangre item in DonacionesList)
                {
                    DateTime date = Convert.ToDateTime(item.Fecha);
                    if (date != null)
                    {

                        if (CalendarViewModel.CalendarInlineEvents.Count > 0 && band)
                        {
                            CalendarViewModel.CalendarInlineEvents.Clear();
                            band = false;
                        }
                        CalendarViewModel.AgregarDonacion(date.Year, date.Day, date.Month);
                    }
                }

                return;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al cargar historial", "Aceptar");
            }
        }

        public async void OnMenuItemConfiguraciones()
        {
            bool band = true;
            DonacionesList = StaticResources.dataBase.getDonaciones(StaticResources.usuario.id);
            if (DonacionesList != null)
            {
                foreach (Sangre item in DonacionesList)
                {
                    if (Convert.ToDateTime(Fecha).Date == Convert.ToDateTime(item.Fecha).Date)
                    {
                        band = false;
                    }
                }
            }
            if (band)
            {
                DateTime date = Convert.ToDateTime(Fecha);
                if (date != null)
                {
                    Sangre s = new Sangre();
                    s.Fecha = date.ToString();
                    s.PacienteID = StaticResources.usuario.id;
                    StaticResources.dataBase.saveDonacion(s);
                    CalendarViewModel.AgregarDonacion(date.Year, date.Day, date.Month);
                }
            }

        }
        #endregion
    }
}
