using System.Collections.Generic;
using System.Windows;

namespace HomeTask2
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         MainWindow window = Owner as MainWindow;

            window.Connect($"insert Student(name,surname,idGroup) values('{tbName.Text}','{tbSurname.Text}',(select  top(1)id from groups where groups.name='{cbGroup.SelectedItem}'))", "name", false);
            window.lbBaz.Items.Clear();
            window.students.Clear();
            window.refresh();
            this.Close();
        }
    }
}
