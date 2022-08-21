using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace juice
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()         // написать цену булки
        {
            this.InitializeComponent();
        }

        /*private async void ButtonForAgreement_Click(object sender, RoutedEventArgs e)
        {
            string popupMessage = "Please, read it patiently. But if you will forget them, you can always come back to this page.";
            MessageDialog messageDialog = new MessageDialog(popupMessage);
            messageDialog.Title = "Important Information";
            messageDialog.Commands.Add(new UICommand("Okay, I understand", null));
            await messageDialog.ShowAsync();

            Frame.Navigate(typeof(BlankPage3));
        }*/

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3500);
            TextBlockOnChoiceGrid4.Opacity = 0;
            TextBlockOnChoiceGrid4.Visibility = Visibility.Visible;

            for (TextBlockOnChoiceGrid4.Opacity = 0; TextBlockOnChoiceGrid4.Opacity <= 1; TextBlockOnChoiceGrid4.Opacity += .025)
            {
                await Task.Delay(40);
            }
        }

        private async void FirstCellTapped(object sender, RoutedEventArgs e)
        {
            string popupMessage = "Please, read it patiently. But if you will forget them, you can always come back to this page.";
            MessageDialog messageDialog = new MessageDialog(popupMessage);
            messageDialog.Title = "Important Information";
            messageDialog.Commands.Add(new UICommand("Okay, I understand", null));
            await messageDialog.ShowAsync();

            Frame.Navigate(typeof(BlankPage3));
        }
    }
}
