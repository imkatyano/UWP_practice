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

        int clientsMoney;
        public int ClientsMoneyInt
        {
            get { return clientsMoney; }
            set { clientsMoney = value; }
        }

        int purchaseQuantity;
        public int PurchaseInt
        {
            get { return purchaseQuantity; }
            set { purchaseQuantity = value; }
        }
        const int BunPrice = 200;
        int clientCheck;
        MessageDialog messageDialog1;
        public BlankPage3()
        {
            this.InitializeComponent();
            messageDialog1 = new MessageDialog("Your wallet can't be empty.", title: "Error");
        }

        private async void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientsMoney = Convert.ToInt32(ClientsMoney.Text);

                if (clientsMoney == 0)
                {
                    await messageDialog1.ShowAsync();
                }

                else if (clientsMoney < 0)
                {
                    messageDialog1.Content = "Incorrect format :( \nPlease, enter a positive number.";
                    await messageDialog1.ShowAsync();
                }
                else
                {
                    MoneyAfterUpdate.Text = clientsMoney.ToString();
                    BorderForTextblock.Visibility = Visibility.Visible;   
                    AvailableBunsQuantity.Text = $"You can buy {(clientsMoney / 200).ToString()} buns.";

                    ElementsVisibilityChange();
                }
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
                clientsMoney += Convert.ToInt32(HowMuchMoneyToAdd.Text);

                if (Convert.ToInt32(HowMuchMoneyToAdd.Text) < 0)
                {
                    messageDialog1.Content = "Incorrect format :( \nPlease, enter a positive number.";
                    await messageDialog1.ShowAsync();
                }
                else
                {
                    MoneyAfterUpdate.Text = clientsMoney.ToString();
                    AvailableBunsQuantity.Text = $"You can buy {(clientsMoney/ 200).ToString()} buns.";
                }
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


        private async void RecordButtonForPurchase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                purchaseQuantity = Convert.ToInt32(BunsQuantityPurchase.Text);

                if (clientsMoney < 200)
                {
                    messageDialog1.Content = "You can't buy buns :( \nThis money is not enough.";
                    await messageDialog1.ShowAsync();

                }

                else if (purchaseQuantity == 0)
                {
                    messageDialog1.Content = "Please, buy at least one bun!";
                    await messageDialog1.ShowAsync();
                }
                else if (purchaseQuantity < 0)
                {
                    messageDialog1.Content = "Incorrect format :( \nPlease, enter a positive number.";
                    await messageDialog1.ShowAsync();
                }
                else
                {

                    clientCheck = purchaseQuantity * BunPrice;
                    ClientCheckWithoutSale.Text = $"Your check is {clientCheck} roubles.";
                    CalculateDiscountButton.Visibility = Visibility.Visible;   
                    MakeAPurchaseButton.Visibility = Visibility.Visible;
                }
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
 
        private async void CalculateDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientCheck -= clientCheck / 4;

                if (clientCheck < 1200)
                {
                    messageDialog1.Content = "You can't have a discount! Read more info.";
                    await messageDialog1.ShowAsync();
                }
                else
                {
                    ClientCheckWithSale.Text = $"Your check is {clientCheck} roubles.";
                }
            }
            catch (Exception ex)
            {
                messageDialog1.Content = ex.Message;
                await messageDialog1.ShowAsync();
            }

        }

        private void ElementsVisibilityChange()
        {
            QuestionAboutQuantity.Visibility = Visibility.Visible;
            BunsQuantityPurchase.Visibility = Visibility.Visible;
            RecordButtonForPurchase.Visibility = Visibility.Visible;
        }

        private void ClientsMoney_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb1 = (sender as TextBox);
            tb1.Text = string.Empty;
            tb1.GotFocus -= ClientsMoney_GotFocus;
        }

        private void BunsQuantityPurchase_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb1 = (sender as TextBox);
            tb1.Text = string.Empty;
            tb1.GotFocus -= BunsQuantityPurchase_GotFocus;
        }

        private async void MakeAPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog messageDialog = new MessageDialog($"Congratulations on buying! Your purchase will be recorded in your Buying List.", title: "Congratulations!");

            messageDialog.Commands.Add(new UICommand("OK", null));
            await messageDialog.ShowAsync();
            //await messageDialog1.ShowAsync();
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




