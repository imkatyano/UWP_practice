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
        MessageDialog messageDialog1 = new MessageDialog("Your wallet can't be empty.", title: "Error");
        public BlankPage3()
        {
            this.InitializeComponent();
        }

        // создана переменная clientsMoneyInt
        // > OK > присвоение переменной clientsMoneyInt значения, введённого пользователем (52)
        //      > вывод в текстбокс MoneyAfterUpdate значения переменной

        // > AddMoney > присвоение переменной clientsMoneyInt значения, введённого в поле HowMuchMoneyToAdd
        // обновление в текстбокс MoneyAfterUpdate

        private async void OKButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientsMoneyInt = Convert.ToInt32(ClientsMoney.Text);  

                if (clientsMoneyInt == 0)  
                {
                    await messageDialog1.ShowAsync();
                }

                else if (clientsMoneyInt < 0)
                {
                    messageDialog1.Content = "Incorrect format :( \nPlease, enter a positive number.";
                    await messageDialog1.ShowAsync();
                }
                else MoneyAfterUpdate.Text = clientsMoneyInt.ToString();  
            }

            catch (FormatException)
            {
                messageDialog1.Content = "Incorrect format :( \nPlease, enter a number.";
                await messageDialog1.ShowAsync();
            }
            catch (Exception ex)
            {
                messageDialog1.Content = ex.Message;
                await messageDialog1.ShowAsync();
            }     
        }

        private async void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientsMoneyInt += Convert.ToInt32(HowMuchMoneyToAdd.Text);

                if (Convert.ToInt32(HowMuchMoneyToAdd.Text) < 0)
                {
                    messageDialog1.Content = "Incorrect format :( \nPlease, enter a positive number.";
                    await messageDialog1.ShowAsync();
                }
                else MoneyAfterUpdate.Text = clientsMoneyInt.ToString();   
                clientsMoneyInt = Convert.ToInt32(MoneyAfterUpdate.Text);
            }

            catch (FormatException)
            {
                messageDialog1.Content = "Incorrect format :( \nPlease, enter a number";
                await messageDialog1.ShowAsync();
            }
            catch (Exception ex)
            {
                messageDialog1.Content = ex.Message;
                await messageDialog1.ShowAsync();
            }
        }

        private void GoToPageInfoButton_Click(object sender, RoutedEventArgs e)
        {
            BlankPage2.PageNavigationQueue.Enqueue(3);
            Frame.Navigate(typeof(BlankPage2));
        }

        private void GoToPage4Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage4));
        }
    }
}


        //             Frame.Navigate(typeof(BlankPage2)); возможно сделать не воид, а чтобы передавалось какое-то число содержащее инфу о странице




