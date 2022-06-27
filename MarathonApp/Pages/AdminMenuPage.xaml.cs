using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : ContentPage
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка перехода к Управлению пользователями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new UserManagementPage());
        }

        private void VolunteersButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new VolunteerPage());
        }
    }
}
