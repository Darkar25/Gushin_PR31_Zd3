using Microsoft.Win32;
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
    /// Логика взаимодействия для RunnerEditPage.xaml
    /// </summary>
    public partial class RunnerEditPage : ContentPage
    {
        Core.user3Entities context;
        public RunnerEditPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Нажатие на кнопку выбора изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            /*OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "PNG file(*.png)|*.png|JPG file(*.jpg)|*.jpg|JPEG file(*.jpeg)|*.jpeg";
            openImage.Title = "Выберите изображение";

            if (openImage.ShowDialog() == true)
            {
                byte[] imageByte = File.ReadAllBytes(openImage.FileName);
                if (imageByte.Length / 1024 / 1024 > 2)
                {
                    DisplayAlert("Ошибка","Выбранное изображение слишком большое","OK");
                }
                else
                {
                    RunnerPicture.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathEntry.Text = openImage.FileName;
                }
            }*/
        }

        /// <summary>
        /// Нажатие на кнопку сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_MouseLeftButtonDown(object sender, EventArgs e)
        {

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
