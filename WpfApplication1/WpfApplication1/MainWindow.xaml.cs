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
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        private void textBox_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_row.Text != "")
            {
                row = Int16.Parse(textBox_row.Text);
                hToV = new Transformer();
                hToV.setBlockSize(row, column);
                getOutput(textBox.Text);
            }
        }

        private void textBox_column_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_column.Text != "")
            {
                column = Int16.Parse(textBox_column.Text);
                hToV = new Transformer();
                hToV.setBlockSize(row, column);
                getOutput(textBox.Text);
            }   
        }

        private string getOutput(string input)
        {
            string output= "";
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
                output = output + hToV.result + "\n";
            }
            textBox1.Text = output;
            Clipboard.SetText(output);
            return output;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = textBox.Text;
            string output = getOutput(input);
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.Enter))
                switchToWechart();
        }

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);
        String ProcWindow = "wechat";
        private void switchToWechart()
        {
            Process[] procs = Process.GetProcessesByName(ProcWindow);
            foreach (Process proc in procs)
            {
                //switch to process by name
                SwitchToThisWindow(proc.MainWindowHandle, true);
            }
        }

        private void textBox_row_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Up))
                textBox_row.Text = (row + 1).ToString();
            else if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Down) && row > 1)
                textBox_row.Text = (row - 1).ToString();
        }

        private void textBox_column_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Up))
                textBox_column.Text = (column + 1).ToString();
            else if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Down) && column > 1)
                textBox_column.Text = (column - 1).ToString();
        }
    }
}
