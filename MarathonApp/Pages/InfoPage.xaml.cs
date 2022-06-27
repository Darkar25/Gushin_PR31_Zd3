using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице информации о марафоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarathonSkillsInfoButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MarathonInfoPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице "Насколько долгий марафон"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HowLongInfoButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MarathonLengthPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице предыдущих результатов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousResultsButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PreviousRunsPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице благотворительных организаций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CharityPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице BMI калькулятора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new BMICalculatorPage());
        }
    }
}
