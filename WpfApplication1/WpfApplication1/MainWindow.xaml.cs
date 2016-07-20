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
using System.Windows.Navigation;
using System.Windows.Shapes;
using test;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //textBox1.Text = textBox.Text;
            Transformer hToV = new Transformer(textBox.Text);
            string text = hToV.result;
            textBox1.Text = text.ToString();
            //throw new NotImplementedException();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Transformer hToV = new Transformer(textBox.Text);
            string text = hToV.result;
            //if(textBox1!=null)
                textBox1.Text = text.ToString();
            Clipboard.SetText(text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
