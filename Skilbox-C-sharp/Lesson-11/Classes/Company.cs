using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Newtonsoft.Json;

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
            {"Руководитель",15 },
            {"Работник",8 },
            {"Интерн",500 }
        };

        /// <summary>
        /// Коллекция подразделений организации.
        /// </summary>
        ObservableCollection<Department> departments;

        /// <summary>
        /// Путь к сохранению в JSON
        /// </summary>
        readonly string path = "MyCompany.json";

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
            set { if (value != null) departments = value; }
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

        #region Методы

        /// <summary>
        /// Проверка наличия руководителя у подразделения.
        /// </summary>
        /// <param name="department">Подразделение.</param>
        /// <returns></returns>
        public static bool CheckDirectorInDepartment(Department department)
        {
            if (department.Executors != null)
                foreach (Executor exe in department.Executors)
                    if (exe.Position == "Руководитель") return true;
            return false;
        }

        /// <summary>
        /// Добавить работника в подразделение.
        /// </summary>
        /// <param name="department">Подразделение.</param>
        /// <param name="executor">Работник.</param>
        public static void AddExecutor(Department department, Executor executor)
        {
            if ( !( executor.Position == "Руководитель" && CheckDirectorInDepartment(department) ) && department.Executors != null)
            {
                department.Executors.Add(executor);
            }
        }

        /// <summary>
        /// Подсчёт зарплаты руководителя подразделения, включая дочерние, но без учёта руководителей дочерних.
        /// </summary>
        /// <param name="department">Подраздаление.</param>
        /// <returns></returns>
        public double SalaryKalkulation(Department department)
        {
            double kalkulation = 0.00;

            if ( department.Executors != null)
            {
                foreach(Executor exe in department.Executors)
                {
                    if(exe.Position != "Руководитель")
                    {
                        switch (exe.Position)
                        {
                            case ("Интерн"): kalkulation += 500; break;
                            default: kalkulation += (8 * 160); break;
                        }
                    }
                }
            }

            if(department.Departments != null)
                foreach (Department dep in department.Departments) kalkulation += SalaryKalkulation(dep);

            return kalkulation;
        }

        /// <summary>
        /// Сбор всех дочерних подразделений в единый список, включая головное подразделение.
        /// </summary>
        /// <param name="dep">Головное подразделение.</param>
        /// <param name="list">Список.</param>
        /// <returns></returns>
        public ObservableCollection<Department> DepartmentsList(Department dep, ObservableCollection<Department> list)
        {
            list.Add(dep);
            if (dep.Departments != null)
                foreach (Department department in dep.Departments)
                    DepartmentsList(department, list);

            return list;
        }

        /// <summary>
        /// Сериализация.
        /// </summary>
        /// <param name="dep"></param>
        public void SerializeJson(ObservableCollection<Department> dep)
        {
            //JsonSerializerOptions options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //    WriteIndented = true,
            //};

            //string json = JsonSerializer.Serialize<object>(dep, options);
            //File.WriteAllText(path, json);

            var jset = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string save = JsonConvert.SerializeObject(dep, jset);
            File.WriteAllText(path, save);
        }

        /// <summary>
        /// Десериализация.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Department> DeserializeJson()
        {
            //string json = File.ReadAllText(path);

            //JsonSerializerOptions options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //    WriteIndented = true
            //};

            //return JsonSerializer.Deserialize<ObservableCollection<Department>>(json, options);

            
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            string load = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ObservableCollection<Department>>(load, jset);
        }

        #endregion
    }
}
