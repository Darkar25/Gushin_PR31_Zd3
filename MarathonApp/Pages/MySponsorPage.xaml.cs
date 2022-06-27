using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MySponsorPage.xaml
    /// </summary>
    public partial class MySponsorPage : ContentPage
    {
        Core.user3Entities context;
        Core.Runner currentRunner;
        Core.User currentUser;

        public ObservableCollection<MarathonApp.Core.Sponsor> Sponsors { get; set; } = new ObservableCollection<MarathonApp.Core.Sponsor>();
        public decimal Total => Sponsors.Sum(x => x.Amount);
        public Core.Sponsor DisplaySponsor { get; set; }
        public MySponsorPage()
        {
            context = new Core.user3Entities();
            var email = Preferences.Get("currentUserEmail", "");
            currentRunner = context.Runner.Where(x => x.Email == email).First();
            currentUser = context.User.Where(x => x.Email == email).First();
            foreach (var s in currentRunner.Sponsor)
                Sponsors.Add(s);
            if(Sponsors.Any())
                DisplaySponsor = Sponsors[new Random().Next(0, Sponsors.Count)];
            InitializeComponent();

        }
    }
}
