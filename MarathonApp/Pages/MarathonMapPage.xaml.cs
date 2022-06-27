using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarathonMapPage.xaml
    /// </summary>
    public partial class MarathonMapPage : ContentPage
    {
        public MarathonMapPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку чекпоинта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleButton_Clicked(object sender, EventArgs e)
        {
            foreach (Button item in InteractiveMapCanvas.Children)
            {
                if(item is Button)
                {
                    item.Background = Brush.Orange;
                }
            }

            Button currentButton = sender as Button;
            currentButton.Background = Brush.Red;

            CheckPointInfoBorder.IsVisible = true;
            CheckpointDescription(currentButton);
        }

        /// <summary>
        /// Метод для выбора информации для всплывающего окна чекпоинта
        /// </summary>
        /// <param name="currentButton"></param>
        private void CheckpointDescription(Button currentButton)
        {
            switch (currentButton.Text)
            {
                case "1":
                    CheckpointNameLabel.Text = "Checkpoint 1";
                    CheckpointPerksLabel.Text = "Стенд для питья\nЭнергетические батончики\nТуалет\nМедецинский Пункт";
                    break;
                case "2":
                    CheckpointNameLabel.Text = "Checkpoint 2";
                    CheckpointPerksLabel.Text = "Энергетические батончики\nТуалет\nМедецинский Пункт";
                    break;
                case "3":
                    CheckpointNameLabel.Text = "Checkpoint 3";
                    CheckpointPerksLabel.Text = "Стенд для питья\nТуалет\nМедецинский Пункт";
                    break;
                case "4":
                    CheckpointNameLabel.Text = "Checkpoint 4";
                    CheckpointPerksLabel.Text = "Стенд для питья\nЭнергетические батончики\nМедецинский Пункт";
                    break;
                case "5":
                    CheckpointNameLabel.Text = "Checkpoint 5";
                    CheckpointPerksLabel.Text = "Стенд для питья\nЭнергетические батончики\nТуалет";
                    break;
                case "6":
                    CheckpointNameLabel.Text = "Checkpoint 6";
                    CheckpointPerksLabel.Text = "Стенд для питья\nМедецинский Пункт";
                    break;
            }
        }

        /// <summary>
        /// Нажатие на крестик для закрытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrossImage_MouseLeftButtonDown(object sender, EventArgs e)
        {
            CheckPointInfoBorder.IsVisible = false;
        }
    }
}
