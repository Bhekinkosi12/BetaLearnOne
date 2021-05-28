using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetaLearnOne.Views.Popups.CalendarPop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetDatePopup : Popup  
    {
        public SetDatePopup()
        {
            InitializeComponent();
        }
    }
}