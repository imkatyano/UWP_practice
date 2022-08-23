using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace juice
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var x = sender as MainPage;
            for (x.Opacity = 0; x.Opacity <= 1; x.Opacity += .025)
            {
                await Task.Delay(40);
            }
        }

        private async void BigButton_Click(object sender, RoutedEventArgs e)
        {
            //BigButton.IsEnabled = false;
            await Task.Delay(800);
            NewText.Text = "hi";
            await Task.Delay(800);
            NewText2.Text = "do u want to play?";
            await Task.Delay(1000);
            ButtonPositve.Visibility = Visibility.Visible;
            ButtonNegative.Visibility = Visibility.Visible;
        }

        //private void NewTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    TextBox tb = (sender as TextBox);
        //    tb.Text = string.Empty;
        //    tb.GotFocus -= NewTextBox_GotFocus;
        //}

        private void ButtonPositve_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage1));
        }

        private async void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            CoreApplication.Exit();
        }


        /* private async void NewTextBox_TextChanged(object sender, TextChangedEventArgs e)
         {
             await Task.Delay(5000);
             UserAnswer = (sender as TextBox).Text;

             if (positiveAnswer.Contains(UserAnswer))
             {
                 Frame.Navigate(typeof(BlankPage1));
             }
             else
             {
                 await Task.Delay(1500);
                 CoreApplication.Exit();
             }
         }
        */
    }
}
