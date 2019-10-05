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

namespace Polish_Worder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string WordInputBoxDefaultText;

        public MainWindow()
        {
            InitializeComponent();
            WordInputBoxDefaultText = WordInputBox.Text;
        }

        private void UserInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(WordInputBox.Text))
            {
                WordInputBox.Foreground = Brushes.Gray;
                WordInputBox.Text = WordInputBoxDefaultText;
            }
        }

        private void MarkedText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (WordInputBox.Text == WordInputBoxDefaultText)
            {
                WordInputBox.Text = string.Empty;
                WordInputBox.Foreground = Brushes.Black;
            }
        }

        private void Anagram_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
