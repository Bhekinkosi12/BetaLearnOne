using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views.Tools;

namespace BetaLearnOne.Views.LearnView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFLearningPage : ContentPage
    {
        public PDFLearningPage()
        {
            InitializeComponent();
            
        }
        Stream fileStream;
        private bool visible = false;
      



        protected override void OnAppearing()
        {
            base.OnAppearing();
            fileStream = typeof(App).GetType().Assembly.GetManifestResourceStream("BetaLearnOne.Asserts.PhysicalSciencesG12.pdf");
            pdfViewerControl.LoadDocument(fileStream);

        }

        private async void ToolBTN_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CalculatorPage));
            if(visible == false)
            {

            FrameFly.IsVisible = true;
                visible = false;
            }
            else
            {
                FrameFly.IsVisible = false;
                visible = false;
            }
        }
    }
}