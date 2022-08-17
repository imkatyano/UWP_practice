using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace juice
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPage3 : Page
    {
        public BlankPage3()
        {
            this.InitializeComponent();
        }

        private async void ClientsMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int ClientsMoney = Convert.ToInt32(((TextBox)sender).Text);
            try
            {
                int ClientsMoney = Convert.ToInt32(((TextBox)sender).Text);

                if (ClientsMoney <= 0)
                {
                    MessageDialog messageDialog = new MessageDialog($"Please, add some money, {ClientsMoney} is too little");
                    messageDialog.Title = "Error";
                    messageDialog.Commands.Add(new UICommand("Sorry", null));
                    await messageDialog.ShowAsync();
                }
            }
            catch (FormatException ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.Title = "Error";
                messageDialog.Commands.Add(new UICommand("Sorry", null));
                await messageDialog.ShowAsync();
            }

            catch (Exception ex1)
            {
                // вывести MessageDialog для рандомной ошибки

            }

        }

        // AnswerTextBlock пока скрыт, появится при написании человеком кол-ва денег






    }
}
