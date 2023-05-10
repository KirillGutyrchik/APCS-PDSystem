namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Счетчик </summary>
        public static readonly DeviceSubType FQT = new(SubTypeIdentifier(DeviceType.FQT) + 1, nameof(FQT))
        {
            Channels =
            {
                AI = { "Объем" },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ABS_V, 1 },
            },
        };

        /// <summary> Счетчик с расходом </summary>
        public static readonly DeviceSubType FQT_F = new(SubTypeIdentifier(DeviceType.FQT) + 2, nameof(FQT_F))
        {
            Channels =
            {
                AI = { "Объем", "Поток" },
            },
            Parameters =
            {
                Parameter.P_MIN_F,
                Parameter.P_MAX_F,
                Parameter.P_C0,
                Parameter.P_DT,
                Parameter.P_ERR_MIN_FLOW,
            },
            Properties =
            {
                Property.MT,    // is multiple "MT1, MT2"
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.P_MIN_FLOW, 1 },
                { Tag.P_MAX_FLOW, 1 },
                { Tag.P_CZ, 1 },
                { Tag.F, 1 },
                { Parameter.P_DT, 1 },
                { Tag.ABS_V, 1 },
                { Parameter.P_ERR_MIN_FLOW, 1 },
            },
        };

        //
        // подтип #3 свободен
        //
        
        /// <summary> Виртуальный счётчик (без привязки к модулям) </summary>
        public static readonly DeviceSubType FQT_VIRT = new(SubTypeIdentifier(DeviceType.FQT) + 4, nameof(FQT_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.P_MIN_FLOW, 1 },
                { Tag.P_MAX_FLOW, 1 },
                { Tag.P_CZ, 1 },
                { Tag.F, 1 },
                { Parameter.P_DT, 1 },
                { Tag.ABS_V, 1 },
                { Parameter.P_ERR_MIN_FLOW, 1 },
            },
        };

        /// <summary> Счетчик IO-Link </summary>
        public static readonly DeviceSubType FQT_IOLINK = new(SubTypeIdentifier(DeviceType.FQT) + 5, nameof(FQT_IOLINK))
        {
            Channels =
            {
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_DT,
                Parameter.P_ERR_MIN_FLOW,
            },
            Properties =
            {
                Property.MT,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ABS_V, 1 },
                { Tag.T, 1 },
                { Parameter.P_ERR_MIN_FLOW, 1 },
            },
            // Is IO-Link
        };
    }

    public class FQT : Device
    {
        public FQT(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }

        // get range
    }
}
