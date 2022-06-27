using MarathonApp.Core;
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
    /// Логика взаимодействия для RunnersManagementPage.xaml
    /// </summary>
    public partial class RunnersManagementPage : ContentPage
    {
        List<RunnerMarathon> dataGridContent;
        user3Entities context;
        public RunnersManagementPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();
            dataGridContent = context.RunnerMarathon.ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;

            MarathonPicker.ItemsSource = context.user3.ToList();
            MarathonPicker.SelectedIndex = 1;

            SortPicker.ItemsSource = new List<string> {"Имя", "Фамилия", "Email"};

            TotalRunnersLabel.Text = String.Format("Всего бегунов {0}", context.RunnerMarathon.Count());
        }

        /// <summary>
        /// Нажатие на кнопку редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Frame currentEditButton = sender as Frame;
            Core.Runner currentRunner = (currentEditButton.BindingContext as Core.RunnerMarathon).Runner;
            if (currentRunner.Registration == null || currentRunner.Registration.Count == 0)
            {
                DisplayAlert("Ошибка","Этот бегун не регистрировался.","OK");
            }
            else {
                this.Navigation.PushAsync(new RunnerManagmentPage(currentRunner));
            }
        }

        /// <summary>
        /// Нажатие на кнопку обновления DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridRefreshButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            dataGridContent = context.RunnerMarathon.ToList();
            Filter();
            Sort(SortPicker.SelectedIndex);
        }

        /// <summary>
        /// Метод фильтрации
        /// </summary>
        private void Filter()
        {
            RunnerMarathon selectedMarathon = (MarathonPicker.SelectedItem as RunnerMarathon);
            dataGridContent = dataGridContent.Where(x => x.MarathonId == selectedMarathon.MarathonId).ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;
            TotalRunnersLabel.Text = String.Format("Всего бегунов {0}", context.RunnerMarathon.Where(x => x.MarathonId == selectedMarathon.RunnerId).Count());
        }

        /// <summary>
        /// Метод сортировки
        /// </summary>
        /// <param name="sortIndex"></param>
        private void Sort(int sortIndex)
        {
            switch (sortIndex)
            {
                case 0:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.FirstName).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
                case 1:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.LastName).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
                case 2:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.Email).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
            }
        }
        /// <summary>
        /// Нажатие на кнопку вывода детальной информации в CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileExportButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            try
            {
                /*SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Выгрузка в CSV файл";
                saveFile.Filter = "CSV file(*.csv)|*.csv|All files(*.*)|*.*";
                if (File.Exists(saveFile.FileName))
                {
                    File.Delete(saveFile.FileName);
                }
                if (saveFile.ShowDialog().HasValue)
                {
                    using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                    {
                        Console.WriteLine("Вывод");
                        List<Runner> userList = context.Runner.ToList();
                        foreach (Runner item in userList)
                        {
                            List<string> lineList = new List<string>();

                            lineList.Add(item.User.FirstName.ToString());
                            lineList.Add(item.User.LastName.ToString());
                            lineList.Add(item.Email.ToString());

                            lineList.Add(item.Gender.ToString());
                            lineList.Add(item.DateOfBirth.ToString());
                            lineList.Add(item.Country.CountryName.ToString());

                            string list = String.Join(";", lineList);
                            Console.WriteLine(list);
                            writer.WriteLine(list);
                        }
                    }
                }

                DisplayAlert("Успех","Файл с данными сохранён","OK");*/
            }
            catch(Exception ex)
            {
                DisplayAlert("Ошибка",ex.Message,"OK");
            }
        }

        /// <summary>
        /// Нажатие на кнопку вывода списка Email в CSV 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailExportButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            try
            {
                /*SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "E-mail список";
                saveFile.Filter = "CSV file(*.csv)|*.csv|All files(*.*)|*.*";
                if (saveFile.ShowDialog().HasValue)
                {
                    using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                    {
                        Console.WriteLine("Вывод");
                        List<Runner> userList = context.Runner.ToList();
                        foreach (Runner item in userList)
                        {
                            List<string> lineList = new List<string>();

                            lineList.Add(item.RunnerFIO);
                            lineList.Add(item.Email.ToString());

                            string list = String.Join(";", lineList);
                            Console.WriteLine(list);
                            writer.WriteLine(list);
                        }
                    }
                }

                DisplayAlert("Успех", "Файл с данными сохранён", "OK");*/
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
