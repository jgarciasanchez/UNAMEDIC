using System.ComponentModel;
using Xamarin.Forms;
using Salud.ViewModels;

namespace Salud.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}