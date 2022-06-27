using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoadVolunteersPage.xaml
    /// </summary>
    public partial class LoadVolunteersPage : ContentPage
    {
        public LoadVolunteersPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new VolunteerPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            /*var f = new OpenFileDialog() { Filter = "CSV file|*.csv" };
            if(f.ShowDialog() == DialogResult.OK)
            {
                file.Text = f.FileName;
            }*/
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Core.user3Entities context = new Core.user3Entities();
            StreamReader sr = new StreamReader(file.Text);
            bool flag = false;
            while (!sr.EndOfStream)
            {
                if (flag)
                {
                    string line = sr.ReadLine();
                    if (line == "")
                        break;
                    string[] temp = line.Split(',');
                    context.Volunteer.Add(new Core.Volunteer() { FirstName = temp[1].Trim(), LastName = temp[2].Trim(), CountryCode = temp[3].Trim(), Gender = temp[4].Trim() });
                }
                flag = true;
            }
            sr.Close();
            context.SaveChanges();
        }
    }
}
