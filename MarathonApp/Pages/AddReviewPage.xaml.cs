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
    /// Логика взаимодействия для AddReviewPage.xaml
    /// </summary>
    public partial class AddReviewPage : ContentPage
    {
        Core.Review currentReview;
        Core.user3Entities context;
        public AddReviewPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            SetBorders();

            MarathonPicker.ItemsSource = context.user3.ToList();
        }

        /// <summary>
        /// Метод для задания стандартных значений для MarathonComboBox и CommentTextBox
        /// </summary>
        void SetBorders()
        {
        }

        /// <summary>
        /// Нажатие на кнопку отправки отзыва
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            currentReview = new Core.Review();
            SetBorders();
            ErrorLabel.Text = String.Empty;
            currentReview.VolunteerId = context.Volunteer.Where(x => x.Email == Preferences.Get("currentUserEmail","")).First().VolunteerId;
            Console.WriteLine(context.Volunteer.Where(x => x.Email == Preferences.Get("currentUserEmail", "")).First().VolunteerId);
            List<string> errorsList = new List<string>();
            // Проверка выбранной оценки
            if (Mark1RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 1;
            }
            else if (Mark2RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 2;
            }
            else if (Mark3RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 3;
            }
            else if (Mark4RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 4;
            }
            else
            {
                currentReview.ReviewMark = 5;
            }
            if (MarathonPicker.SelectedItem != null)
            {
                currentReview.MarathonId = Convert.ToInt32(MarathonPicker.SelectedItem);
            }
            else
            {
                errorsList.Add("Не выбран марафон\n");
            }
            if (String.IsNullOrEmpty(CommentEntry.Text) || String.IsNullOrWhiteSpace(CommentEntry.Text))
            {
                errorsList.Add("Комментарий не заполнен\n");
            }

            if (errorsList.Count > 0)
            {
                foreach (string error in errorsList)
                {
                    ErrorLabel.Text += error;
                }
            }
            else
            {
                currentReview.ReviewDateTime = DateTime.Now;

                currentReview.ReviewDescription = CommentEntry.Text;

                context.Review.Add(currentReview);
                context.SaveChanges();

                DisplayAlert("Спасибо", "Ваше мнение очень важно для нас", "OK");
                this.Navigation.PopAsync();
            }
        }
    }
}
