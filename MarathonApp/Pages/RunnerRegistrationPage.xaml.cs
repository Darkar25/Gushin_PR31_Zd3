using System;
using Microsoft.Win32;
using MarathonApp.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using MarathonXamarin;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerRegistrationPage.xaml
    /// </summary>
    public partial class RunnerRegistrationPage : ContentPage
    {
        byte[] imageByte;
        user3Entities context;
        public RunnerRegistrationPage()
        {
            
            context = new user3Entities();
            InitializeComponent();

            SetBorders();

            // Задние значений для CountryPicker
            CountryPicker.ItemsSource = context.Country.ToList();

            // Задание значений для GenderPicker
            GenderPicker.ItemsSource = context.Gender.ToList();


        }

        /// <summary>
        /// Действия при нажатии на кнопку Подробнее 
        /// для выбора изображения пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            /*OpenFileDialog openImage = new OpenFileDialog();
            openImage.Title = "Выберите фотографию";
            openImage.Filter = "PNG file(*.png)|*.png|JPEG file(*.jpeg)|*.jpeg|JPG file(*.jpg)|*.jpg";

            if (openImage.ShowDialog() == true)
            {
                imageByte = File.ReadAllBytes(openImage.FileName);

                if(imageByte.Length / 1024 / 1024 > 2)
                {
                    DisplayAlert("Ошибка","Выбранное изображение слишком большое","OK");
                }
                else
                {
                    ProfilePicture.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathEntry.Text = openImage.FileName;


                }
            }*/
        }

        /// <summary>
        /// Задание стандартных значений отображения для заполняемых полей
        /// </summary>
        void SetBorders()
        {

        }

        /// <summary>
        /// Действия при нажатии на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            SetBorders();

            StringCheck stringCheck = new StringCheck();
            string errorMessage = null;
            List<string> errorsList = new List<string>();
            if (String.IsNullOrEmpty(EmailEntry.Text) || String.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                errorsList.Add("Email");

            }
            else
            {
                if (stringCheck.EmailCheck(EmailEntry.Text) == false)
                {
                    errorsList.Add("Email введён неверно");
                }
            }

            if (String.IsNullOrEmpty(PasswordEntry.Text)||String.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                errorsList.Add("Пароль");
            }

            if (String.IsNullOrEmpty(PasswordRepeatEntry.Text) || String.IsNullOrWhiteSpace(PasswordRepeatEntry.Text))
            {
                errorsList.Add("Повторите пароль");
            }

            if (GenderPicker.SelectedItem==null)
            {
                errorsList.Add("Пол");
            }

            if (CountryPicker.SelectedItem==null)
            {
                errorsList.Add("Страна");
            }

            if (DateOfBirthDatePicker.Date==null)
            {
                errorsList.Add("Дата рождения");
            }
            
            if (String.IsNullOrEmpty(FirstNameEntry.Text) || String.IsNullOrWhiteSpace(FirstNameEntry.Text))
            {
                errorsList.Add("Имя");
            }
            else
            {
            }
            
            if (String.IsNullOrEmpty(LastNameEntry.Text) || String.IsNullOrWhiteSpace(LastNameEntry.Text))
            {
                errorsList.Add("Фамилия");
            }

            if (PasswordEntry.Text != PasswordRepeatEntry.Text)
            {
                errorMessage = "Пароли не совпадают\n";
            }
            else
            {
                if (stringCheck.PasswordCheck(PasswordEntry.Text)==false)
                {
                    errorMessage = "Пароль введён неправильно";
                }
            }

            if(errorsList.Count>0)
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
                        SaveRunnerData();

                        DisplayAlert("Успех","Регистрация прошла успешно","OK");
                        Preferences.Set("currentUserEmail",EmailEntry.Text);
                        this.Navigation.PushAsync(new RunnerMenuPage());
                    }
                    else
            {
                throw new Exception("Пользователь с таким Email уже существует");
            }
        }
                catch(Exception ex)
                {
                    DisplayAlert("Ошибка",ex.Message,"OK");
                }
}
        }

        private void SaveRunnerData()
        {
            Runner runner = new Runner();
            User user = new User();

            user.Email = EmailEntry.Text;
            user.Password = PasswordEntry.Text;
            user.FirstName = FirstNameEntry.Text;
            user.LastName = LastNameEntry.Text;
            user.RoleId = 1;

            runner.Email = EmailEntry.Text;
            runner.Gender = (GenderPicker.SelectedItem as Gender).Gender1;
            runner.DateOfBirth = DateOfBirthDatePicker.Date;
            runner.CountryCode = (CountryPicker.SelectedItem as Country).CountryCode;
            runner.Img = imageByte;

            context.User.Add(user);
            context.Runner.Add(runner);

            context.SaveChanges();
        }

        /// <summary>
        /// Нажатие на кнопку выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
