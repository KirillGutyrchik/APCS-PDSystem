using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PDSystem.Ext;

namespace PDSystem.Device
{
    /// <summary>
    /// Подтип устройства
    /// </summary>
    public partial record class DeviceSubType : Enumeration<DeviceSubType>
    {
        /// <summary> Неопределенный подтип. </summary>
        public static readonly DeviceSubType NONE = new(0, nameof(NONE));

       
        /// <summary>
        /// Индентификатор подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <returns>Номер типа умноженный на коэффициент</returns>
        private static int SubTypeIdentifier(DeviceType type)
        {
            return typeWeight * type.Id;
        }

        /// <summary>
        /// Номер подтипа.
        /// </summary>
        /// <remarks>
        /// Этот номер не зависит от типа устройства.
        /// </remarks>
        public override int Id
        {
            get
            {
                return id % typeWeight;
            }
        }

        /// <summary>
        /// Получить экземпляр подтипа по типу и номеру подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="id">Номер подтипа</param>
        /// <returns>Подтип устройства (NONE если подтип не найден)</returns>
        public static DeviceSubType FromTypeAndID(DeviceType type, int id)
        {
            if (AllItems.Value.TryGetValue(id + SubTypeIdentifier(type), out var matchingItem))
            {
                return matchingItem;
            }
            return NONE;
        }

        /// <summary>
        /// Получить экземпляр подтипа по типу и названию подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="subtype">Название подтипа</param>
        /// <returns>Подтип устройства (NONE если подтип не найден)</returns>
        public static DeviceSubType FromTypeAndName(DeviceType type, string subtype)
        {
            if (string.IsNullOrEmpty(subtype))
            {
                return FromTypeAndID(type, defaultID);
            }

            if (AllItemsByName.Value.TryGetValue(subtype, out var matchingItem) 
                && CheckSubType(type, matchingItem) == true)
            {
                    return matchingItem;
            }

            return NONE;
        }

        /// <summary>
        /// Проверка принадлежности подтипа к типу
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="subType">Подтип устройства</param>
        /// <returns>true when subtype in type</returns>
        private static bool CheckSubType(DeviceType type, DeviceSubType subType)
        {
            return subType.Id == subType.id - SubTypeIdentifier(type);
        }


        #region Device Description
        /// <summary>
        /// Получить пустое описание устройства
        /// </summary>
        public DeviceDescription GetDescription() => new DeviceDescription()
        {
            Parameters = new DeviceParameters(this.Parameters),
            RuntimeParameters = new DeviceRuntimeParameters(this.RuntimeParameters),
            Properties = new DeviceProperties(this.Properties),
            Channels = new DeviceChannels(Channels.DO, Channels.DI, Channels.AO, Channels.AI),
            
            DeviceTags = this.DeviceTags.ToImmutableDictionary(),
        };

        /// <summary>
        /// Инициализация параметров
        /// </summary>
        private List<Parameter> Parameters = new();

        /// <summary>
        /// Инициализация runtime-параметров
        /// </summary>
        private List<RuntimeParameter> RuntimeParameters = new();

        /// <summary>
        /// Инициализация свойств
        /// </summary>
        private List<Property> Properties = new();

        /// <summary>
        /// Инициализация каналов ввода-вывода
        /// </summary>
        private (List<string> DO, List<string> DI, List<string> AO, List<string> AI) Channels = new(new(), new(), new(), new());


        /// <summary>
        /// Инициализация тегов
        /// </summary>
        private Dictionary<string, int> DeviceTags = new();
        #endregion

        /// <summary>
        /// Конструктор подтипа
        /// </summary>
        /// <param name="id">Номер подтипа</param>
        /// <param name="name">Название подтипа</param>
        /// <param name="description">Конструктор для создания описания устройства</param>
        protected DeviceSubType(int id, string name)
           : base(id, name)
        {
            
        }

        /// <summary>
        /// Коэффициент типа ( IDподтипа = №подтипа + IDтипа * коефициент типа )
        /// </summary>
        private const int typeWeight = 1000;

        /// <summary>
        /// Стандартный номер подтипа (если строка подтипа не заполнена)
        /// </summary>
        private const int defaultID = 1;
    }
}