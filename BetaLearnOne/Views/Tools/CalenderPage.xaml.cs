using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetaLearnOne.Views.Tools
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalenderPage : ContentPage
    {
        DateTime currentDate;
        public CalenderPage()
        {
            InitializeComponent();
        }

        private void monthView_Clicked(object sender, EventArgs e)
        {
            monthView.BackgroundColor = Color.Blue;
            yearView.BackgroundColor = Color.FromHex("#2193b0");
            decateView.BackgroundColor = Color.FromHex("#2193b0");
            centuryView.BackgroundColor = Color.FromHex("#2193b0");

            calenderControl.ViewMode = Syncfusion.SfCalendar.XForms.ViewMode.MonthView;
 
        }

        private void yearView_Clicked(object sender, EventArgs e)
        {
            monthView.BackgroundColor = Color.FromHex("#2193b0");
            yearView.BackgroundColor = Color.Blue;
            decateView.BackgroundColor = Color.FromHex("#2193b0");
            centuryView.BackgroundColor = Color.FromHex("#2193b0");
            calenderControl.ViewMode = Syncfusion.SfCalendar.XForms.ViewMode.YearView;

        }

        private void decateView_Clicked(object sender, EventArgs e)
        {
            monthView.BackgroundColor = Color.FromHex("#2193b0");
            yearView.BackgroundColor = Color.FromHex("#2193b0");
            decateView.BackgroundColor = Color.Blue;
            centuryView.BackgroundColor = Color.FromHex("#2193b0");
            calenderControl.ViewMode = Syncfusion.SfCalendar.XForms.ViewMode.Decade;
        }

        private void centuryView_Clicked(object sender, EventArgs e)
        {
            monthView.BackgroundColor = Color.FromHex("#2193b0");
            yearView.BackgroundColor = Color.FromHex("#2193b0");
            decateView.BackgroundColor = Color.FromHex("#2193b0");
            centuryView.BackgroundColor = Color.Blue;
            calenderControl.ViewMode = Syncfusion.SfCalendar.XForms.ViewMode.Century;
        }
    }
}