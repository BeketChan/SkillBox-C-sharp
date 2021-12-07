using Lesson_11.Classes;
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
        readonly Company MyCompany;
        Department SelectDepartment = new("empty");
        readonly ObservableCollection<Department> DepartmentsList = new();

        public MainWindow()
        {
            InitializeComponent();

            DepartmentsList.Clear();
            MyCompany = new Company();
            if (MyCompany.Departments != null)
            {
                SelectDepartment = MyCompany.Departments[0];
                DepartmentsList.Add(SelectDepartment);
            }

            CompanyTree.ItemsSource = MyCompany.Departments; // пробовал убрать - не работает
            ComboBoxDepartmentsList.ItemsSource = DepartmentsList;
            ComboBoxSalaryList.ItemsSource = MyCompany.Position;
        }

        private void CompanyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectDepartment = (Department)CompanyTree.SelectedItem;
            DepartmentNameValue.Text = SelectDepartment.Name;
            ComboBoxDepartmentsList.SelectedItem = SelectDepartment;

            ExecutorsList.ItemsSource = SelectDepartment.Executors;
        }

        private void ComboBoxDepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectDepartment = (Department)ComboBoxDepartmentsList.SelectedItem;

            if (SelectDepartment.Executors != null) ExecutorsList.ItemsSource = SelectDepartment.Executors;
        }

        private void BottonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment.Parent != null && SelectDepartment.Parent.Departments != null)
            {
                SelectDepartment.Parent.Departments.Remove(SelectDepartment);
            }
            DepartmentsList.Remove(SelectDepartment);
        }

        private void BottonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment != null && SelectDepartment.Departments != null && ComboBoxDepartmentsList.SelectedItem != null)
            {
                Department department = new(DepartmentNameValue.Text, SelectDepartment);
                SelectDepartment.Departments.Add(department);
                DepartmentsList.Add(department);
            }
        }

        private void BottonAddExecutor_Click(object sender, RoutedEventArgs e)
        {
            switch (((KeyValuePair<string, int>)ComboBoxSalaryList.SelectedValue).Key)
            {
                case "Руководитель":
                    Company.AddExecutor(SelectDepartment, new Director(ExecutorNameValue.Text, SelectDepartment));
                    break;
                case "Интерн":
                    Company.AddExecutor(SelectDepartment, new Intern(ExecutorNameValue.Text, SelectDepartment));
                    break;
                default:
                    Company.AddExecutor(SelectDepartment, new Worker(ExecutorNameValue.Text, SelectDepartment));
                    break;
            }
        }

        private void ExecutorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( ((Executor)ExecutorsList.SelectedItem) != null)
                switch (((Executor)ExecutorsList.SelectedItem).Position)
                {
                    case ("Руководитель"):
                        // Я не делал проверку на минималку ЗП руководителя. Просто чтоб видеть работу процентовки.
                        SlarySelectedExecutor.Text = $"15 % от {MyCompany.SalaryKalkulation(SelectDepartment)} = {MyCompany.SalaryKalkulation(SelectDepartment) * 0.15}";
                        break;
                    case ("Интерн"):
                        SlarySelectedExecutor.Text = "500";
                        break;
                    default:
                        SlarySelectedExecutor.Text = "8 x 160 = 1 280";
                        break;
                }
        }

        private void BottonDeleteExecutor_Click(object sender, RoutedEventArgs e)
        {
            if (ExecutorsList.SelectedItem != null && SelectDepartment.Executors != null)
                SelectDepartment.Executors.Remove((Executor)ExecutorsList.SelectedItem);
        }

        private void BottonLoad_Click(object sender, RoutedEventArgs e)
        {
            MyCompany.Departments = MyCompany.DeserializeJson();
        }

        private void BottonSave_Click(object sender, RoutedEventArgs e)
        {
            if (MyCompany.Departments != null) MyCompany.SerializeJson(MyCompany.Departments);
        }
    }
}
