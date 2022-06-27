using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ThankPage.xaml
    /// </summary>
    public partial class ThankPage : ContentPage
    {
        Core.user3Entities context;
        /// <summary>
        /// Страница для вывода благодарности за пожертвование
        /// </summary>
        /// <param name="runner"></param>
        /// <param name="charity"></param>
        /// <param name="money"></param>
        public ThankPage(int runner, int charity, int money)
        {
            context = new Core.user3Entities();
            InitializeComponent();
            // В переменную заносится результат поиска в LINQ запросе имени бегуна
            string currentRunnerFIO = context.Runner.Where(x => x.RunnerId == runner).First().RunnerFIO;
            // В переменную заносится результат поиска в LINQ запросе названия страны бегуна
            string currentRunnerCountry = context.Runner.Where(x => x.RunnerId == runner).First().Country.CountryName;
            // В переменную заносится результат поиска в LINQ запросе названия благотворительной организации
            string currentCharityName = context.Charity.Where(x => x.CharityId == charity).First().CharityName;

            RunnerInfoLabel.Text = String.Format("{0} из {1}", currentRunnerFIO, currentRunnerCountry);
            CharityLabel.Text = currentCharityName;
            MoneyLabel.Text = String.Format("${0}", money);
        }

        /// <summary>
        /// Кнопка перехода назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PopAsync();
        }
    }
}
