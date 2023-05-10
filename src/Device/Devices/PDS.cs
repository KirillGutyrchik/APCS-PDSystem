namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Сигнальный датчик разницы давления </summary>
        public static readonly DeviceSubType PDS = new(SubTypeIdentifier(DeviceType.PDS) + 1, nameof(PDS))
        {
            Parameters = 
            { 
                Parameter.P_DT 
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

        /// <summary> Виртуальный сигнальный датчик разницы давления </summary>
        public static readonly DeviceSubType PDS_VIRT = new(SubTypeIdentifier(DeviceType.PDS) + 2, nameof(PDS_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_DT, 1 },
            },
        };
    }

    public class PDS : Device
    {
        public PDS(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
