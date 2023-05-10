namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Дискретный вход с привязкой к модулям. </summary>
        public static readonly DeviceSubType DI = new(SubTypeIdentifier(DeviceType.DI) + 1, nameof(DI))
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
            }
        };

        /// <summary> Виртуальный дискретный вход (без привязки к модулям). </summary>
        public static readonly DeviceSubType DI_VIRT = new(SubTypeIdentifier(DeviceType.DI) + 2, nameof(DI_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
            }
        };
    }

    public class DI : Device
    {
        public DI(DeviceSubType subType, DeviceInfo deviceInfo)     
            : base(subType, deviceInfo)
        {
        }
    }
}
