namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Аналоговый выход с привязкой к модулям ввода-вывода </summary>
        public static readonly DeviceSubType AO = new(SubTypeIdentifier(DeviceType.AO) + 1, nameof(AO))
        {
            Parameters =
            {
                Parameter.P_MIN_V,
                Parameter.P_MAX_V,
            },
            Channels =
            {
                AO = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1},
            },
        };

        /// <summary> Виртуальный аналоговый выход (без привязки к модулям) </summary>
        public static readonly DeviceSubType AO_VIRT = new(SubTypeIdentifier(DeviceType.AO) + 2, nameof(AO_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
            }
        };
    }


    public sealed class AO : Device
    {

        public AO(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {

        }

        public override string GetRange()
        {
            string range = string.Empty;
            if (Parameters.ContainsParameter(Parameter.P_MIN_V) &&
                Parameters.ContainsParameter(Parameter.P_MAX_V))
            {
                range = "_" + Parameters[Parameter.P_MIN_V]?.ToString() +
                    ".." + Parameters[Parameter.P_MAX_V]?.ToString();
            }

            return range;
        }
    }
}
