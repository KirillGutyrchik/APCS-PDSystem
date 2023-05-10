namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Камера с готовностью, результатом обработки и сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI2 = new(SubTypeIdentifier(DeviceType.CAM) + 1, nameof(CAM_DO1_DI2))
        {
            Parameters =
            {
                Parameter.P_READY_TIME,
            },
            Properties =
            {
                Property.IP,
            },
            Channels =
            {
                DO = { "Сигнал активации" },
                DI = { "Результат обработки", "Готовность" },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.RESULT, 1 },
            }
        };

        /// <summary> Камера с результатом обработки, сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI1 = new(SubTypeIdentifier(DeviceType.CAM) + 2, nameof(CAM_DO1_DI1))
        {
            Properties =
            {
                Property.IP,
            },
            Channels =
            {
                DO = { "Сигнал активации" },
                DI = { "Результат обработки" },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.READY, 1 },
                { Tag.RESULT, 1 },
                { Parameter.P_READY_TIME, 1 }
            }
        };

        /// <summary> Камера с готосностью, 2-мя результатами обработки и сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI3 = new(SubTypeIdentifier(DeviceType.CAM) + 3, nameof(CAM_DO1_DI3))
        {
            Parameters =
            {
                Parameter.P_READY_TIME,
            },
            Properties =
            {
                Property.IP,
            },
            Channels =
            {
                DO = { "Сигнал активации" },
                DI = { "Результат обработки", "Готовность", "Результат обработки 2" },
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.READY, 1 },
                { Tag.RESULT, 1 },
                { Parameter.P_READY_TIME, 1 }
            }
        };

    }


    public class CAM : Device
    {
        public CAM(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {
        }
    }
}
