using System;
using System.Collections.Generic;

namespace Lesson_11
{
    /// <summary>
    /// Варианты сортировок
    /// </summary>
    public enum SortedCriterion
    {
        Name,
        Parent,
        Position
    }

    /// <summary>
    /// Класс описывающий работника.
    /// </summary>
    public abstract class Executor : IEquatable<Executor>
    {
        #region Поля

        string? name;
        string? position;
        string? parent;
        int? salary;

        #endregion

        #region Свойства

        /// <summary>
        /// Имя работника
        /// </summary>
        public string? Name
        {
            get => name;
            set => name = value; 
        }

        /// <summary>
        /// Должность работника
        /// </summary>
        public string? Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Подразделение работника
        /// </summary>
        public string? Parent
        {
            get => parent;
            set => parent = value;
        }

        /// <summary>
        /// Ставка зарпллаты.
        /// </summary>
        /// <returns></returns>
        public int? Salary
        {
            get => salary;
            set => salary = value;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Новый работник.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="position">Должность.</param>
        /// <param name="parent">Подразделение.</param>
        public Executor(string name, string position, string parent, int salary)
        {
            this.name = name;
            this.position = position;
            this.parent = parent;
            this.salary = salary;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Реализация интерфейса сравнения.
        /// </summary>
        /// <param name="other">Сравниваемый исполнитель.</param>
        /// <returns></returns>
        public bool Equals(Executor? other)
        {
            if (other != null) return this.Name == other.Name;
            else return false;
        }

        #endregion

        #region Вложенные классы

        /// <summary>
        /// Сортировка по имени.
        /// </summary>
        private class SortByName : IComparer<Executor>
        {
            public int Compare(Executor? x, Executor? y)
            {
                Executor X = x as Executor;
                Executor Y = y as Executor;

                return String.Compare(X.Name, Y.Name);
            }
        }

        /// <summary>
        /// Сортировка по подразделению.
        /// </summary>
        private class SortByParent : IComparer<Executor>
        {
            public int Compare(Executor? x, Executor? y)
            {
                Executor X = x as Executor;
                Executor Y = y as Executor;

                return String.Compare(X.Parent, Y.Parent);
            }
        }

        /// <summary>
        /// Сортировка по должности.
        /// </summary>
        private class SortByPosition : IComparer<Executor>
        {
            public int Compare(Executor? x, Executor? y)
            {
                Executor X = x as Executor;
                Executor Y = y as Executor;

                return String.Compare(X.Position, Y.Position);
            }
        }

        public static IComparer<Executor> SortedBy(SortedCriterion criterion)
        {
            switch (criterion)
            {
                case SortedCriterion.Name: return new SortByName();
                case SortedCriterion.Parent: return new SortByParent();
                default: return new SortByPosition();
            }
        }

        #endregion
    }
}