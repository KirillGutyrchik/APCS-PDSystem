namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Текущая температура </summary>
        public static readonly DeviceSubType TE = new(SubTypeIdentifier(DeviceType.TE) + 1, nameof(TE))
        {
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
            },
        };

        /// <summary> IO-Link текущая температура </summary>
        public static readonly DeviceSubType TE_IOLINK = new(SubTypeIdentifier(DeviceType.TE) + 2, nameof(TE_IOLINK))
        {
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
            },
            // Is IO-Link
        };

        /// <summary> Виртуальный датчик температуры (без привязки к модулям) </summary>
        public static readonly DeviceSubType TE_VIRT = new(SubTypeIdentifier(DeviceType.TE) + 3, nameof(TE_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
            },
        };

        /// <summary> Аналоговый датчик температуры 4-20 мА </summary>
        public static readonly DeviceSubType TE_ANALOG = new(SubTypeIdentifier(DeviceType.TE) + 4, nameof(TE_ANALOG))
        {
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
                Parameter.P_MIN_V,
                Parameter.P_MAX_V,
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
                { Tag.P_CZ, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
                { Parameter.P_ERR, 1 },
            },
        };
    }

    public class TE : Device
    {
        public TE(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
