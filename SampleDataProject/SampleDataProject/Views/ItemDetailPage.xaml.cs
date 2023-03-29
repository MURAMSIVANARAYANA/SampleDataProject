using SampleDataProject.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleDataProject.Views
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