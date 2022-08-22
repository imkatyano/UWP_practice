using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        int clientsMoneyInt;
        public int ClientsMoneyInt
        {
            get { return clientsMoneyInt; }
            set { clientsMoneyInt = value; }
        }
        
        public BlankPage3()
        {
            this.InitializeComponent();
        }

        // создана переменная
        // произведена попытка конвертировать пр нажатии на ОК, в случае успеха - надпись внизу
        // показывает введённые деньги

        // кнопка "добавить деньги" > MoneyAfterUpdate.Text увелич. на 100

    private async void OKButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientsMoneyInt = Convert.ToInt32(ClientsMoney.Text);   // присвоение переменной введенного текста

                if (clientsMoneyInt <= 0)   // поделить на 0 и на отрицательные значения (сделать два if)
                {
                    MessageDialog messageDialog = new MessageDialog($"Please, add some money, {clientsMoneyInt} is too little");

                    messageDialog.Title = "Error";
                    messageDialog.Commands.Add(new UICommand("Sorry", null));
                    await messageDialog.ShowAsync();

                }
                else MoneyAfterUpdate.Text = clientsMoneyInt.ToString();     // присвоение полю вывода введённого текста в формате стринг 
            }

            catch (FormatException)
            {
                MessageDialog messageDialog = new MessageDialog("Incorrect format :( \nPlease, enter a number.");
                messageDialog.Title = "Error";
                messageDialog.Commands.Add(new UICommand("Sorry", null));
                await messageDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.Title = "Error";
                messageDialog.Commands.Add(new UICommand("Sorry", null));
                await messageDialog.ShowAsync();
            }     
        }

        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
                clientsMoneyInt += Convert.ToInt32(ClientsMoney.Text);
                MoneyAfterUpdate.Text = clientsMoneyInt.ToString();
                clientsMoneyInt = Convert.ToInt32(MoneyAfterUpdate.Text);
        }

        private void GoToPageInfoButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.PageNavigationQueue.Enqueue(3);
            Frame.Navigate(typeof(BlankPage2));
        }

        private void GoToPage4Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage4));
        }
    }
}


        //             Frame.Navigate(typeof(BlankPage2)); возможно сделать не воид, а чтобы передавалось какое-то число содержащее инфу о странице




