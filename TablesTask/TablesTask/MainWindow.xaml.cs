using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace TablesTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        List<DataTable> tb = new List<DataTable>();
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            DataTable head = new DataTable();
            ReadDb(connection, head, "select name from sys.tables");

            foreach (DataRow item in head.Rows)
                tb.Add(new DataTable() { TableName = item.ItemArray[0].ToString() });

            foreach (var item in tb)
            {
                ReadDb(connection, item, $"select * from {item}");
                tbContr.Items.Add(new TabItem() { Header = item.TableName, Content = new DataGrid() { ItemsSource = item.DefaultView } });
            }
        }
        private void ReadDb(SqlConnection connection, DataTable table, string commandStr)
        {
            SqlCommand command = new SqlCommand(commandStr, connection);
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        do
                        {
                            int line = 0;
                            while (reader.Read())
                            {
                                if (line == 0)
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        table.Columns.Add(reader.GetName(i));
                                    }
                                    line++;
                                }
                                DataRow row = table.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader[i];
                                }
                                table.Rows.Add(row);
                            }
                        } while (reader.NextResult());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSaveXML_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in tb)
                item.WriteXml($"{item.TableName}.xml");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataGrid way = ((tbContr.SelectedItem as TabItem).Content as DataGrid);
            if ( !string.IsNullOrEmpty(way.SelectedValue.ToString()) )
            {
                //Title = (way.Items.Count).ToString();// as DataRowView).Row.ItemArray.Length.ToString();
               //Title= (way.SelectedValue as DataRowView).DataView.Count.ToString();

               (way.SelectedValue as DataRowView).DataView.Delete(Convert.ToInt32((way.SelectedValue as DataRowView).Row.ItemArray[0].ToString())-1);
                //SqlCommand command = new SqlCommand($"Delete {(tbContr.SelectedItem as TabItem).Header.ToString()} where Id = {(way.SelectedValue as DataRowView).Row.ItemArray[0].ToString()}", connection);
                //command.ExecuteNonQuery();
            }
            else
                Title = "trere";
        }

    }
}
