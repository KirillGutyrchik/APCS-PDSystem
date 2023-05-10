namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        private static readonly Dictionary<string, int> LS_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Parameter.P_DT, 1 },
        };

        private static readonly Dictionary<string, int> LS_IOLINK_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Tag.V, 1 },
            { Parameter.P_DT, 1 },
            { Parameter.P_ERR, 1 },
        };

        /// <summary> Подключение по схеме минимум </summary>
        public static readonly DeviceSubType LS_MIN = new(SubTypeIdentifier(DeviceType.LS) + 1, nameof(LS_MIN))
        {
            Parameters =
            {
                Parameter.P_DT,
            },
            Channels =
            {
                DI = { string.Empty },
            },
            DeviceTags = LS_TAGS,
        };

        /// <summary> Подключение по схеме максимум </summary>
        public static readonly DeviceSubType LS_MAX = new(SubTypeIdentifier(DeviceType.LS) + 2, nameof(LS_MAX))
        {
            Parameters =
            {
                Parameter.P_DT,
            },
            Channels =
            {
                DI = { string.Empty },
            },
            DeviceTags = LS_TAGS,
        };

        /// <summary> IO-Link уровень. Подключение по схеме минимум </summary>
        public static readonly DeviceSubType LS_IOLINK_MIN = new(SubTypeIdentifier(DeviceType.LS) + 3, nameof(LS_IOLINK_MIN))
        {
            Parameters =
            {
                Parameter.P_DT,
                Parameter.P_ERR,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags = LS_IOLINK_TAGS,
            // Is IO-Link
        };

        /// <summary> IO-Link уровень. Подключение по схеме максимум </summary>
        public static readonly DeviceSubType LS_IOLINK_MAX = new(SubTypeIdentifier(DeviceType.LS) + 4, nameof(LS_IOLINK_MAX))
        {
            Parameters = 
            {
                Parameter.P_DT,
                Parameter.P_ERR,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags = LS_IOLINK_TAGS,
            // Is IO-Link
        };

        /// <summary> Виртуальный датчик уровня (без привязки к модулям) </summary>
        public static readonly DeviceSubType LS_VIRT = new(SubTypeIdentifier(DeviceType.LS) + 5, nameof(LS_VIRT))
        {
            DeviceTags = LS_TAGS,
        };
    }

    public class LS : Device
    {
        public LS(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }

        //get conection type _min _max
    }
}
