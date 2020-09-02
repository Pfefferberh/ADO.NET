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
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    DbCommand command = factory.CreateCommand();
                    command.CommandText = select;
                    command.Connection = connection;
                    if (read)
                    {
                        DbDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                ret.Add(reader[name].ToString());
                                i++;
                            }
                    }
                    else
                    {
                        command.ExecuteNonQuery();
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
