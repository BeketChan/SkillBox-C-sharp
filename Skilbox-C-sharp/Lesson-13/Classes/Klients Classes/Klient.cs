using Lesson_13.Classes.Accaunt_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_13.Classes.Klients_Classes
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Klient<T> : IEquatable<Klient<T>>, IComparable<Klient<T>>, INewAccCovariant<T>
        where T : Accaunt, new()
    {
        #region Поля

        /// <summary>
        /// Наименование клиента
        /// </summary>
        string? name;

        /// <summary>
        /// Список счетов клиента.
        /// </summary>
        List<T>? deposits;

        #endregion

        #region Свойства

        /// <summary>
        /// Получить наименование клиента
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Получить список счетов клиента.
        /// </summary>
        public ObservableCollection<T>? Deposits
        {
            get
            {
                ObservableCollection<T> dep = new();
                foreach (T d in deposits)
                    dep.Add(d);
                return dep;
            }
            set
            {
                if (value != null)
                {
                    deposits.Clear();
                    foreach (T E in value)
                        deposits.Add(E);
                }
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        //public Klient() { }

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="name"></param>
        public Klient(string name)
        {
            this.name = name;
            deposits = new List<T>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Реализация интерфейса сравнения.
        /// </summary>
        /// <param name="other">Сравниваемый клиент.</param>
        /// <returns></returns>
        public bool Equals(Klient<T>? other)
        {
            if (other != null) return this.Name == other.Name;
            else return false;
        }

        /// <summary>
        /// Реализация интерфейса сортировки клиентов.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int CompareTo(Klient<T>? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Реализация интерфейса создания нового счёта.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T NewAcc(string name)
        {
            Accaunt acc = new(name);
            return (T)acc;
        }

        /// <summary>
        /// Правило преобразования для Individual.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator Klient<T>(Individual v)
        {
            return new Klient<T>(v.Name);
        }

        /// <summary>
        /// Правило преобразования для IndividualVip.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator Klient<T>(IndividualVip v)
        {
            return new Klient<T>(v.Name);
        }

        #endregion
    }
}
