namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Датчик наличия расхода </summary>
        public static readonly DeviceSubType FS = new(SubTypeIdentifier(DeviceType.FS) + 1, nameof(FS))
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

        /// <summary> Виртуальный датчик наличия расхода (без привязки к модулям) </summary>
        public static readonly DeviceSubType FS_VIRT = new(SubTypeIdentifier(DeviceType.FS) + 2, nameof(FS_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            },
        };
    }

    public class FS : Device
    {
        public FS(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
