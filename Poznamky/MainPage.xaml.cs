using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Poznamky.Database;
using Poznamky.Model;

namespace Poznamky
{
    public partial class MainPage : ContentPage
    {
        private Db db;

        public MainPage()
        {
            db = new Db();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = db.getAll();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNote ());    
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Note note = (Note)e.SelectedItem;

            Navigation.PushAsync(new ViewNote(note.ID));
        }
    }
}
