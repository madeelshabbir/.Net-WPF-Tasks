using System;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Task1
{
    /// <summary>
    /// Interaction logic for ShowUsers.xaml
    /// </summary>
    public partial class ShowUsers : Window
    {
        public ShowUsers()
        {
            InitializeComponent();
            try
            {
                string connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = $"select FirstName as 'First Name', LastName 'Last Name', Email from Users";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("Users");
                adp.Fill(table);
                UsersData.ItemsSource = table.DefaultView;
                adp.Update(table);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            Application.Current.Windows[0].Close();
        }
    }
}
