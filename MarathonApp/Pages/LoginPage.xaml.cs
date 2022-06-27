using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : ContentPage
    {
        private int WrongTypes = 0;
        private int timeValue;
        Core.user3Entities context;
        public LoginPage()
        {
            InitializeComponent();
            timeValue = 60;
            TimerEntry.Text = String.Format("До конца болокировки осталось {0} секунд", timeValue);
            context = new Core.user3Entities();
            CaptchaRenderer();
        }

        public void StartBlockTimer() {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                timeValue--;
                Device.BeginInvokeOnMainThread(() =>
                {
                    TimerEntry.Text = String.Format("До конца блокировки осталось {0} секунд", timeValue);
                });
                if (timeValue < 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        EmailEntry.IsEnabled = true;
                        PasswordEntry.IsEnabled = true;
                        LoginButton.IsEnabled = true;
                        CapchaEntry.IsEnabled = true;

                        TimerEntry.IsVisible = false;
                    });
                    return false;
                }

                return true; // runs again, or false to stop
            });
        }

        /// <summary>
        /// Авторизация при нажатии на кнопку Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (CapchaEntry.Text == CapchaEntry.Text)
            {
                int currentUserExisting = CheckUserData();
                if (currentUserExisting != 0)
                {
                    var currentUser = context.User.Where(x => x.Email == EmailEntry.Text && x.Password == PasswordEntry.Text).First();
                    WrongTypes = 0;
                    Preferences.Set("currentUserEmail", currentUser.Email);
                    switch (currentUser.RoleId)
                    {
                        case 1:
                            this.Navigation.PushAsync(new RunnerMenuPage());
                            break;
                        case 2:
                            this.Navigation.PushAsync(new CoordinatorMenuPage());
                            break;
                        case 3:
                            this.Navigation.PushAsync(new ViewerMenuPage());
                            break;
                        case 4:
                            this.Navigation.PushAsync(new AdminMenuPage());
                            break;
                    }
                }
                else
                {
                    DisplayAlert("Ошибка","Неправильно введён логин и/или пароль.","OK");
                    if (WrongTypes < 2)
                    {
                        WrongTypes++;
                        int remainingChances = 3 - WrongTypes;
                        CaptchaRenderer();
                    }
                    else
                    {
                        StartBlockTimer();
                        TimerEntry.IsVisible = true;
                        DisplayAlert("Неверная капча", "Вы неверно ввели данные пользователя и исчерпали лимит.\nДоступ заблокирован на одну минуту", "OK");
                        EmailEntry.IsEnabled = false;
                        PasswordEntry.IsEnabled = false;
                        LoginButton.IsEnabled = false;
                        CapchaEntry.IsEnabled = false;
                    }
                }
            }
            else
            {
                DisplayAlert("Неверная капча","Капча введена неверно","OK");
                if (WrongTypes < 2)
                {
                    WrongTypes++;
                    int remainingChances = 3 - WrongTypes;
                    CaptchaRenderer();
                }
                else
                {
                    StartBlockTimer();
                    TimerEntry.IsVisible = true;
                    DisplayAlert("Неверная капча","Вы неверно ввели данные пользователя и исчерпали лимит.\nДоступ заблокирован на одну минуту","OK");
                    EmailEntry.IsEnabled = false;
                    PasswordEntry.IsEnabled = false;
                    LoginButton.IsEnabled = false;
                    CapchaEntry.IsEnabled = false;
                }
            }
        }

        private int CheckUserData()
        {
            return context.User.Where(x => x.Email == EmailEntry.Text && x.Password == PasswordEntry.Text).Count();
        }

        /// <summary>
        /// Нажатие на кнопку Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        /// <summary>
        /// Создание капчи
        /// </summary>
        void CaptchaRenderer()
        {
            Random rnd = new Random();
            string textCapcha = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                textCapcha += ALF[rnd.Next(ALF.Length)];
            CapchaLabel.Text = textCapcha;
            CapchaLabel.Rotation = rnd.Next(20) - 10;
        }

        /// <summary>
        /// Кнопка для разработчика чтобы войти под бегуном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugRunnerButton_Clicked(object sender, EventArgs e)
        {
            CapchaEntry.Text = CapchaLabel.Text;
            EmailEntry.Text = "asd";
            PasswordEntry.Text = "as";
        }

        /// <summary>
        /// Кнопка для разработчика чтобы войти под координатором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugCoordinatorButton_Clicked(object sender, EventArgs e)
        {
            CapchaEntry.Text = CapchaLabel.Text;
            EmailEntry.Text = "coorginator@ya.ru";
            PasswordEntry.Text = "Pass";

        }

        /// <summary>
        /// Кнопка для разработчика чтобы войти под зрителем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugViewerButton_Clicked(object sender, EventArgs e)
        {
            CapchaEntry.Text = CapchaLabel.Text;
            EmailEntry.Text = "a";
            PasswordEntry.Text = "a";

        }

        /// <summary>
        /// Кнопка для разработчика чтобы войти под администратором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugAdminButton_Clicked(object sender, EventArgs e)
        {
            CapchaEntry.Text = CapchaLabel.Text;
            EmailEntry.Text = "admin@ya.ru";
            PasswordEntry.Text = "SdfgSdfg098";

        }
    }
}
