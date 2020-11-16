using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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
        private string _hora;

        //Controller

        #endregion

        #region Properties //Aquí van los elementos desde la vista bindeados
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
        public string Hora
        {
            get { return this._hora; }
            set { this.SetValue(ref this._hora, value); } // no solo asigna, también refresca la vista...
        }

        #endregion

        #region  Constructors
        public HipertensionViewModel()
        {
            picDiastolico = "60";
            picSistolico = "100";
            picPulso = "60";

            var src = DateTime.Now;
            
            Hora = "05" + ":" + src.Minute;
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
        #endregion

        #region Methods
        public void calcular(int sis, int dis)
        {
            if (sis < 90 || dis < 60)
            {
            }
            else if (sis < 90 || dis < 60)
            {
            }
            else if (sis < 90 || dis < 60)
            {
            }
            else if (sis < 90 || dis < 60)
            {
            }
            else if (sis < 90 || dis < 60)
            {
            }
        }

        public async void OnMenuItemConfiguraciones()
        {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage()); //Para una pantalla modal
            // await Shell.Current.GoToAsync(nameof(HipertensionTabbedPage)); //Para llamar otra vista
        }
        #endregion
    }
}
