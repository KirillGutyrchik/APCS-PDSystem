using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PDSystem.Device;
using PDSystem.Ext;


namespace PDSystemTests.Ext
{
    public class EnumerationTest
    {
        /// <summary>
        /// Проверка получения типа по неверному ID
        /// </summary>
        [Test]
        public void FromID_WrongID()
        {
            Assert.Throws<InvalidOperationException>(() => EnumTest.FromID(-10));
        }

        /// <summary>
        /// Проверка получения типа по неверному названию
        /// </summary>
        [Test]
        public void FromName_WrongName()
        {
            Assert.Throws<InvalidOperationException>(() => EnumTest.FromName("WRONG_TYPE"));
        }

        /// <summary>
        /// Проверка получения (HashCode = ID.HashCode)
        /// </summary>
        [Test]
        public void GetHashCode_CheckHash()
        {
            int id = 2;
            EnumTest dt = EnumTest.FromID(id);

            Assert.That(dt.GetHashCode(), Is.EqualTo(id.GetHashCode()));
        }

        /// <summary>
        /// Проверка сравнения подтипов
        /// </summary>
        [Test]
        public void CompareTo_Test()
        {
            EnumTest ONE = EnumTest.ONE;
            EnumTest TWO = EnumTest.TWO;
            EnumTest THREE = EnumTest.THREE;

            Assert.Multiple(() =>
            {
                Assert.That(ONE.CompareTo(TWO), Is.EqualTo(-1));
                Assert.That(TWO.CompareTo(ONE), Is.EqualTo(1));
                Assert.That(ONE.CompareTo(THREE), Is.EqualTo(-1));
                Assert.That(THREE.CompareTo(ONE), Is.EqualTo(1));
            });
        }

        /// <summary>
        /// Проверка получения элемента по номеру
        /// </summary>
        /// <param name="id">Номер элемента</param>
        /// <param name="expectedType">Ожидаемый элемент</param>
        [TestCaseSource(nameof(FromID_SubType_Cases))]
        public void FromID_SubType(int id, EnumTest expectedType)
        {
            EnumTest dt = EnumTest.FromID(id);

            Assert.That(dt, Is.EqualTo(expectedType));
        }

        private static readonly object[] FromID_SubType_Cases =
        {
            new object[] { 1, EnumTest.ONE },
            new object[] { 2, EnumTest.TWO },
            new object[] { 3, EnumTest.THREE },
        };


        /// <summary>
        /// Проверка получения элемента по названию
        /// </summary>
        /// <param name="typeName">Название элемента</param>
        /// <param name="expectedType">Ожидаемый элемент</param>
        [TestCaseSource(nameof(FromName_CheckType_Cases))]
        public void FromName_CheckType(string typeName, EnumTest expectedType)
        {
            EnumTest dst = EnumTest.FromName(typeName);

            Assert.That(dst, Is.EqualTo(expectedType));
        }

        private static readonly object[] FromName_CheckType_Cases =
        {
            new object[] { "ONE", EnumTest.ONE },
            new object[] { "TWO", EnumTest.TWO },
            new object[] { "THREE", EnumTest.THREE },
        };
    }

    /// <summary>
    /// Тестовый класс перечисления
    /// </summary>
    public record EnumTest : Enumeration<EnumTest>
    {
        public static readonly EnumTest ONE = new(1, nameof(ONE));
        public static readonly EnumTest TWO = new(2, nameof(TWO));
        public static readonly EnumTest THREE = new(3, nameof(THREE));

        public EnumTest(int id, string name) : base(id, name)
        {
        }
    }
}
