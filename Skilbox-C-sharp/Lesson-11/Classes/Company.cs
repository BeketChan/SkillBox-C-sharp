using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    public class Company
    {
        #region Поля

        /// <summary>
        /// Название организации.
        /// </summary>
        internal string name;

        /// <summary>
        /// Список возможных должностей с привязкой ставки по ЗП. От типа ставки жёстко привязан расчёт ЗП.
        /// </summary>
        readonly Dictionary<string, int> position = new()
        {
            {"Директор",15 },
            {"Руководитель отдела",15 },
            {"Работник",8 },
            {"Интерн",500 }
        };

        /// <summary>
        /// Коллекция подразделений организации.
        /// </summary>
        ObservableCollection<Department> departments;

        #endregion

        #region Свойства

        /// <summary>
        /// Узнать название организации.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Узнать список возможных должностей.
        /// </summary>
        public Dictionary<string, int> Position => position;

        /// <summary>
        /// Подразделения компании.
        /// </summary>
        public ObservableCollection<Department>? Departments
        {
            get => departments;
            set
            {
                if (value != null) departments = value;
            }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Создание новой компании.
        /// </summary>
        /// <param name="name">Название.</param>
        public Company(string name)
        {
            this.name = name;
            departments = new ObservableCollection<Department>() { new Department(name) };
        }

        /// <summary>
        /// Создание компании, если лень придумывать название.
        /// </summary>
        public Company()
        {
            name = "ООО Рога и Копыта.";
            departments = new ObservableCollection<Department> { new Department(name) };
        }

        #endregion
    }
}
