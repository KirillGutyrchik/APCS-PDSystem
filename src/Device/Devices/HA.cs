namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Сирена </summary>
        public static readonly DeviceSubType HA = new(SubTypeIdentifier(DeviceType.HA) + 1, nameof(HA))
        {
            Channels =
            {
                DO = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };

        /// <summary> Виртуальная сирена (без привязки к модулям) </summary>
        public static readonly DeviceSubType HA_VIRT = new(SubTypeIdentifier(DeviceType.HA) + 2, nameof(HA_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class HA : Device
    {
        public HA(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
