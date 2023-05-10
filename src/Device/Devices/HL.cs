namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Лампа </summary>
        public static readonly DeviceSubType HL = new(SubTypeIdentifier(DeviceType.HL) + 1, nameof(HL))
        {
            Channels =
            { 
                DO = { string.Empty } 
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };

        /// <summary> Виртуальная лампа (без привязки к модулям) </summary>
        public static readonly DeviceSubType HL_VIRT = new(SubTypeIdentifier(DeviceType.HL) + 2, nameof(HL_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class HL : Device
    {
        public HL(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {

        }
    }
}
