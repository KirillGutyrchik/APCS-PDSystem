namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Датчик давления </summary>
        public static readonly DeviceSubType PT = new(SubTypeIdentifier(DeviceType.PT) + 1, nameof(PT))
        {
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_MIN_V,
                Parameter.P_MAX_V,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
                { Tag.P_CZ, 1 },
            },
        };

        /// <summary> IO-Link датчик давления </summary>
        public static readonly DeviceSubType PT_IOLINK = new(SubTypeIdentifier(DeviceType.PT) + 2, nameof(PT_IOLINK))
        {
            Parameters =
            {
                Parameter.P_ERR,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
                { Parameter.P_ERR, 1 },
            },
            //Is IO-Link
        };

        /// <summary> Виртуальный датчик давления (без привязки к модулям) </summary>
        public static readonly DeviceSubType PT_VIRT = new(SubTypeIdentifier(DeviceType.PT) + 3, nameof(PT_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
            },
        };
    }

    public class PT : Device
    {
        public PT(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
