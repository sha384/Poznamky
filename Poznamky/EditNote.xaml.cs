using Poznamky.Database;
using Poznamky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poznamky
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {
        private Db db;

        private int id;

        private Note note;

        public EditNote(int note_id)
        {
            db = new Db();
            id = note_id;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            note = db.getById(id)[0];

            name.Text = note.Name;
            text.Text = note.Text;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            db.edit(
                id,
                name.Text,
                text.Text,
                note.Creation_Date
            );

            Navigation.RemovePage(this);
        }
    }
}