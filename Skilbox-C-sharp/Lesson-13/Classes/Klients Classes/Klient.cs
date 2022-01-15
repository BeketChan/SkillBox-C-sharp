using Lesson_13.Classes.Accaunt_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_13.Classes.Klients_Classes
{
    /// <summary>
    /// Клиент
    /// </summary>
    public abstract class Klient : IEquatable<Klient>, IComparable<Klient>
    {
        #region Поля

        /// <summary>
        /// Наименование клиента
        /// </summary>
        string? name;

        /// <summary>
        /// Список счетов клиента.
        /// </summary>
        List<Accaunt>? deposits;

        /// <summary>
        /// Тип клиента, для удобства
        /// </summary>
        string? type;

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
        public ObservableCollection<Accaunt>? Deposits
        {
            get
            {
                ObservableCollection<Accaunt> dep = new();
                if (deposits != null)
                    foreach (Accaunt d in deposits)
                        dep.Add(d);
                return dep;
            }
            set
            {
                if (value != null)
                {
                    deposits.Clear();
                    foreach (Accaunt E in value)
                        deposits.Add(E);
                }
            }
        }

        /// <summary>
        /// Получить тип клиента
        /// </summary>
        public string? Type
        {
            get => type;
        }

        /// <summary>
        /// Допустимые типу счетов
        /// </summary>
        public List<string>? AccType { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Пустой Конструктор
        /// </summary>
        public Klient() { }

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="name"></param>
        public Klient(string name, string type, List<string> AccType)
        {
            this.name = name;
            this.type = type;
            this.AccType = AccType;
            deposits = new List<Accaunt>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Реализация интерфейса сравнения.
        /// </summary>
        /// <param name="other">Сравниваемый клиент.</param>
        /// <returns></returns>
        public bool Equals(Klient? other)
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
        public int CompareTo(Klient? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Добавляем счёт клиенту.
        /// </summary>
        /// <param name="name">Имя счёта.</param>
        public void AddAcc(string name)
        {
            Accaunt acc = new(name);
            deposits.Add(acc);
        }

        #endregion
    }
}
