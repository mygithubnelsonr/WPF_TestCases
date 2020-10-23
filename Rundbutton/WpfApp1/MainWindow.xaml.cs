using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security;
using System.Security.Cryptography;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Hello Button 1");
            listView1.Items[0] = "A-D";
            listView1.Items[1] = "E-H";
            listView1.Items.Add("qwert");
            listView1.Items.Add("asdfg");

            string key = "18293129819238192381923828340234";
            string iv = "32823947569602830207492028374638";

            string sNumber = @"Ti7Js+FgayYSKrDW54/3zAW4peFAWj45ZzDnZkZgQ8o=";
            Debug.Print(Convert.ToBase64String(Encode(sNumber, key, iv)));

            RundButton rundButton = new RundButton();
            rundButton.Show();

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.label1.Content = "Hallo Welt";
        }

        public byte[] Encode(string plaintext, string key, string IV)
        {
            Rijndael AESCrypto = Rijndael.Create();
            AESCrypto.KeySize = 256;
            AESCrypto.BlockSize = 256;

            byte[] keyByte = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] IVByte = System.Text.Encoding.UTF8.GetBytes(key);

            AESCrypto.Key = keyByte;
            AESCrypto.IV = IVByte;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, AESCrypto.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] PlainBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
            cs.Write(PlainBytes, 0, PlainBytes.Length);
            cs.Close();

            byte[] EncryptedBytes = ms.ToArray();
            return EncryptedBytes;
        }

    }
}
