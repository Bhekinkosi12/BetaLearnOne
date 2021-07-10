using BetaLearnOne.Models;
using BetaLearnOne.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;
using BetaLearnOne.Views.LearnView;
using BetaLearnOne.ViewModels.DocumentVM;
using BetaLearnOne.ViewModels.ExamVM;
using BetaLearnOne.Views.ExamView;

namespace BetaLearnOne.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

      public ItemsViewModel()
        {
          
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            losd();



        }

        async void losd()
        {
            await ExecuteLoadItemsCommand();
        }

        private async void loginCheck()
        {
            try
            {

            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Memory.db");
            var data = new SQLiteConnection(dataPath);

                var table = data.Table<User>();
            }
            catch
            {
                await Shell.Current.DisplayAlert("Alert", "Please Login First", "OK");
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            

        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
           //   await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            await Shell.Current.GoToAsync($"{nameof(PDFLearningPage)}?{nameof(DocumentViewModel.ItemId)}={item.Id}");
           // await Shell.Current.GoToAsync($"{nameof(ExamPage)}?{nameof(ExamViewModel.ItemId)}={item.Id}");
        }
    }
}