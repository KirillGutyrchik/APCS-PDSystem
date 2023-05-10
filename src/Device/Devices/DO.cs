namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        private static Dictionary<string, int> DO_Tags = new() 
        {
            {Tag.ST, 1},
            {Tag.M, 1},
        };

        /// <summary> Дискретный выход с привязкой к модулям </summary>
        public static readonly DeviceSubType DO = new(SubTypeIdentifier(DeviceType.DO) + 1, nameof(DO))
        {
            Channels =
            {
                DO = { string.Empty },
            },
            DeviceTags = DO_Tags,
        };

        /// <summary> Виртуальный дискретный выход(без привязки к модулям) </summary>
        public static readonly DeviceSubType DO_VIRT = new(SubTypeIdentifier(DeviceType.DO) + 2, nameof(DO_VIRT))
        {
            DeviceTags = DO_Tags,
        };
    }
    public class DO : Device
    {
        public DO(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
