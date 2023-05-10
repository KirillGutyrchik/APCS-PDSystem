namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Кнопка </summary>
        public static readonly DeviceSubType SB = new(SubTypeIdentifier(DeviceType.SB) + 1, nameof(SB))
        {
            Channels =
            {
                DI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_DT, 1} 
            },
        };

        /// <summary> Виртуальная кнопка (без привязки к модулям) </summary>
        public static readonly DeviceSubType SB_VIRT = new(SubTypeIdentifier(DeviceType.SB) + 2, nameof(SB_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class SB : Device
    {
        public SB(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
