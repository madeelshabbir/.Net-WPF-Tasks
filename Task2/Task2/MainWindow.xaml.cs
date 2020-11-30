using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Resources/eye.png"), UriKind.Absolute);
            src.EndInit();
            EyeImage.Source = src;
            Binding bind = new Binding("Password");
            bind.Source = PassBox;
            bind.Mode = BindingMode.OneWayToSource;
            TxtBox.SetBinding(TextBox.TextProperty,bind);
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PassBox.Visibility = System.Windows.Visibility.Collapsed;
            TxtBox.Text = PassBox.Password;
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            PassBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserBox.Text.ToString().Equals("admin") && PassBox.Password.ToString().Equals("admin"))
            {
                MessageBox.Show("Signed In Successfully!");
                return;
            }
            MessageBox.Show("Invalid User or Password!");
        }
    }
}