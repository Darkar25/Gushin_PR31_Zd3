using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BMICalculatorPage.xaml
    /// </summary>
    public partial class BMICalculatorPage : ContentPage
    {
        // Переменная со значением выбранного пола (true - мужской/false - женский). По умолчанию выбран мужской пол.
        bool gender;
        public BMICalculatorPage()
        {
            gender = true;

            InitializeComponent();
            ActivityBorder.IsVisible = false;
            BMISlider.Minimum = 10;
            BMISlider.Maximum = 50;
            /*PeoplePicture.Source = new UriImageSource(new Uri("../Resources/men.png", UriKind.Relative));*/


        }

        /// <summary>
        /// Кнопка отмены переводит пользователя на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        /// <summary>
        /// Кнокпка вычисления значения BMI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(HeightEntry.Text) && !String.IsNullOrWhiteSpace(HeightEntry.Text) && !String.IsNullOrEmpty(WeightEntry.Text) && !String.IsNullOrWhiteSpace(WeightEntry.Text))
            {
                try
                {
                    double bmiValue = Convert.ToDouble(WeightEntry.Text) / ((Convert.ToDouble(HeightEntry.Text) / 100) * (Convert.ToDouble(HeightEntry.Text) / 100));
                    Console.WriteLine(bmiValue);
                    var lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\Resources\\BMI.csv"));
                    string[][] normsList = new string[lines.Length][];
                    for (int i = 0; i < normsList.Length; i++) normsList[i] = lines[i].Split(';');
                    int ageNumber = GetAgeNumber();
                    if (bmiValue < Convert.ToDouble(normsList[ageNumber][0]))
                    {
                        StatusLabel.Text = "Недостаточный";
                    }
                    else if (bmiValue >= Convert.ToDouble(normsList[ageNumber][0]) && bmiValue < Convert.ToDouble(normsList[ageNumber][1]))
                    {
                        StatusLabel.Text = "Здоровый";
                    }
                    else if (bmiValue >= Convert.ToDouble(normsList[ageNumber][1]) && bmiValue < Convert.ToDouble(normsList[ageNumber][2]))
                    {
                        StatusLabel.Text = "Избыточный";
                    }
                    else
                    {
                        StatusLabel.Text = "Ожирение";
                    }

                    BMISlider.Value = Convert.ToInt32(bmiValue);
                    DiagramStackLayout.IsVisible = true;

                    double bmrValue;
                    if (gender)
                    {
                        bmrValue = 66.47 + (6.24 * Convert.ToInt32(WeightEntry.Text)) + (12.7 * Convert.ToInt32(HeightEntry.Text) - (6.755 * Convert.ToInt32(AgeEntry.Text)));
                    }
                    else
                    {
                        bmrValue = 655.1 + (4.35 * Convert.ToInt32(WeightEntry.Text)) + (4.7 * Convert.ToInt32(HeightEntry.Text) - (4.7 * Convert.ToInt32(AgeEntry.Text)));
                    }
                    BMRValueLabel.Text = Convert.ToInt32(bmrValue).ToString();
                    SitCaloryLabel.Text = String.Format("Сидячий: {0}", Convert.ToInt32(bmrValue * 1.2));
                    LowCaloryLabel.Text = String.Format("Маленькая активность: {0}", Convert.ToInt32(bmrValue * 1.38));
                    AverageCaloryLabel.Text = String.Format("Средняя активность: {0}", Convert.ToInt32(bmrValue * 1.56));
                    HighCaloryLabel.Text = String.Format("Сильная активность: {0}", Convert.ToInt32(bmrValue * 1.73));
                    MaxCaloryLabel.Text = String.Format("Максимальная активность: {0}", Convert.ToInt32(bmrValue * 1.95));



                }
                catch (Exception ex)
            {
                DisplayAlert("Ошибка",ex.Message,"OK");
            }
        }
        }

        /// <summary>
        /// Получение номера строки для выбора норм BMI
        /// </summary>
        /// <returns></returns>
        private int GetAgeNumber()
        {
            int ageNumber;
            if (Convert.ToInt32(AgeEntry.Text) >= 20 && Convert.ToInt32(AgeEntry.Text) < 30)
            {
                ageNumber = 1;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 30 && Convert.ToInt32(AgeEntry.Text) < 40)
            {
                ageNumber = 2;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 40 && Convert.ToInt32(AgeEntry.Text) < 50)
            {
                ageNumber = 3;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 50 && Convert.ToInt32(AgeEntry.Text) < 60)
            {
                ageNumber = 4;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 60 && Convert.ToInt32(AgeEntry.Text) < 70)
            {
                ageNumber = 5;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 70 && Convert.ToInt32(AgeEntry.Text) < 80)
            {
                ageNumber = 6;
            }
            else if (Convert.ToInt32(AgeEntry.Text) >= 80)
            {
                ageNumber = 7;
            }
            else
            {
                ageNumber = 0;
            }
            if (!gender)
            {
                ageNumber += 9;
            }

            return ageNumber;
        }

        /// <summary>
        /// Выбор мужского пола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManButton_Clicked(object sender, EventArgs e)
        {
            gender = true;
            /*PeoplePicture.Source = new BitmapImage(new Uri("../Resources/men.png", UriKind.Relative));*/
            WomanButton.Opacity = 0.5;
            ManButton.Opacity = 1;
        }

        /// <summary>
        /// Выбор женского пола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WomanButton_Clicked(object sender, EventArgs e)
        {
            gender = false;
            /*PeoplePicture.Source = new BitmapImage(new Uri("../Resources/mowan.png", UriKind.Relative));*/
            WomanButton.Opacity = 1;
            ManButton.Opacity = 0.5;
        }

        /// <summary>
        /// Крестик для закрытия всплывающего окна 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrossImage_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ActivityBorder.IsVisible = false;
        }

        /// <summary>
        /// Кнопка для открытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Clicked(object sender, EventArgs e)
        {
            ActivityBorder.IsVisible = true;
        }
    }
}
