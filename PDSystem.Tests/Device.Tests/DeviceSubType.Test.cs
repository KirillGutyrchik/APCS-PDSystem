using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PDSystem.Device;
using PDSystem.Ext;

namespace PDSystemTests.DeviceTests
{
    public class DeviceSubTypeTest
    {
        /// <summary>
        /// Проверка получения подтипа из типа и номера подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="id">Номер подтипа</param>
        /// <param name="expectedSubType">Ожидаемый подтип</param>
        [TestCaseSource(nameof(FromTypeAndID_CheckSubType_Cases))]
        public void FromTypeAndID_CheckSubType(DeviceType type, int id, DeviceSubType expectedSubType)
        {
            DeviceSubType dst = DeviceSubType.FromTypeAndID(type, id);

            Assert.That(dst, Is.EqualTo(expectedSubType));
        }

        private static readonly object[] FromTypeAndID_CheckSubType_Cases =
        {
            new object[] { DeviceType.V, 10, DeviceSubType.V_AS_DO1_DI2 },
            new object[] { DeviceType.AI, 1, DeviceSubType.AI },
            new object[] { DeviceType.AI, 2, DeviceSubType.AI_VIRT },
            new object[] { DeviceType.AI, 3, DeviceSubType.NONE },
        };

        /// <summary>
        /// Проверка получения подтипа из типа и названия
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="subTypeName">Название подтипа</param>
        /// <param name="expectedSubType">Ожидаемый подтип</param>
        [TestCaseSource(nameof(FromTypeAndName_CheckSubType_Cases))]
        public void FromTypeAndName_CheckSubType(DeviceType type, string subTypeName, DeviceSubType expectedSubType)
        {
            DeviceSubType dst = DeviceSubType.FromTypeAndName(type, subTypeName);

            Assert.That(dst, Is.EqualTo(expectedSubType));
        }

        private static readonly object[] FromTypeAndName_CheckSubType_Cases =
        {
            new object[] { DeviceType.V, "V_AS_DO1_DI2", DeviceSubType.V_AS_DO1_DI2 },
            new object[] { DeviceType.AI, "AI", DeviceSubType.AI },
            new object[] { DeviceType.AI, "", DeviceSubType.AI },
            new object?[] { DeviceType.AI, null, DeviceSubType.AI },
            new object[] { DeviceType.AI, "AI_VIRT", DeviceSubType.AI_VIRT },
            new object[] { DeviceType.AI, "WRON_ST_NAME", DeviceSubType.NONE },
        };


        /// <summary>
        /// Проверка получения номера подтипа
        /// </summary>
        /// <param name="dst">Подтип устройства</param>
        /// <param name="id">Номер подтипа</param>
        [TestCaseSource(nameof(GetID_Test_Cases))]
        public void GetID_Test(DeviceSubType dst, int id)
        {
            Assert.That(dst.Id, Is.EqualTo(id));
        }

        private static readonly object[] GetID_Test_Cases =
        {
            new object[] { DeviceSubType.AI, 1 },
            new object[] { DeviceSubType.AI_VIRT, 2 },
            new object[] { DeviceSubType.NONE, 0 },
        };
    }
}
