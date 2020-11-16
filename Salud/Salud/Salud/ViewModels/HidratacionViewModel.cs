using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Salud.ViewModels
{
    public class HidratacionViewModel : BaseViewModel
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

        #endregion

        #region  Constructors
        public HidratacionViewModel()
        {

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

        public async void OnMenuItemConfiguraciones()
        {
            DateTime date = Convert.ToDateTime(Fecha);
            if (date != null)
            {
                CalendarViewModel.AgregarDonacion(date.Year, date.Day, date.Month);
            }
        }
        #endregion
    }
}
