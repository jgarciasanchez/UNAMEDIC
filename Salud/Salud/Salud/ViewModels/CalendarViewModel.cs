using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Salud.ViewModels
{
    public static class CalendarViewModel
    {
        public static CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public static CalendarEventCollection CalendarInlineEventsWater { get; set; } = new CalendarEventCollection();

        static CalendarViewModel()
        {

        }

        public static void AgregarDonacion(int ano, int day, int mes)
        {
            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(ano, mes, day, 10, 0, 0);
            event2.EndTime = new DateTime(ano, mes, day, 12, 0, 0);
            event2.Subject = "Donación";
            event2.Color = Color.Red;
            CalendarInlineEvents.Add(event2);
        }

        public static void AgregarAgua(int ano, int day, int mes, int agua)
        {
            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(ano, mes, day, 10, 0, 0);
            event2.EndTime = new DateTime(ano, mes, day, 12, 0, 0);
            event2.Subject = "Agua consumida: " + agua + "mL";
            event2.Color = Color.Aqua;
            CalendarInlineEventsWater.Add(event2);
        }
    }
}
