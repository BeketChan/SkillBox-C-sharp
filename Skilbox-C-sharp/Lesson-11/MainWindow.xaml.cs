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

            CompanyTree.ItemsSource = MyCompany.Departments;

            if (MyCompany.Departments != null)
            {
                ComboBoxDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());
                ExecutorDepartmentsList.ItemsSource = MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>());

                AllExecutorsList.ItemsSource = MyCompany.ExecutorsList(MyCompany.Departments[0], new List<Executor>());
            }   

            ComboBoxSalaryList.ItemsSource = MyCompany.Position;
            ExecutorPositionList.ItemsSource = MyCompany.Position;
        }

        /// <summary>
        /// Дерево подразделений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectDepartment = (Department)CompanyTree.SelectedItem;

            if (SelectDepartment != null && SelectDepartment.Executors != null)
            {
                DepartmentNameValue.Text = SelectDepartment.Name;

                ComboBoxDepartmentsList.SelectedItem = SelectDepartment;

                ExecutorsList.ItemsSource = SelectDepartment.Executors;
            }
        }

        /// <summary>
        /// Изменение выбранного подразделение в общем списке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxDepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectDepartment = (Department)ComboBoxDepartmentsList.SelectedItem;

            if (SelectDepartment != null && SelectDepartment.Executors != null)
            {
                ExecutorsList.ItemsSource = SelectDepartment.Executors;
            }
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
            if (SelectDepartment != null &&
                SelectDepartment.Departments != null &&
                ComboBoxDepartmentsList.SelectedItem != null)
            {
                Department department = new(DepartmentNameValue.Text, SelectDepartment);

                if (!MyCompany.DepartmentUnique(department))
                {
                    SelectDepartment.Departments.Add(department);
                    DepartmentsList.Add(department);
                }
            }
        }

        /// <summary>
        /// Добавление исполнителя в выбранное подразделение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonAddExecutor_Click(object sender, RoutedEventArgs e)
        {
            Executor exe;
            switch (((KeyValuePair<string, int>)ComboBoxSalaryList.SelectedValue).Key)
            {
                case "Руководитель":
                    exe = new Director(ExecutorNameValue.Text, SelectDepartment.Name);
                    break;
                case "Интерн":
                    exe = new Intern(ExecutorNameValue.Text, SelectDepartment.Name);
                    break;
                default:
                    exe = new Worker(ExecutorNameValue.Text, SelectDepartment.Name);
                    break;
            }

            if(!MyCompany.ExecutorsList(MyCompany.Departments[0], new List<Executor>()).Contains(exe))
                MyCompany.AddExecutor(SelectDepartment, exe);
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
            if (MyCompany.Departments != null) MyCompany.Departments.Clear();
            MyCompany.Departments = MyCompany.DeserializeJson();

            CompanyTree.ItemsSource = MyCompany.Departments;
            if (MyCompany.Departments != null)
            {
                ComboBoxDepartmentsList.ItemsSource = MyCompany.SortDepList(MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>()));
                ExecutorDepartmentsList.ItemsSource = MyCompany.SortDepList(MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>()));

                List<Executor> list = MyCompany.ExecutorsList(MyCompany.Departments[0], new List<Executor>());
                AllExecutorsList.ItemsSource = MyCompany.ListToObs(list);
            }   
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

        /// <summary>
        /// Варианты сортировка общего списка работников.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyCompany != null && MyCompany.Departments != null && SortType != null && SortType.SelectedItem != null)
            {
                string sortType = ((TextBlock)SortType.SelectedItem).Text;
                List<Executor> list = MyCompany.ExecutorsList(MyCompany.Departments[0], new List<Executor>());

                switch (sortType)
                {
                    case "По имени":
                        list.Sort(Executor.SortedBy(SortedCriterion.Name));
                        AllExecutorsList.ItemsSource = MyCompany.ListToObs(list);
                        break;
                    case "По подразделению":
                        list.Sort(Executor.SortedBy(SortedCriterion.Parent));
                        AllExecutorsList.ItemsSource = MyCompany.ListToObs(list);
                        break;
                    default:
                        list.Sort(Executor.SortedBy(SortedCriterion.Position));
                        AllExecutorsList.ItemsSource = MyCompany.ListToObs(list);
                        break;
                }
            }
        }

        /// <summary>
        /// Выбор исполнителя из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllExecutorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Executor selected = (Executor)AllExecutorsList.SelectedItem;

            ExecuturNameValue.Text = selected.Name;

            for(int i = 0; i < ExecutorDepartmentsList.Items.Count; i++)
                if (((Department)ExecutorDepartmentsList.Items[i]).Name == selected.Parent)
                    ExecutorDepartmentsList.SelectedIndex = i;

            for(int i = 0; i < ExecutorPositionList.Items.Count; i++)
                if (((KeyValuePair<string, int>)ExecutorPositionList.Items[i]).Key == selected.Position)
                    ExecutorPositionList.SelectedIndex = i;
        }

        /// <summary>
        /// Применить изменения в выбранном исполнителе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutorCommit_Click(object sender, RoutedEventArgs e)
        {
            Executor selected = (Executor)AllExecutorsList.SelectedItem;

            ObservableCollection<Department> depList = MyCompany.SortDepList(MyCompany.DepartmentsList(MyCompany.Departments[0], new ObservableCollection<Department>()));
            Department departmentOld = new();
            foreach(Department d in depList)
                if(d.Name == selected.Parent)
                    departmentOld = d;

            Department departmentNew = (Department)ExecutorDepartmentsList.SelectedItem;
            
            if (!( ((KeyValuePair<string, int>)ExecutorPositionList.SelectedItem).Key == "Руководитель" && Company.CheckDirectorInDepartment(departmentNew)) && departmentNew.Executors != null)
            {
                if (departmentOld.Name != departmentNew.Name)
                {
                    departmentOld.Executors.Remove(selected);
                    departmentNew.Executors.Add(selected);
                    selected.Parent = departmentNew.Name;
                }

                if (((KeyValuePair<string, int>)ExecutorPositionList.SelectedItem).Key != selected.Position)
                {
                    selected.Position = ((KeyValuePair<string, int>)ExecutorPositionList.SelectedItem).Key;
                }
            }

            List<Executor> list = MyCompany.ExecutorsList(MyCompany.Departments[0], new List<Executor>());
            AllExecutorsList.ItemsSource = MyCompany.ListToObs(list);
        }
    }
}
