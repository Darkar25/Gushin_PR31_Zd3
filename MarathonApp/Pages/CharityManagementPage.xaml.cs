using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharityManagementPage.xaml
    /// </summary>
    public partial class CharityManagementPage : ContentPage
    {
        Core.user3Entities context;
        public CharityManagementPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            CharityDataGrid.ItemsSource = context.Charity.ToList();
            CharityCountLabel.Text = String.Format("Благотворительные организации:  {0}", context.Charity.Count());
            int allDonationsCount = 0;
            foreach (var item in context.Charity.ToList())
            {
                allDonationsCount += item.MoneyCount;
            }
            CharityMoneyCountLabel.Text = String.Format("Всего спонсорских взносов:  ${0}", allDonationsCount);
            SortPicker.ItemsSource = new List<string>
            {
                "Наименование",
                "Сумма"
            };
        }

        /// <summary>
        /// Нажатие на кнопку сортировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            switch (SortPicker.SelectedIndex)
            {
                case 0:
                    CharityDataGrid.ItemsSource = context.Charity.OrderBy(x=>x.CharityName).ToList();
                    break;
                case 1:
                    CharityDataGrid.ItemsSource = context.Charity.OrderBy(x=>x.MoneyCount).ToList();
                    break;
            }
        }
    }
}
