using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    public class Worker : Department
    {
        #region Поля

        /// <summary>
        /// Должность работника.
        /// </summary>
        string position;

        #endregion

        #region Свойства

        /// <summary>
        /// Узнать должность работника.
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Единственный конструктор, так как все поля требуют заполнения.
        /// </summary>
        /// <param name="name">Имя работника.</param>
        /// <param name="parent">Подразделение работника.</param>
        /// <param name="position">Должность работника.</param>
        public Worker(string name, Department parent, string position) : base(parent.name)
        {
            this.name = name;
            this.parent = parent;
            this.position = position;
        }

        #endregion
    }
}