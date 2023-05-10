namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Текущий уровень без дополнительных параметров </summary>
        public static readonly DeviceSubType LT = new(SubTypeIdentifier(DeviceType.LT) + 1, nameof(LT))
        {
            Channels =
            {
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
            },
            DeviceTags = 
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Parameter.P_ERR, 1 },
            }
        };

        /// <summary> Текущий уровень для цилиндрического танка </summary>
        public static readonly DeviceSubType LT_CYL = new(SubTypeIdentifier(DeviceType.LT) + 2, nameof(LT_CYL))
        {
            Channels = 
            {
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
                Parameter.P_MAX_P,
                Parameter.P_R,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Parameter.P_MAX_P, 1 },
                { Parameter.P_R, 1 },
                { Tag.CLEVEL, 1 },
                { Parameter.P_ERR, 1 },
            }
        };

        /// <summary> Текущий уровень для танка с конусом </summary>
        public static readonly DeviceSubType LT_CONE = new(SubTypeIdentifier(DeviceType.LT) + 3, nameof(LT_CONE))
        {
            Channels =
            {
                AI = { string.Empty },
            },
            Parameters = 
            {
                Parameter.P_C0,
                Parameter.P_ERR,
                Parameter.P_MAX_P,
                Parameter.P_R,
                Parameter.P_H_CONE,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Parameter.P_H_CONE, 1 },
                { Parameter.P_MAX_P, 1 },
                { Parameter.P_R, 1 },
                { Tag.CLEVEL, 1 },
                { Parameter.P_ERR, 1 },
            }
        };

        /// <summary> Текущий уровень для танка с усеченным цилиндром </summary>
        public static readonly DeviceSubType LT_TRUNC = new(SubTypeIdentifier(DeviceType.LT) + 4, nameof(LT_TRUNC))
        {
            Channels =
            {
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
                Parameter.P_MAX_P,
                Parameter.P_R,
                Parameter.P_H_TRUNC,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Parameter.P_H_TRUNC, 1 },
                { Parameter.P_MAX_P, 1 },
                { Parameter.P_R, 1 },
                { Tag.CLEVEL, 1 },
                { Parameter.P_ERR, 1 },
            }
        };

        /// <summary> IO-Link текущий уровень без дополнительных параметров </summary>
        public static readonly DeviceSubType LT_IOLINK = new(SubTypeIdentifier(DeviceType.LT) + 5, nameof(LT_IOLINK))
        {
            Channels =
            {
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_C0,
                Parameter.P_ERR,
                Parameter.P_MAX_P,
                Parameter.P_R,
                Parameter.P_H_CONE,
            },
            Properties =
            {
                Property.PT,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.P_CZ, 1 },
                { Tag.V, 1 },
                { Parameter.P_H_CONE, 1 },
                { Parameter.P_MAX_P, 1 },
                { Parameter.P_R, 1 },
                { Tag.CLEVEL, 1 },
                { Parameter.P_ERR, 1 },
            },
            // Is IO-Link
        };

        /// <summary> Виртуальный текущий уровень (без привязки к модулям) </summary>
        public static readonly DeviceSubType LT_VIRT = new(SubTypeIdentifier(DeviceType.LT) + 6, nameof(LT_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.V, 1 },
            }
        };
    }

    public class LT : Device
    {
        public LT(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
