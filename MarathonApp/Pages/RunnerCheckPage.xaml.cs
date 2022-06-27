using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerCheckPage.xaml
    /// </summary>
    public partial class RunnerCheckPage : ContentPage
    {
        public RunnerCheckPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переход на страницу регистрации бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewRunner_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RunnerRegistrationPage());
        }

        /// <summary>
        /// Нажатие на кнопку старого бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOldRunner_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LoginPage());
        }
    }
}
