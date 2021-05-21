using BetaLearnOne.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BetaLearnOne.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void SfCarousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {

        }

        private void SfCarousel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}