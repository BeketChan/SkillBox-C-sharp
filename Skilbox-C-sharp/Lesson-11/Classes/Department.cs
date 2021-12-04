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
        //protected string name;
        internal string name;

        /// <summary>
        /// Головное подразделение.
        /// </summary>
        internal Department? parent;

        /// <summary>
        /// Дочерние подразделения.
        /// </summary>
        ObservableCollection<Department>? departments;

        /// <summary>
        /// Руководитель. Может быть только 1 на отдел.
        /// </summary>
        Worker? miniBoss;

        #endregion

        #region Свойства

        /// <summary>
        /// Узнать название подразделения.
        /// </summary>
        public string Name => name;

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
            set
            {
                if (value != null) departments = value;
            }
        }

        /// <summary>
        /// Узнать/назначить руководителя подразделения.
        /// </summary>
        public Worker? MiniBoss
        {
            get => miniBoss;
            set
            {
                if (value != null) miniBoss = value;
            }
        }

        /// <summary>
        /// Имя руководителя.
        /// </summary>
        public string? MiniBossName
        {
            get
            {
                if (miniBoss != null) return miniBoss.Name;
                else return null;
            }
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Конструктор корневого подразделения.
        /// </summary>
        /// <param name="name">Название.</param>
        public Department(string name)
        {
            this.name = name;
            departments = new ObservableCollection<Department>();
        }

        /// <summary>
        /// Конструктор нового подразделения.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="parent">Головное подразделение.</param>
        public Department(string name, Department parent)
        {
            this.name = name;
            this.parent = parent;
            departments = new ObservableCollection<Department>();
        }

        #endregion
    }
}