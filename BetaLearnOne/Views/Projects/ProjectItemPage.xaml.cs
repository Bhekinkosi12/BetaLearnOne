using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaLearnOne.Models.ProjectModel;
using BetaLearnOne.ViewModels.ProjectVM;
using BetaLearnOne.Services.ProjectServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BetaLearnOne.Views.Projects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectItemPage : ContentPage
    {
        public ProjectItemPage()
        {
            InitializeComponent();
        }

        private void preview_Tapped(object sender, EventArgs e)
        {

        }

       

        private void save_Clicked(object sender, EventArgs e)
        {
            FramePreview.IsVisible = true;
            FrameEditor.IsVisible = false;

            save.IsVisible = false;
            delete.IsVisible = false;
            edit.IsVisible = true;
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
            FramePreview.IsVisible = false;
            FrameEditor.IsVisible = true;
            save.IsVisible = true;
            delete.IsVisible = true;
            edit.IsVisible = false;
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            FramePreview.IsVisible = true;
            FrameEditor.IsVisible = false;

            save.IsVisible = false;
            delete.IsVisible = false;
            edit.IsVisible = true;

        }

        private void aims_Tapped(object sender, EventArgs e)
        {
            aimPreview.IsVisible = false;
            aimEdtit.IsVisible = true;
            aimsave.IsVisible = true;
        }

        private void aimsave_Clicked(object sender, EventArgs e)
        {
            aimPreview.IsVisible = true;
            aimEdtit.IsVisible = false;
            aimsave.IsVisible = false;
        }
    }
}