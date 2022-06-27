using MarathonApp.Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharityPage.xaml
    /// </summary>
    public partial class CharityPage : ContentPage
    {
        Core.user3Entities context;
        public CharityPage()
        {
            context = new Core.user3Entities();

            InitializeComponent();

            CharityItemsControl.ItemsSource = context.Charity.ToArray();
        }
    }
}
