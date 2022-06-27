using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorMenuPage.xaml
    /// </summary>
    public partial class CoordinatorMenuPage : ContentPage
    {
        public CoordinatorMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка перехода к странице управления бегунами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunnersButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RunnersManagementPage());
        }

        /// <summary>
        /// Кнопка перехода к странице управления благотворительными организациями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CharityManagementPage());
        }
    }
}
