using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReviewsPage.xaml
    /// </summary>
    public partial class ReviewsPage : ContentPage
    {
        Core.user3Entities context;
        public ReviewsPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            ReviewItemsControl.ItemsSource = context.Review.OrderByDescending(x => x.ReviewDateTime).Take(6).ToList();
            ManCountLabel.Text = context.Review.Where(x => x.Volunteer.Gender == "M").Count().ToString();
            WomanCountLabel.Text = context.Review.Where(x => x.Volunteer.Gender == "W").Count().ToString();
            RussiaCountLabel.Text = context.Review.Where(x => x.user3.CountryCode == "RU").Count().ToString();
            AnotherCountriesCountLabel.Text = context.Review.Where(x => x.user3.CountryCode != "RU").Count().ToString();

            var curentSeries = new ColumnSeries()
            {
                Label = "Rating"
            };
            ReviewChart.AreaBorderColor = System.Drawing.Color.White;

            var reviewMarks = context.Review.ToList();
            var pts = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                pts.Add(reviewMarks.Where(x => x.ReviewMark == i).Count());
            }
            curentSeries.ItemsSource = pts;
            ReviewChart.Series.Add(curentSeries);
        }

        /// <summary>
        /// Нажатие на кнопку фильтра мужчин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManFilterButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.Volunteer.Gender == "M").ToList();
        }

        /// <summary>
        /// Нажатие на кнопку фильтра женщин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WomenFilterButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.Volunteer.Gender == "W").ToList();
        }

        /// <summary>
        /// Нажатие на кнопку фильтра России
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RussiaFilterButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.user3.CountryCode == "RU").ToList();
        }

        /// <summary>
        /// Нажатие на кнопку фильтра других стран
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnotherCountriesButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.user3.CountryCode != "RU").ToList();
        }
    }
}
