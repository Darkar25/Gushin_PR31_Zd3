using MarathonApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerManagmentPage.xaml
    /// </summary>
    public partial class RunnerManagmentPage : ContentPage
    {
        public Registration reg { get; set; }
        public RunnerManagmentPage(Runner run)
        {
            reg = run.Registration.First();
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CertificatePage(reg.Runner));
        }
    }
}
