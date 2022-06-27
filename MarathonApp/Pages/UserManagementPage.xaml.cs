using MarathonApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : ContentPage
    {
        Core.user3Entities context;
        public UserManagementPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            RoleFilterPicker.ItemsSource = context.Role.ToList();

            UserCountLabel.Text =String.Format("Количество пользователей: {0}",context.User.Count().ToString());

            UsersDataGrid.ItemsSource = context.User.ToList();
        }

        /// <summary>
        /// Кнопка редактирования информации о пользователе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Frame editButton = sender as Frame;
            Core.User currentUser = editButton.BindingContext as Core.User;
            this.Navigation.PushAsync(new AddNewUserPage(context, currentUser, false));
        }

        /// <summary>
        /// Кнопка добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewUserButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Core.User newUser = new Core.User();
            this.Navigation.PushAsync(new AddNewUserPage(context, newUser, true));
        }

        /// <summary>
        /// Кнопка обновления по заданным фильтрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            List<Core.User> currentDataGridContext = context.User.ToList();
            if(RoleFilterPicker.SelectedItem != null)
            {
                var rid = (RoleFilterPicker.SelectedItem as Role).RoleId;
                currentDataGridContext = currentDataGridContext.Where(x => x.RoleId == rid).ToList();
            }

            if(SortPicker.SelectedItem != null)
            {
                //currentDataGridContext = currentDataGridContext.OrderBy( SortPicker.SelectedValue);
            }

            if (!String.IsNullOrEmpty(SearchEntry.Text) || !String.IsNullOrWhiteSpace(SearchEntry.Text))
            {
                currentDataGridContext = currentDataGridContext.Where(x => x.FirstName.ToLower().Contains(SearchEntry.Text.ToLower())||x.LastName.ToLower().Contains(SearchEntry.Text.ToLower())).ToList();
            }
            UserCountLabel.Text = String.Format("Количество пользователей: {0}", currentDataGridContext.Count().ToString());
            UsersDataGrid.ItemsSource = currentDataGridContext;
        }
    }
}
