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
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE2") ?? new()),
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE2") ?? new()),
                0
            },
            // deviceNumber
            new object[]
            {
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE2") ?? new()),
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE3") ?? new()),
                -1
            },
            // objectNumber
            new object[]
            {
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A2-NONE2") ?? new()),
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE2") ?? new()),
                1
            },
            // objectName
            new object[]
            {
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+A1-NONE2") ?? new()),
                new NONE(DeviceSubType.NONE, DeviceInfo.ParseCAD("+B1-NONE2") ?? new()),
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
