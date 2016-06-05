﻿using System;
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

namespace Blacklight.Views
{
    public sealed partial class Inspiration : Page
    {
        public Inspiration()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        public void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "");
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Profile), "");
        }

        private void CouponButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Coupons), "");
        }

        private void InspirationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Inspiration), "");
        }

        private void InsertData_click(object sender, RoutedEventArgs e)
        {
            var idrandom = DateTime.Now.ToBinary().ToString() + messageTxt.Text;

            Message msg = new Message
            {
                id = idrandom,
                content = messageTxt.Text
            };

            Messaging.InsertMessage(msg);

            var m1 = new MessageDialog("Data Inserted: " + msg.content).ShowAsync();

            messageTxt.Text = "";
        }


        private async void Retrive_Click(object sender, RoutedEventArgs e)

        {

            //List<Message> allMessages = Messaging.RetrieveMessage();

            List<Message> allMessages = await App.MobileService.GetTable<Message>().ToListAsync();

            string res = "";

            foreach (Message mess in allMessages)

            {

                res += "Message :" + mess.content + "\n\n";

            }

            var m1 = new MessageDialog(res).ShowAsync();

        }
    }
}