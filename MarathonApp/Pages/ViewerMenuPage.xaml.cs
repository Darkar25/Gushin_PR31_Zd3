using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewerMenuPage.xaml
    /// </summary>
    public partial class ViewerMenuPage : ContentPage
    {
        int picturePageNumber;
        int maxPicturePageNumber;
        Core.user3Entities context;
        public ViewerMenuPage()
        {
            context = new Core.user3Entities();

            InitializeComponent();

            picturePageNumber = 1;
            maxPicturePageNumber = context.Runner.ToList().Count/4;

            if(context.Runner.ToList().Count % 4 > 0)
            {
                maxPicturePageNumber++;
            }

            PictureListView.ItemsSource = context.Runner.OrderBy(x=>x.RunnerId).Take(4).ToList();

            PageCountLabel.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
        }


        /// <summary>
        /// Кнопка перехода на страницу назад в просмотре изображений бегунов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageDownButton_Clicked(object sender, EventArgs e)
        {
            if (picturePageNumber > 1)
            {
                picturePageNumber -= 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*4).Take(4).ToList();
                
                PageCountLabel.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        /// <summary>
        /// Кнопка перехода на следующую страницу в просмотре изображений бегунов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageUpButton_Clicked(object sender, EventArgs e)
        {
            if (picturePageNumber < maxPicturePageNumber)
            {
                picturePageNumber += 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*4).Take(4).ToList();
                PageCountLabel.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        /// <summary>
        /// Кнопка Оставить отзыв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCommentButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddReviewPage());
        }

        /// <summary>
        /// Нажатие на кнопку вывода статистики отзывов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentStatButton_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ReviewsPage());
        }
    }
}
