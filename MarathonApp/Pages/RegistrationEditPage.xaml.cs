using MarathonApp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationEditPage.xaml
    /// </summary>
    public partial class RegistrationEditPage : ContentPage
    {
        Core.user3Entities context;
        Core.Runner currentRunner;
        Core.User currentUser;
        Core.Registration reg;
        public RegistrationEditPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            EmailEntry.Text = Preferences.Get("currentUserEmail","");

            currentRunner = context.Runner.Where(x => x.Email == EmailEntry.Text).First();
            currentUser = context.User.Where(x => x.Email == EmailEntry.Text).First();
            reg = context.Registration.Where(x => x.Runner.Email == EmailEntry.Text).First();
            if(reg == null)
            {
                DisplayAlert("Ошибка", "Этот бегун не регистрировался!", "OK");
                this.Navigation.PopAsync();
            }

            FirstNameEntry.Text = currentUser.FirstName.ToString();
            LastNameEntry.Text = currentUser.LastName.ToString();

            GenderPicker.ItemsSource = context.Gender.ToList();
            GenderPicker.SelectedItem = currentRunner.Gender;

            CountryPicker.ItemsSource = context.Country.ToList();
            CountryPicker.SelectedItem = currentRunner.CountryCode;

            DateOfBirthDatePicker.Date = currentRunner.DateOfBirth;

            RegisterStatus.ItemsSource = context.RegistrationStatus.ToList();
            RegisterStatus.SelectedItem = reg;

            /*MemoryStream ms = new MemoryStream(currentRunner.RunnerPicture);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            RunnerImage.Source = image;*/
        }
        private void FileButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            /*OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "PNG file(*.png)|*.png|JPG file(*.jpg)|*.jpg|JPEG file(*.jpeg)|*.jpeg";
            openImage.Title = "Выберите изображение";

            if (openImage.ShowDialog() == DialogResult.OK)
            {
                byte[] imageByte = File.ReadAllBytes(openImage.FileName);
                if (imageByte.Length / 1024 / 1024 > 2)
                {
                    DisplayAlert("Ошибка","Выбранное изображение слишком большое","OK");
                }
                else
                {
                    RunnerImage.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathEntry.Text = openImage.FileName;
                    currentRunner.Img = imageByte;
                }
            }*/
        }

        /// <summary>
        /// Нажатие на кнопку сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(PasswordEntry.Text))
                {
                    if (PasswordEntry.Text == PasswordRepeatEntry.Text)
                    {
                        currentUser.Password = PasswordEntry.Text;
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Пароли не совпадают\nПароль не изменён", "OK");
                    }
                }

                currentUser.FirstName = FirstNameEntry.Text;
                currentUser.LastName = LastNameEntry.Text;
                currentRunner.Gender = (GenderPicker.SelectedItem as Gender).Gender1;
                currentRunner.DateOfBirth = DateOfBirthDatePicker.Date;
                reg.RegistrationStatusId = (RegisterStatus.SelectedItem as Core.RegistrationStatus).RegistrationStatusId;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }

        }

        /// <summary>
        /// Нажатие на кнопку отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
