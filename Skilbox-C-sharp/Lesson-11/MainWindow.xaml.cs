using Lesson_11.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Lesson_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company MyCompany;
        Department SelectDepartment = new("empty");
        ObservableCollection<Department> DepartmentsList = new();

        /// <summary>
        /// Основное окно.
        /// </summary>
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

            if (MyCompany.Departments != null)
                ComboBoxDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());

            ComboBoxSalaryList.ItemsSource = MyCompany.Position;
        }

        /// <summary>
        /// Дерево подразделений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectDepartment = (Department)CompanyTree.SelectedItem;
            DepartmentNameValue.Text = SelectDepartment.Name;
            ComboBoxDepartmentsList.SelectedItem = SelectDepartment;

            ExecutorsList.ItemsSource = SelectDepartment.Executors;
        }

        /// <summary>
        /// Изменение выбранного подразделение в общем списке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxDepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectDepartment = (Department)ComboBoxDepartmentsList.SelectedItem;

            if (SelectDepartment != null && SelectDepartment.Executors != null) ExecutorsList.ItemsSource = SelectDepartment.Executors;
        }

        /// <summary>
        /// Удаление выбранного подразделения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment.Parent != null && SelectDepartment.Parent.Departments != null)
            {
                SelectDepartment.Parent.Departments.Remove(SelectDepartment);
            }
            DepartmentsList.Remove(SelectDepartment);

            if (MyCompany.Departments != null)
                ComboBoxDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());
        }

        /// <summary>
        /// Добавление дочернего подразделение к выбранному.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDepartment != null && SelectDepartment.Departments != null && ComboBoxDepartmentsList.SelectedItem != null)
            {
                Department department = new(DepartmentNameValue.Text, SelectDepartment);
                SelectDepartment.Departments.Add(department);
                DepartmentsList.Add(department);
            }

            if (MyCompany.Departments != null)
                ComboBoxDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());
        }

        /// <summary>
        /// Добавление исполнителя в выбранное подразделение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Расчёт ЗП на выбранного исполнителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( ((Executor)ExecutorsList.SelectedItem) != null)
                switch (((Executor)ExecutorsList.SelectedItem).Position)
                {
                    case ("Руководитель"):
                        double salary = MyCompany.SalaryKalkulation(SelectDepartment);
                        if (salary * 0.15 < 1300)
                        {
                            salary = 1300;
                            SlarySelectedExecutor.Text = $"Минимальная ставка руководителя = {salary}";
                        }
                        else SlarySelectedExecutor.Text = $"15 % от {salary} = {salary * 0.15}";
                        break;
                    case ("Интерн"):
                        SlarySelectedExecutor.Text = "500";
                        break;
                    default:
                        SlarySelectedExecutor.Text = "8 x 160 = 1 280";
                        break;
                }
        }

        /// <summary>
        /// Удаление выбранного исполнителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonDeleteExecutor_Click(object sender, RoutedEventArgs e)
        {
            if (ExecutorsList.SelectedItem != null && SelectDepartment.Executors != null)
                SelectDepartment.Executors.Remove((Executor)ExecutorsList.SelectedItem);
        }

        /// <summary>
        /// Загрузить структуру компании.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonLoad_Click(object sender, RoutedEventArgs e)
        {
            MyCompany.Departments.Clear();

            MyCompany.Departments = MyCompany.DeserializeJson();

            // Да, тупой повтор кода. Но я так и не понял, как иначе привязывать источники.
            CompanyTree.ItemsSource = MyCompany.Departments;
            if (MyCompany.Departments != null)
                ComboBoxDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());
            ComboBoxSalaryList.ItemsSource = MyCompany.Position;
        }

        /// <summary>
        /// Сохранить структуру компании.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonSave_Click(object sender, RoutedEventArgs e)
        {
            if (MyCompany.Departments != null) MyCompany.SerializeJson(MyCompany.Departments);
        }
    }
}
