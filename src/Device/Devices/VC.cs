namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Аналоговый клапан </summary>
        public static readonly DeviceSubType VC = new(SubTypeIdentifier(DeviceType.VC) + 1, nameof(VC))
        {
            Channels =
            {
                AO = { string.Empty },
            },
            DeviceTags = 
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
            }
        };

        /// <summary> IO-Link аналоговый клапан </summary>
        public static readonly DeviceSubType VC_IOLINK = new(SubTypeIdentifier(DeviceType.VC) + 2, nameof(VC_IOLINK))
        {
            Channels =
            {
                AO = { string.Empty },
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.BLINK, 1 },
                { Tag.NAMUR_ST, 1 },
                { Tag.OPENED, 1 },
                { Tag.CLOSED, 1 },
            },
            // Is IO-Link
        };

        /// <summary> Виртуальный аналоговый клапан (без привязки к модулям) </summary>
        public static readonly DeviceSubType VC_VIRT = new(SubTypeIdentifier(DeviceType.VC) + 3, nameof(VC_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
            }
        };

    }

    public class VC : Device
    {
        public VC(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
