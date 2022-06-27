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
    /// Логика взаимодействия для CertificatePage.xaml
    /// </summary>
    public partial class CertificatePage : ContentPage
    {
        public ObservableCollection<user3> Marathons { get; set; }
        public RunnerMarathon Run { get; set; }
        Runner runner;
        public CertificatePage(Runner runner)
        {
            this.runner = runner;
            Core.user3Entities context = new Core.user3Entities();
            Marathons = new ObservableCollection<user3>(context.user3.ToArray());
            Run = (mar.SelectedItem as user3).RunnerMarathon.FirstOrDefault(x => x.Runner == runner);
            if(Run == null)
            {
                DisplayAlert("Ошибка","Этот бегун не учавствовал в этом марафоне","ОK");
                Navigation.PopAsync();
            }
            InitializeComponent();
        }

        private void mar_SelectionChanged(object sender, EventArgs e)
        {
            Run = (mar.SelectedItem as user3).RunnerMarathon.FirstOrDefault(x => x.Runner == runner);
            if (Run == null)
            {
                DisplayAlert("Ошибка","Этот бегун не учавствовал в этом марафоне", "OK");
            }
        }
    }
}
