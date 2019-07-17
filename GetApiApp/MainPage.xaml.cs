using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using GetApiApp.Models;
using SQLite;


namespace GetApiApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private const string url = "https://jsonplaceholder.typicode.com/photos";
        private HttpClient _Client = new HttpClient();

        protected override async void OnAppearing()
        {
            //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            var content = await _Client.GetStringAsync(url);
            //Deserializes or converts JSON String into a collection of Post
            List<Photos> posts = JsonConvert.DeserializeObject<List<Photos>>(content);
            //Assigning the ObservableCollection to MyListView in the XAML of this file
            Post_List.ItemsSource = posts;
            base.OnAppearing();
        }

        private void FavToolbarItem_Clicked(Object sender,EventArgs e)
        {
           Navigation.PushAsync(new SavedPosts());
        }

        private void Posts_listView_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
           

         var PostSelected = e.SelectedItem as Photos;
         Photos post = new Photos()
            {
                albumId = PostSelected.albumId,
                id = PostSelected.id,
                title = PostSelected.title,
                url = PostSelected.url,
                thumbnailUrl = PostSelected.thumbnailUrl

         };

            //if (e.SelectedItem != null)
            //{
            //    DisplayAlert("Tapped", PostSelected.title, "OK");
            //}

            //! added using SQLite;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Photos>();
                int itemsInserted = conn.Insert(post);

                if (itemsInserted > 0)
                    DisplayAlert("Done", "Note saved", "Ok");
                else
                    DisplayAlert("Error", "Note not saved", "Ok");
            }
        }

    }
}

