using NUnit.Framework;
using PDSystem.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PDSystemTests.DeviceTests
{
    public class DeviceTypeTest
    {
        /// <summary>
        /// Проверка получения типа по номеру
        /// </summary>
        /// <param name="id">Номер типа</param>
        /// <param name="expectedType">Ожидаемый тип</param>
        [TestCaseSource(nameof(FromID_SubType_Cases))]
        public void FromID_SubType(int id, DeviceType expectedType)
        {
            DeviceType dt = DeviceType.FromID(id);

            Assert.That(dt, Is.EqualTo(expectedType));
        }

        private static readonly object[] FromID_SubType_Cases =
        {
            new object[] { 0, DeviceType.V },
            new object[] { 1, DeviceType.VC },
            new object[] { 2, DeviceType.M },
            new object[] { 3, DeviceType.LS },
        };

        
        /// <summary>
        /// Проверка получения типо по названию
        /// </summary>
        /// <param name="typeName">Название типа</param>
        /// <param name="expectedType">Ожидаемый тип</param>
        [TestCaseSource(nameof(FromName_CheckType_Cases))]
        public void FromName_CheckType(string typeName, DeviceType expectedType)
        {
            DeviceType dst = DeviceType.FromName(typeName);

            Assert.That(dst, Is.EqualTo(expectedType));
        }

        private static readonly object[] FromName_CheckType_Cases =
        {
            new object[] { "AI", DeviceType.AI },
            new object[] { "AO", DeviceType.AO },
            new object[] { "V", DeviceType.V },
        };
    }
}
