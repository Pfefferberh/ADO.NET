using BusisLevel.ModelDTO;
using BusisLevel.Servise;
using System;
using System.Collections.ObjectModel;
using System.Windows;
namespace UILevel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Mai : Window
    {
        private  IUnivers service;
        public ObservableCollection<StudentDTO> Students { get; set; } = new ObservableCollection<StudentDTO>();
        public ObservableCollection<GroupDTO> Groups { get; set; } = new ObservableCollection<GroupDTO>();
        public Mai(IUnivers universityService)
        {
            InitializeComponent();
            service = universityService;
            Update(universityService);
            dgStudent.DataContext = Students;
            dgGroup.DataContext = Groups;
            for (int i = 0; i < Groups.Count; i++)
            {
                cbGroup.Items.Add(Groups[i].Name);
            }
        }
        //public Mai()
        //{
        //    InitializeComponent();
        //    Update(service);
        //    dgStudent.DataContext = Students;
        //    dgGroup.DataContext = Groups;
        //    for (int i = 0; i < Groups.Count; i++)
        //    {
        //        cbGroup.Items.Add(Groups[i].Name);
        //    }
        //}
        private void Update(IUnivers universityService)
        {
            Students.Clear();
            Groups.Clear();
            var tempStud = universityService.GetStudents();
            var tempGroup = universityService.GetGroup();
            foreach (var item in tempStud)
            {
                Students.Add(item);
            }
            foreach (var item in tempGroup)
            {
                Groups.Add(item);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            StudentDTO students = new StudentDTO
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                GroupName = cbGroup.SelectedItem.ToString()
            };

            service.AddStudents(students);
            Update(service);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = "";
            tbSurname.Text = "";
            cbGroup.Text = "";
            int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;

            foreach (var item in Students)
            {
                if (item.Id == stId)
                {
                    service.DeleteStudent(item);
                    break;
                }

            }
            Update(service);
        }

        private void btnUpDate_Click(object sender, RoutedEventArgs e)
        {
            int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;

            foreach (var item in Students)
            {
                if (item.Id == stId)
                {
                    item.Surname = tbSurname.Text;
                    item.Name = tbName.Text;
                    item.GroupName = cbGroup.SelectedItem.ToString();
                    service.UpdateStudent(item);
                    break;
                }
            }
            Update(service);
        }

        private void dgStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;

                foreach (var item in Students)
                {
                    if (item.Id == stId)
                    {
                        tbName.Text = item.Name;
                        tbSurname.Text = item.Surname;
                        cbGroup.Text = item.GroupName;
                        break;
                    }
                }
            }
            catch (Exception ex) { };
        }
    }
}
