using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNewUserPage.xaml
    /// </summary>
    public partial class AddNewUserPage : ContentPage
    {
        Core.user3Entities context;
        Core.User user;
        bool isNew;
        public AddNewUserPage(Core.user3Entities context, Core.User user, bool isNew)
        {
            this.isNew = isNew;
            InitializeComponent();

            RolePicker.ItemsSource = context.Role.ToList();
            // Проверка того, выбрано создание нового пользователя или редактирование существующего
            if (isNew)
            {
                PageLabel.Text = "Добавление нового пользователя";
                PasswordLabel.Text = "Новый пароль";
                PasswordLabel.Text = String.Empty;
                EmailEntry.IsReadOnly = false;
            }
            else
            {
                PageLabel.Text = "Редактирование пользователя";
                PasswordLabel.Text = "Смена пароля";
                PasswordLabel.Text = "Оставьте эти поля, незаполненными, если вы не хотите изменять пароль.";
                EmailEntry.IsReadOnly = true;
            }

            this.context = context;
            this.BindingContext = user;
        }

        /// <summary>
        /// Кнопка для сохранения данных пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            ErrorsLabel.Text = String.Empty;
            List<string> errorsList = new List<string>();
            if (!String.IsNullOrEmpty(PasswordEntry.Text) || !String.IsNullOrEmpty(PasswordRepeatEntry.Text) || !String.IsNullOrWhiteSpace(PasswordEntry.Text) || !String.IsNullOrWhiteSpace(PasswordRepeatEntry.Text))
            {
                if (PasswordEntry.Text == PasswordRepeatEntry.Text)
                {
                    PasswordValue.Text = PasswordEntry.Text;
                }
                else
                {
                    errorsList.Add("Пароли не совпадают");
                }
            }
            else
            {
                if (isNew)
                {
                    errorsList.Add("Пароль не заполнен");
                }
            }

            if (errorsList.Count == 0)
            {
                context.User.Add(user);
                context.SaveChanges();
                DisplayAlert("Данные сохранены", "Данные успешно сохранены", "OK");
                this.Navigation.PopAsync();
            }
            else
            {
                ErrorsLabel.Text = String.Join(",", errorsList);
            }
        
        }

        /// <summary>
        /// Кнопка отмены редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
