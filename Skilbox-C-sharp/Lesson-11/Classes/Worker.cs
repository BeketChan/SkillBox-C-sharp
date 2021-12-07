using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11.Classes
{
    internal class Worker : Executor
    {
        #region Поля

        int salary;

        #endregion

        #region Свойства

        /// <summary>
        /// Ставка ЗП работника
        /// </summary>
        public int Salary
        {
            get => salary;
            set => salary = value;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Руководитель подразделения.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="parent">Подразделение.</param>
        public Worker(string name, Department parent) : base(name, "Работник", parent)
        {
            salary = 8;
        }

        #endregion
    }
}
