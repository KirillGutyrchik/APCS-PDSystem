using System.Collections.Immutable;

namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        private static Dictionary<string, int> ST_M_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
        };

        private static Dictionary<string, int> FB_OFF_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Parameter.P_ON_TIME, 1 },
            { Parameter.P_FB, 1 },
            { Tag.FB_OFF_ST, 1 },
        };

        private static Dictionary<string, int> FB_OFF_ON_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Parameter.P_ON_TIME, 1 },
            { Parameter.P_FB, 1 },
            { Tag.FB_OFF_ST, 1 },
            { Tag.FB_ON_ST, 1 },
        };

        private static Dictionary<string, int> BLINK_CS_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Parameter.P_ON_TIME, 1 },
            { Parameter.P_FB, 1 },
            { Tag.V, 1 },
            { Tag.BLINK, 1 },
            { Tag.CS, 1 },
            { Tag.ERR, 1 },
        };


        /// <summary> Клапан с одним каналом управления. </summary>
        public static readonly DeviceSubType V_DO1 = new(SubTypeIdentifier(DeviceType.V) + 1, nameof(V_DO1))
        {
            Channels =
            {
                DO = { string.Empty },
            },
            DeviceTags = ST_M_TAGS,
        };

        /// <summary> Клапан с двумя каналами управления. </summary>
        public static readonly DeviceSubType V_DO2 = new(SubTypeIdentifier(DeviceType.V) + 2, nameof(V_DO2))
        {
            Channels =
            {
                DO = { "Закрыть", "Открыть" },
            },
            DeviceTags = ST_M_TAGS,
        };

        /// <summary> Клапан с одним каналом управления и одной обратной связью (выключенное состояние). </summary>
        public static readonly DeviceSubType V_DO1_DI1_FB_OFF = new(SubTypeIdentifier(DeviceType.V) + 3, nameof(V_DO1_DI1_FB_OFF))
        {
            Channels =
            {
                DO = { string.Empty },
                DI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_TAGS,
        };

        /// <summary> Клапан с одним каналом управления и одной обратной связью (включенное состояние). </summary>
        public static readonly DeviceSubType V_DO1_DI1_FB_ON = new(SubTypeIdentifier(DeviceType.V) + 4, nameof(V_DO1_DI1_FB_ON))
        {
            Channels =
            {
                DO = { string.Empty },
                DI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_TAGS,
        };

        /// <summary> Клапан с одним каналом управления и двумя обратными связями. </summary>
        public static readonly DeviceSubType V_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 5, nameof(V_DO1_DI2))
        {
            Channels =
            {
                DO = { string.Empty },
                DI = { "Закрыт", "Открыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> Клапан с двумя каналами управления и двумя обратными связями. </summary>
        public static readonly DeviceSubType V_DO2_DI2 = new(SubTypeIdentifier(DeviceType.V) + 6, nameof(V_DO2_DI2))
        {
            Channels =
            {
                DO = { "Закрыть", "Открыть" },
                DI = { "Закрыт", "Открыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> Клапан микспруф. </summary>
        public static readonly DeviceSubType V_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 7, nameof(V_MIXPROOF))
        {
            Channels =
            {
                DO = { "Закрыть", "Открыть НС", "Открыть ВС" },
                DI = { "Закрыт", "Открыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> Клапан с двумя каналами управления и двумя обратными связями с AS интерфейсом (микспруф). </summary>
        public static readonly DeviceSubType V_AS_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 8, nameof(V_AS_MIXPROOF))
        {
            Channels =
            {
                AO = { string.Empty },
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_AS_NUMBER,
            },
        };

        /// <summary> Клапан с промывкой и двумя обратными связями (донный). </summary>
        public static readonly DeviceSubType V_BOTTOM_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 9, nameof(V_BOTTOM_MIXPROOF))
        {
            Channels =
            {
                DO = { "Закрыть", "Открыть мини", "Открыть НС" },
                DI = { "Закрыт", "Открыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> Клапан с одним каналом управления и двумя обратными связями с AS интерфейсом. </summary>
        public static readonly DeviceSubType V_AS_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 10, nameof(V_AS_DO1_DI2))
        {
            Channels =
            {
                AO = { string.Empty },
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_AS_NUMBER,
            },
        };

        /// <summary> Клапан с двумя каналами управления и двумя обратными связями бистабильный. </summary>
        public static readonly DeviceSubType V_DO2_DI2_BISTABLE = new(SubTypeIdentifier(DeviceType.V) + 11, nameof(V_DO2_DI2_BISTABLE))
        {
            Channels =
            {
                DO = { "Закрыть", "Открыть" },
                DI = { "Закрыт", "Открыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> IO-Link VTUG клапан с одним каналом управления. </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1 = new(SubTypeIdentifier(DeviceType.V) + 12, nameof(V_IOLINK_VTUG_DO1))
        {
            // RT PARAMETERS
            Channels =
            {
                AO = { string.Empty },
            },
            DeviceTags = ST_M_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_VTUG_NUMBER,
                RuntimeParameter.R_VTUG_SIZE,
            },
        };

        /// <summary> IO-Link VTUG клапан с одним каналом управления и одной обратной связью (выключенное состояние). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_FB_OFF = new(SubTypeIdentifier(DeviceType.V) + 13, nameof(V_IOLINK_VTUG_DO1_FB_OFF))
        {
            Channels =
            {
                AO = { string.Empty },
                DI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_VTUG_NUMBER,
                RuntimeParameter.R_VTUG_SIZE,
            },
        };

        /// <summary> IO-Link VTUG клапан с одним каналом управления и одной обратной связью (включенное состояние). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_FB_ON = new(SubTypeIdentifier(DeviceType.V) + 14, nameof(V_IOLINK_VTUG_DO1_FB_ON))
        {
            Channels =
            {
                AO = { string.Empty },
                DI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_VTUG_NUMBER,
                RuntimeParameter.R_VTUG_SIZE,
            },
        };

        /// <summary> Клапан микспруф с IO-Link. </summary>
        public static readonly DeviceSubType V_IOLINK_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 15, nameof(V_IOLINK_MIXPROOF))
        {
            Channels =
            {
                AO = { string.Empty },
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = BLINK_CS_TAGS,
            //Is IO-Link
        };

        /// <summary> Клапан с одним каналом управления и двумя обратными связями с IO-Link интерфейсом. </summary>
        public static readonly DeviceSubType V_IOLINK_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 16, nameof(V_IOLINK_DO1_DI2))
        {
            Channels =
            {
                AO = { string.Empty },
                AI = { string.Empty },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = BLINK_CS_TAGS,
        };

        /// <summary> IO-Link VTUG клапан с одним каналом управления и двумя обратными связями (включенное и выключенное состояния). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 17, nameof(V_IOLINK_VTUG_DO1_DI2))
        {
            Channels =
            {
                AO = { string.Empty },
                DI = { "Открыт", "Закрыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_VTUG_NUMBER,
                RuntimeParameter.R_VTUG_SIZE,
            },
        };

        /// <summary> Виртуальный клапан (без привязки к модулям). </summary>
        public static readonly DeviceSubType V_VIRT = new(SubTypeIdentifier(DeviceType.V) + 18, nameof(V_VIRT))
        {
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
            }
        };

        /// <summary> Клапан с мини-клапаном промывки. </summary>
        public static readonly DeviceSubType V_MINI_FLUSHING = new(SubTypeIdentifier(DeviceType.V) + 19, nameof(V_MINI_FLUSHING))
        {
            Channels =
            {
                DO = { "Открыть", "Открыть мини" },
                DI = { "Открыт", "Закрыт" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_FB,
            },
            DeviceTags = FB_OFF_ON_TAGS,
        };

        /// <summary> Противосмешивающий клапан с управление от пневмоострова IO-Link </summary>
        public static readonly DeviceSubType V_IOL_TERMINAL_MIXPROOF_DO3 = new(SubTypeIdentifier(DeviceType.V) + 20, nameof(V_IOL_TERMINAL_MIXPROOF_DO3))
        {
            Channels =
            {
                AO = { "Открыть", "Открыть ВС", "Открыть НС" },
            },
            DeviceTags = ST_M_TAGS,
            RuntimeParameters =
            {
                RuntimeParameter.R_ID_ON,
                RuntimeParameter.R_ID_UPPER_SEAT,
                RuntimeParameter.R_ID_LOWER_SEAT,
            },
        };

    }

    public class V : Device
    {
        public V(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {
            if (Parameters.ToList().Contains(Parameter.P_FB))
                Parameters[Parameter.P_FB] = 1;
        }

        // CHECK
    }
}
