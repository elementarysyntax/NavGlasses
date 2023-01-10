using NavGlasses.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NavGlasses.Views
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