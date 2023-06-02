using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PDSystem.Device;

namespace PDSystemTests.DeviceTests.DevicesTest
{
    public class AITest : DeviceTest<AI>
    {
        [ExcludeFromCodeCoverage]
        public override AI Creator(DeviceSubType subType)
            => new AI(subType, DeviceInfo.ParseCAD("+OBJ1-AI1") ?? new());


        [ExcludeFromCodeCoverage]
        [TestCaseSource(nameof(Create_checkChannelsCount_Cases))]
        public override void Create_CheckChannelsCount(DeviceSubType subType, Dictionary<ChannelType, int> expectedChannels)
            => base.Create_CheckChannelsCount(subType, expectedChannels);
        private static readonly object[] Create_checkChannelsCount_Cases = new object[]
        {
            new object[]
            {
                DeviceSubType.AI, new Dictionary<ChannelType, int>
                {
                    { ChannelType.AI, 1 },
                }
            },
            new object[] { DeviceSubType.AI_VIRT, new Dictionary<ChannelType, int>() }
        };

        [ExcludeFromCodeCoverage]
        [TestCaseSource(nameof(Create_CheckSubType_Cases))]
        public override void Create_CheckSubType(DeviceSubType subType)
            => base.Create_CheckSubType(subType);
        private static readonly object[] Create_CheckSubType_Cases = new object[]
        {
            DeviceSubType.AI,
            DeviceSubType.AI_VIRT,
        };
    }
}
