using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PDSystem.Device;

namespace PDSystemTests.DeviceTests.DevicesTest
{
    /// <summary>
    /// Абстрактный класс для тестирования устройств:
    /// [test source] override Test(data) => base(data);
    /// </summary>
    /// <typeparam name="T">Тип устройства</typeparam>
    public abstract class DeviceTest<T> where T : Device
    {

        /// <summary>
        /// Метод для создания устройтсва T-типа 
        /// </summary>
        /// <param name="subType">Подтип устройсва</param>
        /// <returns>Устройство T-типа</returns>
        public abstract T Creator(DeviceSubType subType);

        /// <summary>
        /// Тест для проверки установленых каналов при создании устройства
        /// </summary>
        /// <param name="subType">Подтип устройства</param>
        /// <param name="expectedChannels">Ожидаемые каналы</param>
        public virtual void Create_CheckChannelsCount(DeviceSubType subType, Dictionary<ChannelType, int> expectedChannels)
        {
            Device device = Creator(subType);
            Assert.Multiple(() =>
            {
                Assert.That(device.DI, Has.Count.EqualTo(expectedChannels.GetValueOrDefault(ChannelType.DI, 0)));
                Assert.That(device.DO, Has.Count.EqualTo(expectedChannels.GetValueOrDefault(ChannelType.DO, 0)));
                Assert.That(device.AI, Has.Count.EqualTo(expectedChannels.GetValueOrDefault(ChannelType.AI, 0)));
                Assert.That(device.AO, Has.Count.EqualTo(expectedChannels.GetValueOrDefault(ChannelType.AO, 0)));
            });
        }

        /// <summary>
        /// Тест для проверки установленного подтипа при создании устройства
        /// </summary>
        /// <param name="subType">Подтип устройства</param>
        public virtual void Create_CheckSubType(DeviceSubType subType)
        {
            Device device = Creator(subType);
            Assert.That(subType, Is.EqualTo(device.DeviceSubType));
        }

        /// <summary>
        /// Тест для проверки установленых параметров в инициализированном устройстве
        /// </summary>
        /// <param name="subType">Подтип устройства</param>
        /// <param name="expectedParameters">Список ожидаемых пареметров</param>
        public virtual void Create_CheckParameters(DeviceSubType subType, List<Parameter> expectedParameters)
        {
            Device device = Creator(subType);
            var actualParametersList = device.Parameters.ToList();
            Assert.That(actualParametersList, Is.EqualTo(expectedParameters));
        }

        /// <summary>
        /// Тест для проверки установленных рабочих параметров в инициализированном устройстве
        /// </summary>
        /// <param name="subType">Подтип устройства</param>
        /// <param name="expectedRuntimeParameters">Список ожидаемых рабочих параметров</param>
        //public virtual void Create_CheckRuntimeParameters(DeviceSubType subType, List<string> expectedRuntimeParameters)
        //{
        //    Device device = Creator(subType);
        //    List<string> actualRuntimeParametersList = device.RuntimeParameters.Select(parameter => parameter.Key).ToList();
        //    Assert.That(actualRuntimeParametersList, Is.EqualTo(expectedRuntimeParameters));
        //}

        /// <summary>
        /// Тест для проверки установленных свойсв в инициализированном устройстве
        /// </summary>
        /// <param name="subType">Подтип устройства</param>
        /// <param name="expectedProperties">Список ожидаемых свойств</param>
        public virtual void Create_CheckProperties(DeviceSubType subType, List<Property> expectedProperties)
        {
            Device device = Creator(subType);
            List<Property> actualPropertiesList = device.Properties.ToList();
            Assert.That(actualPropertiesList, Is.EqualTo(expectedProperties));
        }
    }
}
