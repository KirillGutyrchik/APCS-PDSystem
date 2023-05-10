
namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Аналоговый вход с привязкой к модулям ввода-вывода </summary>
        public static readonly DeviceSubType AI = new(SubTypeIdentifier(DeviceType.AI) + 1, nameof(AI))
        {
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_MIN_V, 
                Parameter.P_MAX_V 
            },
            Channels =
            {
                AI = { string.Empty },
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.ST, 1 },
                { Parameter.P_MIN_V, 1 },
                { Parameter.P_MAX_V, 1 },
                {Tag.V, 1},
            },
        };

        /// <summary> Виртуальный аналоговый вход (без привязки к модулям) </summary>
        public static readonly DeviceSubType AI_VIRT = new(SubTypeIdentifier(DeviceType.AI) + 2, nameof(AI_VIRT))
        {
            DeviceTags =
            {
                {Tag.M, 1},
                {Tag.ST, 1},
                {Tag.V, 1},
            },
        };
    }


    public sealed class AI : Device
    {

        public AI(DeviceSubType subType, DeviceInfo deviceInfo)
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
