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
        private Button ActiveButton;

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
            MakeButtonActive(sender);
            MakeButtonInactive(Palindrome);
            ActiveButton = (Button)sender;
        }

        private void Palindrome_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonActive(sender);
            MakeButtonInactive(Anagram);
            ActiveButton = (Button)sender;
        }

        private void MakeButtonActive(object sender)
        {
            Button button = sender as Button;
            button.Background = Brushes.DarkGreen;
            button.FontWeight = FontWeights.Bold;
            button.BorderThickness = new Thickness(5);
            button.IsEnabled = false;
        }

        private void MakeButtonInactive(object sender)
        {
            Button button = sender as Button;
            button.Background = Brushes.LightGray;
            button.FontWeight = default(FontWeight);
            button.BorderThickness = new Thickness(1);
            button.IsEnabled = true;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(ActiveButton == Anagram)
            {
                FindAnagrams();
            }
            else if(ActiveButton == Palindrome)
            {
                FindPalandroms();
            }
        }

        private void FindAnagrams()
        {

        }

        private void FindPalandroms()
        {

        }
    }
}
