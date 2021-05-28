using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using BetaLearnOne.Services.DocumentData;
using Xamarin.Forms;
using System.Diagnostics;

namespace BetaLearnOne.ViewModels.DocumentVM
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class DocumentViewModel : BaseViewModel
    {
        private string documentName;
        private string topic;
        private int startPage;
        private string itemId;
        DocumentDataStore dataStore = new DocumentDataStore();
        private Stream pdfDocument;
         

        public DocumentViewModel()
        {
           // DataAccess();



            //accesing the pdf

        //  pdfDocument = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("BetaLearnOne.Asserts.PhysicalSciencesG12.pdf");



        }
     


        

        public string Id { get; set; }


        public string ItemId
        {
            get => itemId;
            set
            {
                SetProperty(ref itemId, value);
                LoadItemId(value);
                OnPropertyChanged(nameof(ItemId));
            }
        }
         
        public Stream PdfDocumnet
        {
            get => pdfDocument;
            set
            {
                SetProperty(ref pdfDocument, value);
                OnPropertyChanged(nameof(PdfDocumnet));
            }
        }

        public string DocumentName
        {
            get => documentName;
            set
            {
                SetProperty(ref documentName, value);
                OnPropertyChanged(nameof(DocumentName));

            }
        }
        public string Topic
        {
            get => topic;
            set
            {
                SetProperty(ref topic, value);
                OnPropertyChanged(nameof(Topic));
            }
        }
        public int StartPage
        {
            get => startPage;
            set
            {
                SetProperty(ref startPage, value);
                OnPropertyChanged(nameof(StartPage));
            }
        }





        private async void DataAccess()
        {
            try
            {


          var item =  dataStore.ReturnOneDocument();

            DocumentName = item.PdfDocument;
            Topic = item.Topic;
            StartPage = item.StartPage;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "Could not load pdf", "OK");
            }


        }







        public async void LoadItemId(string itemId)
        {
            try
            {
               


                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                PdfDocumnet = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream($"BetaLearnOne.Asserts.{item.Document}");



            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
