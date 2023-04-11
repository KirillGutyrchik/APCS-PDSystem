using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    /// <summary>
    /// Свойство устройства.
    /// </summary>
    public record Property : DeviceOption<Property>
    {
        /// <summary> Пустое свойство </summary>
        public static readonly Property NONE = new("NONE", string.Empty);

        /// <summary> Связанные моторы. </summary>
        public static readonly Property MT = new("MT", "Связанные моторы");

        /// <summary> Датчик давления. </summary>
        public static readonly Property PT = new("PT", "Датчик давления");

        /// <summary> Входное значение (обычно для ПИД-а). </summary>
        public static readonly Property IN_VALUE = new("IN_VALUE", "Входное значение");

        /// <summary> Выходное значение (обычно для ПИД-а). </summary>
        public static readonly Property OUT_VALUE = new("OUT_VALUE", "Выходное значение");

        /// <summary> IP-адрес устройства. </summary>
        public static readonly Property IP = new("IP", "ip-адрес");

        /// <summary> Последовательность сигналов. </summary>
        public static readonly Property SIGNALS_SEQUENCE = new("SIGNALS_SEQUENCE", "Последовательность сигналов");

        /// <summary>
        /// Конструктор свойства
        /// </summary>
        /// <param name="name">Название свойства (Lua)</param>
        /// <param name="description">Описание свойства</param>
        private Property(string name, string description)
            : base(name)
        {
            this.description = description;
        }

        /// <summary>
        /// Неявное преобразование названия в свойство.
        /// Если свойство не найдено, возвращается свойство NONE
        /// </summary>
        /// <param name="propertyName"> Название свойства </param>
        public static implicit operator Property(string propertyName)
            => AllOptions.Value.GetValueOrDefault(propertyName, NONE);

        /// <summary>
        /// Неявное преобразования параметра в строку
        /// </summary>
        /// <param name="property"> Свойство </param>
        public static implicit operator string(Property property)
            => property.Name;

        /// <summary>
        /// Описание свойства
        /// </summary>
        public string Description { get => description; }

        private string description;
    }

    /// <summary>
    /// Словарь свойств
    /// </summary>
    public class DeviceProperties
    {

        /// <summary>
        /// val = get[key] - получить значение свойства, если оно существует.
        /// set[key] = val - установить значение свойства, если оно сущуствует.
        /// </summary>
        /// <param name="property">Свойство</param>
        /// <exception cref="ArgumentException">свойство не найдено</exception>
        public object? this[Property property]
        {
            get
            {
                try
                {
                    return properties?[property];
                }
                catch (Exception)
                {
                    throw new ArgumentException($"\"{property.Name}\" - параметр не найден");
                }
            }
            set
            {
                if (properties.ContainsKey(property))
                {
                    properties[property] = value;
                }
                else
                {
                    throw new ArgumentException($"\"{property.Name}\" - параметр не найден");
                }
            }
        }

        public object Clone()
        {
            return new DeviceProperties(this.properties);
        }

        /// <summary>
        /// Конструктор для клонирования параметров
        /// </summary>
        /// <param name="parameters">Словарь параметров для копирования</param>
        private DeviceProperties(Dictionary<Property, object?> parameters)
        {
            this.properties = new(parameters);
        }

        /// <summary>
        /// Конструктор для инициализации параметров устройства из списка параметров
        /// </summary>
        /// <param name="propertyList"></param>
        private DeviceProperties(List<Property> propertyList)
        {
            this.properties = propertyList.ToDictionary<Property, Property, object?>(par => par, par => null);
        }

        /// <summary>
        /// Инициализация параметров устройства из списка параметров.
        /// </summary>
        /// <param name="propertyList"></param>
        public static implicit operator DeviceProperties(List<Property> propertyList)
        {
            return new DeviceProperties(propertyList);
        }


        private Dictionary<Property, object?> properties;
    }
}
