using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;

namespace SystemAudioByLanSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            GetIpAddr();

          // OpenSocket();

        }

        public void OpenSocket()
        {
          //  var host = Dns.GetHostEntry(Dns.GetHostName());
          //  IPAddress ip = new IPAddress();
           // ip=host.AddressList
            //ip.setAddressFamily = AddressFamily.InterNetwork;
        //    TcpListener tl = new TcpListener(ip,65000);
        //    tl.Start();
            
         //   Socket sc= tl.AcceptSocket();
           // socketConStatus.Content="Litening"


       //     sc.Close(); 

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
            ipsListBox.ItemsSource = GetLocalIPAddress();
       
        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
