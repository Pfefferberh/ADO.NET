using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Ado.net_server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SqlConnection connection = new SqlConnection();
        static string connectStr;
        string str;
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

            StackTabl.Visibility = Visibility.Hidden;

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

            StackTabl.Visibility = Visibility.Hidden;

            lbServers.Items.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbServers.Visibility = Visibility.Visible;
            if ((cbConect.SelectedItem as ComboBoxItem).Content.ToString() == "Server")
                connectStr = $@"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=false;User Id={tbLogin.Text};Password={pwbPassword.Password};";
            else
                connectStr = $"Data Source={tbServer.Text};Initial Catalog=master;Integrated Security=True";

            using (connection = new SqlConnection(connectStr))
            {
                connection.Open();
                Commander(lbServers, "select Name from sys.sysdatabases", "Name");
            }
        }
        private void lbServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbElTable.Items.Clear();
            cbTable.Items.Clear();
            if (lbServers.SelectedItem == null)
                return;
            StackTabl.Visibility = Visibility.Visible;
            str = lbServers.SelectedItem.ToString();
            using (connection = new SqlConnection(connectStr))
            {
                connection.Open();
                Commander(cbTable, $"use {lbServers.SelectedItem.ToString()}; select Name From sys.tables", "Name");
            }

        }
        private void cbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbElTable.Items.Clear();
            if (!cbTable.Items.IsEmpty)
                lbElTable_SelectionChanged(null, null);
        }
        private void Commander(Selector list, string sql, string s)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Items.Add(reader[s]);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbElTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (connection = new SqlConnection(connectStr))
            {
                connection.Open();
                Commander(lbElTable, $"use {str};  select ID From {cbTable.SelectedItem.ToString()} ", "ID");
            }
        }
    }
}
