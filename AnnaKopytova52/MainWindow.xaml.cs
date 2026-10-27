using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary1;

namespace AnnaKopytova52
{
    public partial class MainWindow : Window
    {
        private readonly Calculator _calculator = new Calculator();
        private bool _resultShown = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            string symbol = btn.Content.ToString();

            if (_resultShown) { DisplayBox.Text = "0"; _resultShown = false; }
            if (DisplayBox.Text == "0" && symbol != ".") DisplayBox.Text = "";

            DisplayBox.Text += symbol;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayBox.Text.Length > 0)
                DisplayBox.Text = DisplayBox.Text.Substring(0, DisplayBox.Text.Length - 1);
            if (string.IsNullOrEmpty(DisplayBox.Text)) DisplayBox.Text = "0";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DisplayBox.Text = "0";
            HistoryTextBlock.Text = "";
            _resultShown = false;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            string expression = DisplayBox.Text;
            try
            {
                double result = _calculator.Compute(expression);
                HistoryTextBlock.Text = expression + " =";
                DisplayBox.Text = result.ToString(CultureInfo.InvariantCulture);
                _resultShown = true;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("На ноль делить нельзя!", "Ошибка");
                Clear_Click(this, new RoutedEventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректное выражение", "Ошибка");
                Clear_Click(this, new RoutedEventArgs());
            }
        }
    }
}