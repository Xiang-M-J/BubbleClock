using System;
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
using System.Windows.Shapes;

namespace TextShine
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        public delegate void SendMessage(string []Color);
        public SendMessage sendMessage;
        public Setting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] Color = new string[3] {
            "#00000000","#FF0092BC","#FF277AD4"};

            if(textBox.Text!=""){
                Color[0] = textBox.Text;
            }
            if(textBox1.Text!=""){
                Color[1] = textBox1.Text;
            }
            if (textBox2.Text != ""){
                Color[2] = textBox2.Text;
            }
            
            sendMessage(Color);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.matools.com/color/");
            }
            catch
            {
                MessageBox.Show("Somthing worry just happpen");
            }
        }
    }
}
