namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> IO-Link автоматический выключатель </summary>
        public static readonly DeviceSubType F = new(SubTypeIdentifier(DeviceType.F) + 1, nameof(F))
        { 
            Channels =
            { 
                AI = { string.Empty }, 
                AO = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.ST, 1 },
                { Tag.ERR, 1 },
                { Tag.ST_CH, 4 },
                { Tag.NOMINAL_CURRENT_CH, 4 },
                { Tag.LOAD_CURRENT_CH, 4 },
                { Tag.ERR_CH, 4 },
            }

            //Is IO-Link
        };

        /// <summary> Виртуальный автоматический выключатель (без привязки к модулям) </summary>
        public static readonly DeviceSubType F_VIRT = new(SubTypeIdentifier(DeviceType.F) + 2, nameof(F_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.ST, 1 },
                { Tag.V, 1 },
            }
        };
    }

    public class F : Device
    {
        public F(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }

        // Check article
    }
}
