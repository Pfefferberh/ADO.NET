using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Ado.net_server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmb1_Selected(object sender, RoutedEventArgs e)
        {
            lServ.Visibility = Visibility.Visible;
            tbServer.Visibility = Visibility.Visible;

            lLog.Visibility = Visibility.Hidden;
            tbLogin.Visibility = Visibility.Hidden;

            lPass.Visibility = Visibility.Hidden;
            pwbPassword.Visibility = Visibility.Hidden;

            lbServers.Visibility = Visibility.Hidden;

            tbServer.Text = "";
            bConnect.Visibility = Visibility.Visible;

            lbServers.Items.Clear();
        }
        private void cmb2_Selected(object sender, RoutedEventArgs e)
        {
            lServ.Visibility = Visibility.Visible;
            tbServer.Visibility = Visibility.Visible;

            lLog.Visibility = Visibility.Visible;
            tbLogin.Visibility = Visibility.Visible;

            lPass.Visibility = Visibility.Visible;
            pwbPassword.Visibility = Visibility.Visible;

            lbServers.Visibility = Visibility.Hidden;

            tbLogin.Text = "";
            tbServer.Text = "";
            pwbPassword.Password = "";
            bConnect.Visibility = Visibility.Visible;

            lbServers.Items.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbServers.Visibility = Visibility.Visible;
            string connectStr;
            if ((cbConect.SelectedItem as ComboBoxItem).Content.ToString() == "Server")
                connectStr = $@"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=false;User Id={tbLogin.Text};Password={pwbPassword.Password};";
            else
                connectStr = $"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=True";

            using (SqlConnection connection=new SqlConnection(connectStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Name from sys.sysdatabases", connection);
                    SqlDataReader reader= command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lbServers.Items.Add(reader["Name"]);
                        }
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lbServers_Selected(object sender, RoutedEventArgs e)
        {
            string connectStr;
            if ((cbConect.SelectedItem as ComboBoxItem).Content.ToString() == "Server")
                connectStr = $@"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=false;User Id={tbLogin.Text};Password={pwbPassword.Password};";
            else
                connectStr = $"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Name from sys.sysdatabases", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lbServers.Items.Add(reader["Name"]);
                        }
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
