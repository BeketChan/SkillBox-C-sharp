using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    public struct Worker
    {
        #region Свойства

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Зарплата.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Количество проектов.
        /// </summary>
        public int Projects { get; private set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Карточка работника.
        /// </summary>
        /// <param name="LastName">Фамилия.</param>
        /// <param name="FirstName">Имя.</param>
        /// <param name="Position">Должность.</param>
        /// <param name="Salary">Зарплата.</param>
        /// <param name="Projects">Количесвто проектов.</param>
        public Worker(string LastName,
                      string FirstName,
                      string Position,
                      double Salary,
                      int Projects)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Position = Position;
            this.Salary = Salary;
            this.Projects = Projects;
        }

        #endregion
    }
}
