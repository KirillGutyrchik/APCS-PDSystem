using LuaInterface;
using PDSystem.Ext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PDSystem.Device
{
    public interface IDevice
    {
        /// <summary> Имя устройства (например - А1V12). </summary>
        string Name { get; }

        /// <summary> Имя устройства в CAD(например "+А1-V12"). </summary>
        string CADName { get; }

        /// <summary> Описание устройства. </summary>
        string Description { get; }

        /// <summary> Номер объекта устройства. </summary>
        int ObjectNumber { get; }

        /// <summary> Объект устройства. </summary>
        string ObjectName { get; }

        /// <summary> Номер устройства. </summary>
        int DeviceNumber { get; }

        /// <summary> Тип устройства. </summary>
        DeviceType DeviceType { get; }

        /// <summary> Подтип устройства. </summary>
        DeviceSubType DeviceSubType { get; init; }

        /// <summary> Получение типа подключения для устройства </summary>
        string GetConnectionType();

        /// <summary> Получение диапазона настройки </summary>
        string GetRange();

        /// <summary>
        /// IOL-Conf свойства в устройстве.
        /// </summary>
        Dictionary<string, double> IolConfProperties { get; }

        /// <summary>
        /// Свойство содержащее изделие, которое используется для устройства
        /// </summary>
        string ArticleName { get; set; }

        /// <summary>
        /// IO-Link свойства устройства
        /// </summary>
        //IODevice.IOLinkSize IOLinkProperties { get; }

        /// <summary>
        /// Установить свойство IOL-Conf в устройстве (переопределить в шаблоне)
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="value">Устанавливаемое значение</param>
        void SetIolConfProperty(string propertyName, double value);
    }

    public abstract class Device : IComparable<Device>, IEquatable<Device>, IDevice, ISaveAsLuaTable
    {
        /// <param name="subType"> Подтип устройства</param>
        /// <param name="cadName"> САПр имя устройства (+OBJ1-DEV2) </param>
        public Device(DeviceSubType subType, DeviceInfo deviceInfo)
        {
            this.deviceSubType = subType ?? DeviceSubType.NONE;
            this.deviceInfo = deviceInfo;
            this.deviceDescription = subType?.GetDescription() ?? new();
        }

        #region DevcieInfo Getters
        public string Name => deviceInfo.Name;

        public string CADName => deviceInfo.CADName;

        public string Description 
        { 
            get => deviceInfo.Description; 
            set => deviceInfo.Description = value; 
        }

        public int ObjectNumber => deviceInfo.ObjectNumber;

        public string ObjectName => deviceInfo.ObjectName;

        public int DeviceNumber => deviceInfo.DeviceNumber;

        public string ArticleName 
        { 
            get => deviceInfo.ArticleName;
            set => deviceInfo.ArticleName = value; 
        }
        #endregion

        public DeviceType DeviceType => deviceType ??= DeviceType.FromName(GetType().Name);

        public DeviceSubType DeviceSubType 
        { 
            get => deviceSubType;
            init => deviceSubType = value; 
        }

        public Dictionary<string, double> IolConfProperties => throw new NotImplementedException();

        #region Device Description getters
        /// <summary> Параметры </summary>
        public DeviceParameters Parameters => deviceDescription.Parameters;

        /// <summary> Свойства </summary>
        public DeviceProperties Properties => deviceDescription.Properties;

        /// <summary> Каналы </summary>
        public DeviceChannels Channels => deviceDescription.Channels;

        public virtual ImmutableDictionary<string, int> DeviceTags => deviceDescription.DeviceTags;
        #endregion


        /// <summary>
        /// Сравнение объектов для сортировки.
        /// </summary>
        /// <remarks> Сортировка по типу и названию</remarks>
        /// <param name="otherDevice">Устройство для сравнения</param>
        /// <returns>
        /// меньше 0 - this меньше other
        ///        0 - this равно  other
        /// больше 0 - this больше other
        /// </returns>
        public int CompareTo(Device? otherDevice)
        {
            if (otherDevice == null)
                return 1;

            if (DeviceType != otherDevice.DeviceType)
            {
                return DeviceType.CompareTo(otherDevice.DeviceType);
            }
            
            if (ObjectName != otherDevice.ObjectName)
            {
                return ObjectName.CompareTo(otherDevice.ObjectName);
            }

            if (ObjectNumber != otherDevice.ObjectNumber) 
            { 
                return ObjectNumber.CompareTo(otherDevice.ObjectNumber);
            }

            if (DeviceNumber != otherDevice.DeviceNumber)
            {
                return DeviceNumber.CompareTo(otherDevice.DeviceNumber);
            }

            return 0;
        }

        public bool Equals(Device? otherDevice)
        {
            if (otherDevice == null)
            {
                return false;
            }

            return Name.Equals(otherDevice.Name);
        }

        public string GetConnectionType()
        {
            throw new NotImplementedException();
        }

        
        public virtual string GetRange()
        {
            return string.Empty;
        }

        public void SetIolConfProperty(string propertyName, double value)
        {
            throw new NotImplementedException();
        }

        public virtual StringBuilder SaveAsLuaTable(string prefix = "")
        {
            var result = new StringBuilder();

            result
                .Append($"{prefix}{{\n")
                .Append($"{prefix}name    = '{Name}',\n")
                .Append($"{prefix}descr   = '{Description}',\n")
                .Append($"{prefix}dtype   = '{DeviceType.Id}',\n")
                .Append($"{prefix}subtype = '{DeviceSubType.Id}', -- {DeviceSubType.Name}\n")
                .Append($"{prefix}article = '{ArticleName}',\n")
                .Append(deviceDescription.SaveAsLuaTable(prefix))
                .Append($"{prefix}}},\n\n");

            return result;
        }

        protected DeviceType? deviceType = null;
        protected DeviceSubType deviceSubType;
        protected DeviceDescription deviceDescription;
        protected DeviceInfo deviceInfo;
    }
}
