using MarathonApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для VolunteerPage.xaml
    /// </summary>
    public partial class VolunteerPage : ContentPage
    {
        Core.user3Entities context;
        public ObservableCollection<Volunteer> Volunteers { get; set; }
        public VolunteerPage()
        {
            context = new user3Entities();
            Volunteers = new ObservableCollection<Volunteer>(context.Volunteer.ToArray());
            InitializeComponent();
            filter.ItemsSource = new string[] { "Email", "Имя", "Фамилия" };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Volunteers.Clear();
            var a = context.Volunteer.AsQueryable();
            switch(filter.SelectedIndex)
            {
                case 0:
                    a = a.OrderBy(x => x.Email);
                    break;
                case 1:
                    a = a.OrderBy(x => x.FirstName);
                    break;
                case 2:
                    a = a.OrderBy(x => x.LastName);
                    break;
            }
            foreach(var v in a.ToArray())
            {
                Volunteers.Add(v);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LoadVolunteersPage());
        }
    }
}
