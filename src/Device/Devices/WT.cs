namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {

        /// <summary> Весы </summary>
        public static readonly DeviceSubType WT = new(SubTypeIdentifier(DeviceType.WT) + 1, nameof(WT))
        {
            Channels =
            {
                AI = { "Напряжение моста(+Ud)", "Референсное напряжение(+Uref)" },
            },
            Parameters =
            {
                Parameter.P_NOMINAL_W,
                Parameter.P_RKP,
                Parameter.P_C0,
                Parameter.P_DT,
            },
            DeviceTags = 
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Parameter.P_NOMINAL_W, 1 },
                { Parameter.P_DT, 1 },
                { Parameter.P_RKP, 1 },
                { Tag.P_CZ, 1 },
            },
        };

        /// <summary> Виртуальные весы </summary>
        public static readonly DeviceSubType WT_VIRT = new(SubTypeIdentifier(DeviceType.WT) + 2, nameof(WT_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
            },
        };

        /// <summary> Весы с интерфейсом RS-232 </summary>
        public static readonly DeviceSubType WT_RS232 = new(SubTypeIdentifier(DeviceType.WT) + 3, nameof(WT_RS232))
        {
            Channels =
            {
                AI = { string.Empty },
                AO = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.P_CZ, 1 },
            },
        };

        /// <summary> Весы с ethernet </summary>
        public static readonly DeviceSubType WT_ETH = new(SubTypeIdentifier(DeviceType.WT) + 4, nameof(WT_ETH))
        {
            Parameters =
            {
                Parameter.P_C0,
            },
            Properties =
            {
                Property.IP,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.P_CZ, 1 },
            },
        };

    }

    public class WT : Device
    {
        public WT(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {
        }
    }
}
