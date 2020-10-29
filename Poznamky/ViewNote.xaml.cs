using Poznamky.Database;
using Poznamky.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poznamky
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        private int id;

        private Db db;

        public ViewNote(int note_id)
        {
            id = note_id;
            db = new Db();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Note note = db.getById(id)[0];

            name.Text = note.Name;
            creation_date.Text = "Datum vytvoření: " + note.Creation_Date.ToString("dd.MM.yyyy HH:mm");

            if (note.Edit_Date.HasValue)
            {
                edit_date.Text = "Datum poslední úpravy: " + note.Edit_Date.Value.ToString("dd.MM.yyyy HH:mm");
            }

            text.Text = note.Text;
        }

        private void edit_button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNote (id));
        }

        private void delete_button(object sender, EventArgs e)
        {
            db.delete(id);

            Navigation.RemovePage(this);
        }
    }
}