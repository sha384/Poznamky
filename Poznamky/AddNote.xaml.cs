using Poznamky.Database;
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
    public partial class AddNote : ContentPage
    {
        private Db db;

        public AddNote()
        {
            db = new Db();
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            db.add(
                name.Text,
                text.Text
            );

            Navigation.RemovePage(this);
        }
    }
}