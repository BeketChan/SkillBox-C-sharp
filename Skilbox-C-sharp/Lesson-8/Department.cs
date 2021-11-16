using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    public struct Department
    {
        #region Поля

        string name;
        private Worker[] workers; // Массив работников
        int index;                // Индекс для нового работника.
        string[] titles;          // Список полей-заголовков.

        #endregion

        #region Конструкторы
        
        /// <summary>
        /// Констрктор.
        /// </summary>
        /// <param name="s">Название отдела.</param>
        public Department(string s)
        {
            name = s;
            index = 0;
            titles = new string[6] { "ID", "Фамилия", "Имя", "Должность", "Зарплата", "Проекты" };
            workers = new Worker[1];
        }

        #endregion
    }
}
