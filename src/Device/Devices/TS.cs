namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Сигнальный датчик температуры </summary>
        public static readonly DeviceSubType TS = new(SubTypeIdentifier(DeviceType.TS) + 1, nameof(TS))
        {
            Parameters =
            {
                Parameter.P_DT,
            },
            Channels =
            {
                DI = { string.Empty }
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_DT, 1 },
            },
        };

        /// <summary> Виртуальный сигнальный датчик температуры </summary>
        public static readonly DeviceSubType TS_VIRT = new(SubTypeIdentifier(DeviceType.TS) + 2, nameof(TS_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class TS : Device
    {
        public TS(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
