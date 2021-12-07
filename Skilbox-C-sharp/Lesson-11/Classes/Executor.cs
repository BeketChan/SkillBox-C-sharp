using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    public abstract class Executor
    {
        #region Поля

        string name;
        string position;
        Department parent;

        #endregion

        #region Свойства

        /// <summary>
        /// Имя работника
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value; 
        }

        /// <summary>
        /// Должность работника
        /// </summary>
        public string Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Подразделение работника
        /// </summary>
        public Department Parent
        {
            get => parent;
            set => parent = value;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Новый работник.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="position">Должность.</param>
        /// <param name="parent">Подразделение.</param>
        public Executor(string name, string position, Department parent)
        {
            this.name = name;
            this.position = position;
            this.parent = parent;
        }

        #endregion
    }
}