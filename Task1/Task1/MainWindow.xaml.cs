using System.Windows;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new Registration()).Show();
            Application.Current.Windows[0].Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (new ShowUsers()).Show();
            Application.Current.Windows[0].Close();
        }
    }
}
