using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Аналоговый вход с привязкой к модулям ввода-вывода </summary>
        public static readonly DeviceSubType AI = new(SubTypeIdentifier(DeviceType.AI) + 1, nameof(AI))
        {
            Parameters = new() 
            { 
                Parameter.P_C0, 
                Parameter.P_MIN_V, 
                Parameter.P_MAX_V 
            },
            Channels = new() 
            { 
                new IOChannel(ChannelType.AI, string.Empty) 
            },
            DeviceTags = new()
            {
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
            },
        };

        /// <summary> Виртуальный аналоговый вход (без привязки к модулям) </summary>
        public static readonly DeviceSubType AI_VIRT = new(SubTypeIdentifier(DeviceType.AI) + 2, nameof(AI_VIRT))
        {
            DeviceTags = new()
            {
                
            },
        };
    }


    public sealed class AI : Device
    {

        public AI(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {
            deviceDescription = subType.Description;
        }


    }
}
