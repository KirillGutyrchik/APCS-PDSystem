namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Концентратомер </summary>
        public static readonly DeviceSubType QT = new(SubTypeIdentifier(DeviceType.QT) + 1, nameof(QT))
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
        
        /// <summary> Концентратомер c диагностикой </summary>
        public static readonly DeviceSubType QT_OK = new(SubTypeIdentifier(DeviceType.QT) + 2, nameof(QT_OK))
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
                DI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.OK, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
                { Tag.P_CZ, 1 },
            },
        };
        
        /// <summary> IO-Link концентратомер </summary>
        public static readonly DeviceSubType QT_IOLINK = new(SubTypeIdentifier(DeviceType.QT) + 3, nameof(QT_IOLINK))
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
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.P_CZ, 1 },
                { Tag.T, 1 },
                { Parameter.P_ERR, 1 },
            },
            // Is IO-Link
        };
        
        /// <summary> Виртуальный концентратомер (без привязки к модулям) </summary>
        public static readonly DeviceSubType QT_VIRT = new(SubTypeIdentifier(DeviceType.QT) + 4, nameof(QT_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
            },
        };
    }

    public class QT : Device
    {
        public QT(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
