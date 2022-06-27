using MarathonApp.Core;
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
    /// Логика взаимодействия для ViewerRegistrationPage.xaml
    /// </summary>
    public partial class ViewerRegistrationPage : ContentPage
    {
        Core.user3Entities context;
        public ViewerRegistrationPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            SetBorders();

            // Задние значений для CountryPicker
            CountryPicker.ItemsSource = context.Country.ToList();

            // Задание значений для GenderPicker
            GenderPicker.ItemsSource = context.Gender.ToList();
        }
        /// <summary>
        /// Метод задания стандартных значений границ полей
        /// </summary>
        void SetBorders()
        {
        }

        /// <summary>
        /// Нажатие на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            SetBorders();
            string errorMessage = null;
            List<string> errorsList = new List<string>();
            if (String.IsNullOrEmpty(EmailEntry.Text) || String.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                errorsList.Add("Email");

            }

            if (String.IsNullOrEmpty(PasswordEntry.Text) || String.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                errorsList.Add("Пароль");
            }

            if (String.IsNullOrEmpty(PasswordRepeatEntry.Text) || String.IsNullOrWhiteSpace(PasswordRepeatEntry.Text))
            {
                errorsList.Add("Повторите пароль");
            }

            if (GenderPicker.SelectedItem == null)
            {
                errorsList.Add("Пол");
            }

            if (CountryPicker.SelectedItem == null)
            {
                errorsList.Add("Страна");
            }


            if (String.IsNullOrEmpty(FirstNameEntry.Text) || String.IsNullOrWhiteSpace(FirstNameEntry.Text))
            {
                errorsList.Add("Имя");
            }

            if (String.IsNullOrEmpty(LastNameEntry.Text) || String.IsNullOrWhiteSpace(LastNameEntry.Text))
            {
                errorsList.Add("Фамилия");
            }

            if (PasswordEntry.Text != PasswordRepeatEntry.Text)
            {
                errorMessage = "Пароли не совпадают\n";
            }

            if (errorsList.Count > 0)
                errorMessage += "Пропущены обязательные к заполнению поля:\n";

            if (errorsList.Count > 0 || PasswordEntry.Text != PasswordRepeatEntry.Text)
            {
                string errorsString = String.Join(", ", errorsList);
                ErrorsLabel.Text = errorMessage + errorsString;
                ErrorsLabel.IsVisible = true;
            }
            else
            {
                try
                {
                    int newUser = context.User.Where(x => x.Email == EmailEntry.Text).Count();
                    if (newUser == 0) 
                    {
                        Core.Volunteer volunteer = new Core.Volunteer();
                        Core.User user = new Core.User();

                        user.Email = EmailEntry.Text;
                        user.Password = PasswordEntry.Text;
                        user.FirstName = FirstNameEntry.Text;
                        user.LastName = LastNameEntry.Text;
                        user.RoleId = 3;

                        volunteer.FirstName = FirstNameEntry.Text;
                        volunteer.LastName = LastNameEntry.Text;
                        volunteer.Email = EmailEntry.Text;
                        volunteer.Gender = (GenderPicker.SelectedItem as Gender).Gender1;
                        volunteer.CountryCode = (CountryPicker.SelectedItem as Country).CountryCode;

                        context.User.Add(user);
                        context.Volunteer.Add(volunteer);

                        context.SaveChanges();
                        Preferences.Set("currentUserEmail", EmailEntry.Text);
                        DisplayAlert("Успех", "Регистрация прошла успешно", "OK");
                        this.Navigation.PushAsync(new ViewerMenuPage());
                    }
                    else
                    {
                        throw new Exception("Пользователь с таким Email уже существует");
                    }
                }
                catch(Exception ex)
                {
                    DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }
        }

        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
