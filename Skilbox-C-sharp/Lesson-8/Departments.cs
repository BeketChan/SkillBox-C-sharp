using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    public class Departments
    {
        #region Поля и свойства

        /// <summary>
        /// Лиминт на количество сотрудников.
        /// </summary>
        public int WorkerLimit = 1_000_000;

        /// <summary>
        /// Наименование подразделения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания подразделения.
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Текущее количество сотрудников.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Departments() { }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="Name">Название подразделения.</param>
        public Departments(string Name)
        {
            this.Name = Name;
            CreateDate = DateTime.Now;
            Count = 0;
        }

        #endregion
    }
}
