using MarathonApp.Core;
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
    /// Логика взаимодействия для Sponsor.xaml
    /// </summary>
    public partial class Sponsor : ContentPage
    {
        Core.user3Entities context;
        Core.Sponsor sponsor;
        int money;
        public Sponsor()
        {
            context = new Core.user3Entities();
            sponsor = new Core.Sponsor();
            InitializeComponent();
            money = 50;

            MoneyEntry.Text = money.ToString();
            MoneyScreenLabel.Text = String.Format("${0}", money);

            RunnerPicker.ItemsSource = context.Runner.ToList();

            CharityPicker.ItemsSource = context.Charity.ToList();

            AboutCharityBorder.IsVisible = false;
        }

        /// <summary>
        /// Кнопка заплатить
        /// Происходит сохранение занесённых данных в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            try
            {
                sponsor.CharityId = (CharityPicker.SelectedItem as Charity).CharityId;
                sponsor.RunnerId = (RunnerPicker.SelectedItem as Runner).RunnerId;
                sponsor.Name = NameEntry.Text;
                sponsor.CardName = CardNameEntry.Text;
                sponsor.CardMonth = Convert.ToInt32(CardMonthEntry.Text);
                sponsor.CardYear = Convert.ToInt32(CardYearEntry.Text);
                sponsor.CVCCode = Convert.ToInt32(CVCCodeEntry.Text);
                sponsor.Amount = Convert.ToInt32(MoneyEntry.Text);

                context.Sponsor.Add(sponsor);
                context.SaveChanges();

                this.Navigation.PushAsync(new ThankPage((RunnerPicker.SelectedItem as Runner).RunnerId, (CharityPicker.SelectedItem as Charity).CharityId, money));
            }
            catch(Exception ex)
            {
                DisplayAlert("Ошибка",ex.Message,"OK");
            }
        }
        /// <summary>
        /// Кнопка для увеличения значения пожертвования на 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Clicked(object sender, EventArgs e)
        {
            money++;
            MoneyEntry.Text = money.ToString();
        }

        /// <summary>
        /// Кнопка для уменьшения значения пожертвования на 1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusButton_Clicked(object sender, EventArgs e)
        {
            if (money > 1)
            {
                money--;
                MoneyEntry.Text = money.ToString();
            }
        }

        /// <summary>
        /// Изменение отображаемой суммы пожертвования в зависимости от введённого значения пожертвования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                money = Convert.ToInt32(MoneyEntry.Text);
                MoneyScreenLabel.Text = String.Format("${0}", money);
            }
            catch
            {
                DisplayAlert("Ошибка","Было введено недопустимое значение","OK");
                money = 50;
                MoneyEntry.Text = money.ToString();
            }
        }

        /// <summary>
        /// Кнопка для отображения информации о бляготворительной организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityAbout_Clicked(object sender, EventArgs e)
        {
            if (CharityPicker.SelectedItem != null)
            {
                Charity selectedCharity = CharityPicker.SelectedItem as Charity;
                AboutCharityBorder.IsVisible = true;
                CharityNameLabel.Text = selectedCharity.CharityName;
                CharityDescriptionLabel.Text = selectedCharity.CharityDescription;

                /*MemoryStream ms = new MemoryStream(selectedCharity.Logo);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();

                CharityLogoImage.Source = image;*/
            }
        }

        /// <summary>
        /// Нажатие на крестик для закрытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cross_MouseLeftButtonDown(object sender, EventArgs e)
        {
            AboutCharityBorder.IsVisible = false;
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
