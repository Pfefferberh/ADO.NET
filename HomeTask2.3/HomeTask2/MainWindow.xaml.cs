using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;

namespace HomeTask2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        public List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            int j = 0;
            do
            {
                students.Add(new Student()
                {
                    Name = Connect("Select * from Student", "name")[j],
                    Surame = Connect("Select * from Student", "Surname")[j],
                    group = Connect("Select groups.Name from Student join groups on Student.idGroup=Groups.id", "Name")[j]
                });
                lbBaz.Items.Add($"{students[j].Name } " +
                            $"{students[j].Surame}  " +
                            $"{students[j].group}");
                j++;
            }
            while (j != i);
        }
        public List<string> Connect(string select, string name, bool read = true)
        {
            i = 0;
            List<string> ret = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(select, connection);
                    connection.Open();
                    if (read)
                    {
                    IAsyncResult result = command.BeginExecuteReader();
                        using (SqlDataReader reader = command.EndExecuteReader(result))
                        {


                            if (reader.HasRows)
                                while (reader.Read())
                                {
                                    ret.Add(reader[name].ToString());
                                    i++;
                                }
                        }

                    }
                    else
                    {
                        IAsyncResult result = command.BeginExecuteNonQuery();
                        command.EndExecuteNonQuery(result);


                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return ret;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Owner = this;
            foreach (var id in Connect("Select Name from groups ", "Name"))
                add.cbGroup.Items.Add(id);
            add.Show();
            lbBaz.Items.Clear();
            students.Clear();
            refresh();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbBaz.SelectedItem != null)
            {
                Connect($"delete from Student where name = '{students[lbBaz.SelectedIndex].Name}'", "name", false);
                lbBaz.Items.Clear();
                students.Clear();
                refresh();
            }
        }
    }
}
