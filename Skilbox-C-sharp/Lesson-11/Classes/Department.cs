using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    public class Department
    {
        #region Поля

        /// <summary>
        /// Название подразделения.
        /// </summary>
        string? name;

        /// <summary>
        /// Головное подразделение.
        /// </summary>
        Department? parent;

        /// <summary>
        /// Дочерние подразделения.
        /// </summary>
        ObservableCollection<Department>? departments;

        ObservableCollection<Executor>? executors;

        #endregion

        #region Свойства

        /// <summary>
        /// Узнать название подразделения.
        /// </summary>
        public string? Name
        {
            get => name;
            set { name = value; }
        }

        /// <summary>
        /// Узнать/назначить головное подразделение.
        /// </summary>
        public Department? Parent
        {
            get => parent;
            set
            {
                if (value != null) parent = value;
            }
        }

        /// <summary>
        /// Работа со списком дочерних подразделений.
        /// </summary>
        public ObservableCollection<Department>? Departments
        {
            get => departments;
            set { if (value != null) departments = value; }
        }

        /// <summary>
        /// Работа со списком работников подразделения.
        /// </summary>
        public ObservableCollection<Executor>? Executors
        {
            get => executors;
            set { if (value != null) executors = value; }
        }

        #endregion

        #region Конструкторы.

        public Department() { }

        /// <summary>
        /// Конструктор корневого подразделения.
        /// </summary>
        /// <param name="name">Название.</param>
        public Department(string name)
        {
            this.name = name;
            departments = new ObservableCollection<Department>();
            executors = new ObservableCollection<Executor>();
        }

        /// <summary>
        /// Конструктор нового подразделения.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="parent">Головное подразделение.</param>
        public Department(string name, Department parent) : this(name)
        {
            this.parent = parent;
        }

        #endregion

        #region Методы




        #endregion
    }
}