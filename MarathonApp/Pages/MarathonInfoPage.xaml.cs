using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarathonInfoPage.xaml
    /// </summary>
    public partial class MarathonInfoPage : ContentPage
    {
        public MarathonInfoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на интерактивную карту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InteractiveMap_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MarathonMapPage());
        }
    }
}
