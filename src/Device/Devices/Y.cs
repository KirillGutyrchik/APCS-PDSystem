namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Обычный пневмоостров Festo </summary>
        public static readonly DeviceSubType Y = new(SubTypeIdentifier(DeviceType.Y) + 1, nameof(Y))
        {
            Channels = 
            {
                AO = { string.Empty },
            },
        };
        
        /// <summary> Festo 16 каналов </summary>
        public static readonly DeviceSubType DEV_VTUG_8 = new(SubTypeIdentifier(DeviceType.Y) + 2, nameof(DEV_VTUG_8))
        {
            Channels =
            {
                AO = { string.Empty },
            },
        };
        
        /// <summary> Festo 32 канала </summary>
        public static readonly DeviceSubType DEV_VTUG_16 = new(SubTypeIdentifier(DeviceType.Y) + 3, nameof(DEV_VTUG_16))
        {
            Channels =
            {
                AO = { string.Empty },
            },
        };

        /// <summary> Festo 48 каналов </summary>
        public static readonly DeviceSubType DEV_VTUG_24 = new(SubTypeIdentifier(DeviceType.Y) + 4, nameof(DEV_VTUG_24))
        {
            Channels =
            {
                AO = { string.Empty },
            },
        };
    }

    public class Y : Device
    {
        public Y(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {

        }

        // Данное устройство не сохраняется
        public override StringBuilder SaveAsLuaTable(string prefix = "")
        {
            return new StringBuilder();
        }
    }
}
