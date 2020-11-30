using System.Collections.ObjectModel;
using System.Windows;


namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> list1;
        ObservableCollection<string> list2;
        public MainWindow()
        {
            InitializeComponent();
            list1 = new ObservableCollection<string>();
            list2 = new ObservableCollection<string>();
            LstBox1.ItemsSource = list1;
            LstBox2.ItemsSource = list2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!TxtBox1.Text.Equals(""))
                list1.Add(TxtBox1.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!TxtBox2.Text.Equals(""))
                list1.Add(TxtBox2.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (LstBox1.SelectedItem != null)
            {
                string selectedItem = LstBox1.SelectedItem.ToString();
                list2.Add(selectedItem);
                list1.Remove(selectedItem);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (string i in list1)
                list2.Add(i);
            list1.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (LstBox2.SelectedItem != null)
            {
                string selectedItem = LstBox2.SelectedItem.ToString();
                list1.Add(selectedItem);
                list2.Remove(selectedItem);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            foreach(string i in list2)
                list1.Add(i);
            list2.Clear();
        }
    }
}
