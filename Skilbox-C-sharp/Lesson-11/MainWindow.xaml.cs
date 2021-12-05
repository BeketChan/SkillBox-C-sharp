using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Company Company;
        Department SelectDepartment = new("empty");
        readonly ObservableCollection<Department> DepartmentsList = new();

        public MainWindow()
        {
            InitializeComponent();

            DepartmentsList.Clear();
            Company = new Company();
            if (Company.Departments != null)
            {
                SelectDepartment = Company.Departments[0];
                DepartmentsList.Add(SelectDepartment);
            }

            CompanyTree.ItemsSource = Company.Departments; // пробовал убрать - не работает
            ComboBoxDepartmentsList.ItemsSource = DepartmentsList;
            ComboBoxSalaryList.ItemsSource = Company.Position;
        }

        private void CompanyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectDepartment = (Department)CompanyTree.SelectedItem;
            TextNameValue.Text = SelectDepartment.Name;
            ComboBoxDepartmentsList.SelectedItem = SelectDepartment.Parent;
        }
        private void ComboBoxDepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectDepartment = (Department)ComboBoxDepartmentsList.SelectedItem;
        }

        private void BottonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment.Parent != null && SelectDepartment.Parent.Departments != null)
            {
                SelectDepartment.Parent.Departments.Remove(SelectDepartment);
            }
            DepartmentsList.Remove(SelectDepartment);
            //DepartmentsListRemuve(SelectDepartment);
        }

        void DepartmentsListRemuve(Department dep)
        {
            if (dep != null && dep.Departments == null)
                DepartmentsList.Remove(dep);

            if (dep != null && dep.Departments != null)
                for (int n = 0; n < dep.Departments.Count; n++)
                {
                    DepartmentsListRemuve(dep.Departments[n]);
                }
        }

        private void BottonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment != null && SelectDepartment.Departments != null && ComboBoxDepartmentsList.SelectedItem != null)
            {
                Department department = new(TextNameValue.Text, SelectDepartment);
                SelectDepartment.Departments.Add(department);
                DepartmentsList.Add(department);
            }
        }

        private void BottonAddWorker_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment != null && SelectDepartment.Departments != null && ComboBoxDepartmentsList.SelectedItem != null)
            {
                KeyValuePair<string, int> val = (KeyValuePair<string, int>)ComboBoxSalaryList.SelectedItem;

                Worker worker = new(TextNameValue.Text, (Department)ComboBoxDepartmentsList.SelectedItem, val.Key);

                if (SelectDepartment.MiniBoss == null)
                    if (val.Key == "Директор" || val.Key == "Руководитель отдела")
                    {
                        SelectDepartment.MiniBoss = worker;
                        test.Text = $"1 {SelectDepartment.Name}";
                    }   
                else
                    if (val.Key == "Директор" || val.Key == "Руководитель отдела")
                    {
                        worker.Position = "Работник";
                        test.Text = $"2 {SelectDepartment.Name}";
                    }
                        

                SelectDepartment.Departments.Add(worker);

                //test.Text = SelectDepartment.MiniBossName;
            }
        }
    }
}
