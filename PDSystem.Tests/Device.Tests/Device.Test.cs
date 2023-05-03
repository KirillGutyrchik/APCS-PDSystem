using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PDSystem.Device;

namespace PDSystemTests.DeviceTests
{
    public class DeviceTest
    {
        [TestCaseSource(nameof(CompareTo_Cases))]
        public void CompareTo_(Device dev1, Device dev2, int expected)
        {
            Assert.That(dev1.CompareTo(dev2), Is.EqualTo(expected));
        }

        private static readonly object[] CompareTo_Cases = new object[]
        {
            // equals
            new object[]
            {
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE2"
                }),
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE2"
                }),
                0
            },
            // deviceNumber
            new object[]
            {
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE2"
                }),
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE3"
                }),
                -1
            },
            // objectNumber
            new object[]
            {
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A2NONE2"
                }),
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE2"
                }),
                1
            },
            // objectName
            new object[]
            {
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "A1NONE2"
                }),
                new NONE(DeviceSubType.NONE, new DeviceInfo()
                {
                    ParseName = "B1NONE2"
                }),
                -1
            },
        };
    }


    /// <summary>
    /// Устройство для тестирования
    /// </summary>
    public class NONE : Device
    {
        public NONE(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {

        }
    }

}
