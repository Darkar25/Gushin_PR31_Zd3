using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenuPage.xaml
    /// </summary>
    public partial class RunnerMenuPage : ContentPage
    {
        public RunnerMenuPage()
        {
            InitializeComponent();

            ContactsBorder.IsVisible = false;
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице редактирования профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileEditButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ProfileEditPage());
        }

        /// <summary>
        /// Нажатие на кнопку контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ContactsBorder.IsVisible = true;

        }

        /// <summary>
        /// Нажатие на крестик для закрытие всплывающего окна контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cross_MouseLeftButtonDown(object sender, EventArgs e)
        {

            ContactsBorder.IsVisible = false;
        }

        private void Border_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MySponsorPage());
        }

        private void Border_MouseLeftButtonDown_1(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MyResultsPage());
        }
    }
}
