using System;

namespace Lesson_13.Classes.Accaunt_Classes
{
    public class Accaunt : IEquatable<Accaunt>, IComparable<Accaunt>
    {
        #region Поля

        /// <summary>
        /// Наименование счёта.
        /// </summary>
        string? name;

        /// <summary>
        /// Текущее состояние счёта.
        /// </summary>
        double? currentValue;

        #endregion

        #region Свойства

        /// <summary>
        /// Название / Номер счёта.
        /// </summary>
        public string? Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Работать с текущим состоянием счёта.
        /// </summary>
        public double? CurrentValue
        {
            get => currentValue;
            set => currentValue = value;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        public Accaunt() { }

        /// <summary>
        /// Новый счёт.
        /// </summary>
        /// <param name="name"></param>
        public Accaunt(string name)
        {
            Name = name;
            CurrentValue = 0;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Реализация интерфейса сравнения.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Accaunt? other)
        {
            if (other != null) return Name == other.Name;
            else return false;
        }

        /// <summary>
        /// Реализация интерфейса сортировки.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Accaunt? other)
        {
            if (other is null || Name is null)
                throw new ArgumentNullException(nameof(other));
            return Name.CompareTo(other.Name);
        }

        #endregion
    }
}
