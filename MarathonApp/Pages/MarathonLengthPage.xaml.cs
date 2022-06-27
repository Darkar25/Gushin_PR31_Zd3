using MarathonApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarathonLengthPage.xaml
    /// </summary>
    public partial class MarathonLengthPage : ContentPage
    {
        user3Entities context;

        public HowLong hl { get; set; }
        public MarathonLengthPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();
            spid.ItemsSource = context.HowLong.Where(x => x.Id <= 7).ToList();
            dist.ItemsSource = context.HowLong.Where(x => x.Id > 7).ToList();
        }

        private void spid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hl = (sender as ListView).SelectedItem as HowLong;
            OnPropertyChanged(nameof(hl));
        }
    }
}
