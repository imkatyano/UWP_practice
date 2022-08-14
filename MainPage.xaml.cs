using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace juice
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BigButton_Click(object sender, RoutedEventArgs e)
        {
            //BigButton.IsEnabled = false;
            await Task.Delay(800);
            NewText.Text = "hi";
            await Task.Delay(800);
            NewText2.Text = "do u want to play?";
            await Task.Delay(800);
            NewTextBox.Visibility = Visibility.Visible;
            await Task.Delay(5000);

            if (NewTextBox.Text=="put ur answer here")
            {
                NewText.Text = " ";
                var bgcolor = Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0);
                NewText2.Foreground = new SolidColorBrush(bgcolor);
                NewText2.Text = "think faster!";
                NewTextBox.Visibility = Visibility.Collapsed;
                await Task.Delay(1500);

            }
            else if (NewTextBox.Text == "yes" | NewTextBox.Text == "Yes" | NewTextBox.Text == "да" | NewTextBox.Text == "Да")
            {
                Game();
            }

            else if (NewTextBox.Text == "no" | NewTextBox.Text == "No" | NewTextBox.Text == "нет" | NewTextBox.Text == "Нет")
            {
                await Task.Delay(1500);
                CoreApplication.Exit();
            }
            CoreApplication.Exit();


        }

        private void NewTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.Text = string.Empty;
            tb.GotFocus -= NewTextBox_GotFocus;
        }
        void Game() { int x = 1; x++; }


    }
}
