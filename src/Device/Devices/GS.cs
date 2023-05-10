namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Датчик положения </summary>
        public static readonly DeviceSubType GS = new(SubTypeIdentifier(DeviceType.GS) + 1, nameof(GS))
        {
            Parameters =
            {
                Parameter.P_DT,
            },
            Channels =
            {
                DI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_DT, 1 },
            },
        };

        /// <summary> Виртуальный датчик положения (без привязки к модулям) </summary>
        public static readonly DeviceSubType GS_VIRT = new(SubTypeIdentifier(DeviceType.GS) + 2, nameof(GS_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class GS : Device
    {
        public GS(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
