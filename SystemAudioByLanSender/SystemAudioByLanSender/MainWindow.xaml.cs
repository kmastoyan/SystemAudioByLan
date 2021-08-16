using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace SystemAudioByLanSender
{
    public partial class MainWindow : Window
    {
        public string ipAddress = "127.0.0.1";
        public string port = "8000";


        public MainWindow()
        {
            InitializeComponent();
            GetIpAddr();

        }

        public static List<string> GetLocalIPAddress()
        {
            List<string> ips = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {

                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ips.Add(ip.ToString());
                }
            }
            return ips;
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void GetIpAddr()
        {
            List<string> availableIps = GetLocalIPAddress();

            ipsListBox.ItemsSource = availableIps;
            comboBox1.ItemsSource = availableIps;
            //   if()
            comboBox1.SelectedIndex = 0;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            ipAddress = comboBox1.SelectedItem.ToString();
            ipLabel.Content = "Local Ip addresses of this computer: " + ipAddress;
            tbSettingText.Text = ipAddress;
        }
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            // Omitted Code: Insert code that does something whenever
            // the text changes...
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            tbSettingText.Text = regex.IsMatch(e.Text).ToString();
            if (!regex.IsMatch(e.Text))
            {
                if (int.Parse(e.Text) > 0 && int.Parse(e.Text) <= 65535)
                {
                    e.Handled = true;
                }
                else { e.Handled = false; }
            }
            else
            {
                e.Handled = true;
            };

        }
    }
}
