using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Ext
{
    /// <summary>
    /// Класс перечисления
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    public record Enumeration<T> : IComparable<T> where T : Enumeration<T>
    {
        protected static readonly Lazy<Dictionary<int, T>> AllItems;
        protected static readonly Lazy<Dictionary<string, T>> AllItemsByName;

        /// <summary>
        /// Название элемента
        /// </summary>
        public virtual string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Id элемента
        /// </summary>
        public virtual int ID
        {
            get
            {
                return id;
            }
        }

        protected Enumeration(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Инициализация всех элементов перечисления в словари по номеру и названию
        /// </summary>
        /// <exception cref="Exception">Добавление повторного ключа в словаарь</exception>
        static Enumeration()
        {
            AllItems = new Lazy<Dictionary<int, T>>(() =>
            {
                var list = typeof(T)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(x => x.FieldType == typeof(T))
                    .Select(x => x.GetValue(null))
                    .Cast<T>()
                    .ToDictionary(x => x.id, x => x);

                return list;
            });
            AllItemsByName = new Lazy<Dictionary<string, T>>(() =>
            {
                var items = new Dictionary<string, T>(AllItems.Value.Count);
                foreach (var item in AllItems.Value)
                {                  
                    TryAddItem(items, item);
                }
                return items;
            });
        }

        /// <summary>
        /// Оболочка для добавления элементов в список по имени.
        /// </summary>
        /// <remarks>
        /// метод исключен из покрытия тестами, так как исключение
        /// срабатывает только при инициализации перечисления.
        /// </remarks>
        /// <param name="items">Словарь элементов</param>
        /// <param name="item">Элемент</param>
        /// <exception cref="Exception"> Элемент уже доавлен </exception>
        [ExcludeFromCodeCoverage]
        private static void TryAddItem(Dictionary<string, T> items, KeyValuePair<int, T> item)
        {
            if (!items.TryAdd(item.Value.name, item.Value))
            {
                throw new Exception($"DisplayName needs to be unique. '{item.Value.name}' already exists");
            }
        }



        /// <summary>
        /// Получить элемент перечисления по номеру
        /// </summary>
        /// <param name="id">Номер элемента</param>
        /// <returns>Элемент перечисления</returns>
        /// <exception cref="InvalidOperationException">Неверный номер элемента</exception>
        public static T FromID(int id)
        {
            if (AllItems.Value.TryGetValue(id, out var matchingItem))
            {
                return matchingItem;
            }
            throw new InvalidOperationException($"'{id}' is not a valid value in {typeof(T)}");
        }

        /// <summary>
        /// Получить элемент перечисления по названию
        /// </summary>
        /// <param name="name">Название элемента</param>
        /// <returns>Элемент перечисления</returns>
        /// <exception cref="InvalidOperationException">Неверное название элемента</exception>
        public static T FromName(string name)
        {
            if (AllItemsByName.Value.TryGetValue(name, out var matchingItem))
            {
                return matchingItem;
            }
            throw new InvalidOperationException($"'{name}' is not a valid display name in {typeof(T)}");
        }

        public override int GetHashCode() => ID.GetHashCode();

        public int CompareTo(T? other) => ID.CompareTo(other!.ID);

        protected int id;
        protected string name;
    }
}