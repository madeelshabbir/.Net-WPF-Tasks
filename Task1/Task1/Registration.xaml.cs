using System;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace Task1
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            Application.Current.Windows[0].Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text.Length == 0 || LastName.Text.Length == 0 || Email.Text.Length == 0 || Password.Password.Length == 0 || ConfPassword.Password.Length == 0)
            {
                MessageBox.Show("Empty Field(s) Available!");
                return;
            }
            if (0 < Email.Text.IndexOf('@') && Email.Text.IndexOf('@') + 1 < Email.Text.IndexOf('.') && Email.Text.IndexOf('.') < Email.Text.Length - 1) ;
            else
            {
                MessageBox.Show("Invalid Email!");
                return;
            }
            if (Password.Password.Length < 8)
            {
                MessageBox.Show("Password must have 8 or more charracters!");
                return;
            }
            if (!Password.Password.Equals(ConfPassword.Password))
            {
                MessageBox.Show("Password Mismatch!");
                return;
            }
            try
            {
                string connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = $"insert into Users(FirstName, LastName, Email,  Password) values('{FirstName.Text}', '{LastName.Text}', '{Email.Text}', '{Password.Password}')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    (new MainWindow()).Show();
                    Application.Current.Windows[0].Close();
                    MessageBox.Show("User Successfully Registered!");
                }
                else
                    MessageBox.Show("Email already Exist");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
