using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite;
using GetApiApp.Models;

namespace GetApiApp
{
    public partial class SavedPosts : ContentPage
    {
        public SavedPosts()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //! added using SQLite;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //! added using XamarinNotesApp.Models;
                conn.CreateTable<Photos>();
                List<Photos> notes = conn.Table<Photos>().ToList();
                Saved_Post_List.ItemsSource = notes;
            }
        }

    }
}
