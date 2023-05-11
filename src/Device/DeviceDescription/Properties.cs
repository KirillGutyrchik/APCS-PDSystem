using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    /// <summary>
    /// Свойство устройства.
    /// </summary>
    public record class Property
    {
        /// <summary>
        /// Пустое свойство
        /// </summary>
        public static readonly Property NONE = new Property(nameof(NONE));

        /// <summary>
        /// Связанные моторы.
        /// </summary>
        public static readonly Property MT = new(nameof(MT), "Связанные моторы");

        /// <summary>
        /// Датчик давления.
        /// </summary>
        public static readonly Property PT = new(nameof(PT), "Датчик давления");

        /// <summary>
        /// Входное значение (обычно для ПИД-а).
        /// </summary>
        public static readonly Property IN_VALUE = new(nameof(IN_VALUE), "Входное значение");

        /// <summary>
        /// Выходное значение (обычно для ПИД-а).
        /// </summary>
        public static readonly Property OUT_VALUE = new(nameof(OUT_VALUE), "Выходное значение");

        /// <summary>
        /// IP-адрес устройства.
        /// </summary>
        public static readonly Property IP = new(nameof(IP), "IP-адрес");

        /// <summary>
        /// Последовательность сигналов.
        /// </summary>
        public static readonly Property SIGNALS_SEQUENCE = new(nameof(SIGNALS_SEQUENCE), "Последовательность сигналов");

        /// <summary>
        /// Название свойства
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Описание свойства
        /// </summary>
        public string Description => description;   


        private Property(string name, string description = "") 
        { 
            this.name = name;
            this.description = description;
        }

        private string name;
        private string description;
    }

    public class DeviceProperties
    {
        public DeviceProperties CloneTemplate() => new DeviceProperties(ToList());

        public DeviceProperties()
        {

        }

        /// <summary>
        /// val = get[key] - получить значение свойства, если он существует.
        /// set[key] = val - установить значение свойства, если он сущуствует.
        /// </summary>
        /// <param name="parameter">Свойство</param>
        /// <exception cref="ArgumentException">Свойство не найдено</exception>
        public object? this[Property property]
        {
            get
            {
                try
                {
                    return properties[property];
                }
                catch (Exception)
                {
                    throw new ArgumentException($"\"{property.Name}\" - свойство не найдено");
                }
            }
            set
            {
                if (properties.ContainsKey(property))
                {
                    properties[property] = value;
                    OnPropertyChanged?.Invoke();
                }
                else
                {
                    throw new ArgumentException($"\"{property.Name}\" - свойство не найдено");
                }
            }
        }

        /// <summary>
        /// Получить список параметров
        /// </summary>
        public List<Property> ToList()
        {
            return properties.Select(property => property.Key).ToList();
        }

        /// <summary>
        /// Конструктор для инициализации свойств из списка свойств
        /// </summary>
        /// <param name="parametersList">Список свойств</param>
        public DeviceProperties(List<Property> parametersList)
        {
            properties = parametersList.ToDictionary<Property, Property, object?>(prop => prop, prop => null);
        }

        public bool Empty => properties.Any() is false;

        public delegate void PropertyChanged();
        public event PropertyChanged? OnPropertyChanged = null;

        private Dictionary<Property, object?> properties = new();
    }
}
