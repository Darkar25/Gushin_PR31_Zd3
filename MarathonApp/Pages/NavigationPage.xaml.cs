using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Xamarin.Forms.NavigationPage
    {
        public NavigationPage(int pageNumber)
        {
            InitializeComponent();


            //Проверка выбранной страницы для перехода
            switch (pageNumber)
            {
                case 1:
                    Navigation.PushAsync(new RunnerCheckPage());
                    break;
                case 2:
                    Navigation.PushAsync(new ViewerRegistrationPage());
                    break;
                case 3:
                    Navigation.PushAsync(new Sponsor());
                    break;
                case 4:
                    Navigation.PushAsync(new InfoPage());
                    break;
                case 5:
                    Navigation.PushAsync(new LoginPage());
                    break;
            }

            if (!String.IsNullOrEmpty(Preferences.Get("currentUserEmail", "")) || !String.IsNullOrWhiteSpace(Preferences.Get("currentUserEmail", "")))
            {
                LogOutButton.IsVisible = true;
                Console.WriteLine(Preferences.Get("currentUserEmail", ""));
            }

        }

        public NavigationPage(Page page)
        {
            InitializeComponent();

            this.Navigation.PushAsync(page);

            if (!String.IsNullOrEmpty(Preferences.Get("currentUserEmail", "")) || !String.IsNullOrWhiteSpace(Preferences.Get("currentUserEmail", "")))
            {
                LogOutButton.IsVisible = true;
                Console.WriteLine(Preferences.Get("currentUserEmail", ""));
            }

        }

        /// <summary>
        /// Действия кнопки возврата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        /// <summary>
        /// Кнопка для выхода из своего аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOutButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Preferences.Remove("currentUserEmail");
            this.Navigation.PushAsync(new StartingPage());
        }


    }
}
