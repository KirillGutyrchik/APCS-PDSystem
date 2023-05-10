namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        private static readonly Dictionary<string, int> M_REVS_TAGS = new()
        {
            { Tag.ST, 1 },
            { Tag.M, 1 },
            { Parameter.P_ON_TIME, 1 },
            { Tag.V, 1 },
            { Tag.R, 1 },
        };

        /// <summary> Мотор без управления частотой вращения </summary>
        public static readonly DeviceSubType M = new(SubTypeIdentifier(DeviceType.M) + 1, nameof(M))
        {
            Channels =
            {
                DO = { "Пск" },
                DI = { "Обратная связь" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_ON_TIME, 1 },
            },
        };

        /// <summary> Мотор с управлением частотой вращения </summary>
        public static readonly DeviceSubType M_FREQ = new(SubTypeIdentifier(DeviceType.M) + 2, nameof(M_FREQ))
        {
            Channels =
            {
                DO = { "Пск" },
                DI = { "Обратная связь" },
                AO = { "Частота вращения" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Parameter.P_ON_TIME, 1 },
                { Tag.V, 1 },
            },
        };

        /// <summary> Мотор с реверсом без управления частотой вращения. Реверс включается совместно </summary>
        public static readonly DeviceSubType M_REV = new(SubTypeIdentifier(DeviceType.M) + 3, nameof(M_REV))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Обратная связь" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается совместно </summary>
        public static readonly DeviceSubType M_REV_FREQ = new(SubTypeIdentifier(DeviceType.M) + 4, nameof(M_REV_FREQ))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Обратная связь" },
                AO = { "Частота вращения" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary> Мотор с реверсом без управления частотой вращения. Реверс включается отдельно </summary>
        public static readonly DeviceSubType M_REV_2 = new(SubTypeIdentifier(DeviceType.M) + 5, nameof(M_REV_2))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Обратная связь" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается отдельно </summary>
        public static readonly DeviceSubType M_REV_FREQ_2 = new(SubTypeIdentifier(DeviceType.M) + 6, nameof(M_REV_FREQ_2))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Обратная связь" },
                AO = { "Частота вращения" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary>  </summary>
        public static readonly DeviceSubType M_REV_2_ERROR = new(SubTypeIdentifier(DeviceType.M) + 7, nameof(M_REV_2_ERROR))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Авария" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается отдельно. Отдельный сигнал аварии </summary>
        public static readonly DeviceSubType M_REV_FREQ_2_ERROR = new(SubTypeIdentifier(DeviceType.M) + 8, nameof(M_REV_FREQ_2_ERROR))
        {
            Channels =
            {
                DO = { "Реверс", "Пск" },
                DI = { "Обратная связь", "Авария" },
                AO = { "Частота вращения" },
            },
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            DeviceTags = M_REVS_TAGS,
        };

        /// <summary> Мотор управляемый частотником Altivar. Связь с частотником по Ethernet. Реверс и аварии опционально </summary>
        public static readonly DeviceSubType M_ATV = new(SubTypeIdentifier(DeviceType.M) + 9, nameof(M_ATV))
        {
            Parameters =
            {
                Parameter.P_ON_TIME,
            },
            Properties =
            {
                Property.IP,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.ST, 1 },
                { Tag.R, 1 },
                { Tag.FRQ, 1 },
                { Tag.RPM, 1 },
                { Tag.EST, 1 },
                { Tag.V, 1 },
                { Parameter.P_ON_TIME, 1 },
            },
        };

        /// <summary> Виртуальный мотор (без привязки к модулям) </summary>
        public static readonly DeviceSubType M_VIRT = new(SubTypeIdentifier(DeviceType.M) + 10, nameof(M_VIRT))
        {
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.ST, 1 },
                { Tag.V, 1 },
            },
        };

        /// <summary> Аналогично M_ATV, только есть параметры для расчета линейной скорости </summary>
        public static readonly DeviceSubType M_ATV_LINEAR = new(SubTypeIdentifier(DeviceType.M) + 11, nameof(M_ATV_LINEAR))
        {
            Parameters =
            {
                Parameter.P_ON_TIME,
                Parameter.P_SHAFT_DIAMETER,
                Parameter.P_TRANSFER_RATIO,
            },
            Properties =
            {
                Property.IP,
            },
            DeviceTags =
            {
                { Tag.M, 1 },
                { Tag.ST, 1 },
                { Tag.R, 1 },
                { Tag.FRQ, 1 },
                { Tag.RPM, 1 },
                { Tag.EST, 1 },
                { Tag.V, 1 },
                { Parameter.P_ON_TIME, 1 },
                { Parameter.P_SHAFT_DIAMETER, 1 },
                { Parameter.P_TRANSFER_RATIO, 1 },
            }
        };

    }

    public class M : Device
    {
        public M(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
        }
    }
}
