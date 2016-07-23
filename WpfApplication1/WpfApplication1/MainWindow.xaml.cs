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
        public Transformer hToV = new Transformer();
        int row;
        int column;

        public MainWindow()
        {
            InitializeComponent();
            row = 8;
            column = 7;
            hToV.setBlockSize(row, column);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string output = "";
            string input = textBox.Text;

            int count = input.Length;
            int capacity = row * column;
            int components = (int)Math.Ceiling((double)count / capacity);

            string textPart;
            for (int i = 0; i < components; i++)
            {
                int startIndex = i * capacity;
                if (count - startIndex < capacity)
                {
                    textPart = input.Substring(startIndex, count - startIndex);
                }
                else
                {
                    textPart = input.Substring(startIndex, capacity);
                }
                hToV.transform(textPart);
                output = output  + hToV.result + "\n";
            }
            textBox1.Text = output;
            Clipboard.SetText(output);
        }
    }
}
