namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        public static readonly DeviceSubType C = new(SubTypeIdentifier(DeviceType.C) + 1, nameof(C))
        {
            Parameters =
            {
                Parameter.P_k,
                Parameter.P_Ti,
                Parameter.P_Td,
                Parameter.P_dt,
                Parameter.P_max,
                Parameter.P_min,
                Parameter.P_acceleration_time,
                Parameter.P_is_manual_mode,
                Parameter.P_U_manual,
                Parameter.P_k2,
                Parameter.P_Ti2,
                Parameter.P_Td2,
                Parameter.P_out_max,
                Parameter.P_out_min,
                Parameter.P_is_reverse,
                Parameter.P_is_zero_start,
            },
            Properties =
            {
                Property.IN_VALUE,
                Property.OUT_VALUE,
            },
            DeviceTags =
            {
                { Tag.ST, 1 },
                { Tag.M, 1 },
                { Tag.V, 1 },
                { Tag.Z, 1 },
            },
        };

    }

    /// <summary>
    /// ПИД - регулятор
    /// </summary>
    public class C : Device
    {
        public C(DeviceSubType subType, DeviceInfo deviceInfo)
            : base(subType, deviceInfo)
        {
            
            initParameters(); // устанавливаем базовые значения для параметров ПИД
        }

        /// <summary>
        /// Установить базовые значения параметров для ПИД-регулятора
        /// </summary>
        private void initParameters()
        {
            Parameters[Parameter.P_k] = 1;
            Parameters[Parameter.P_Ti] = 15;
            Parameters[Parameter.P_Td] = 0.01;
            Parameters[Parameter.P_dt] = 1000;

            Parameters[Parameter.P_max] = 100;
            Parameters[Parameter.P_min] = 0;

            Parameters[Parameter.P_acceleration_time] = 30;
            Parameters[Parameter.P_is_manual_mode] = 0;
            Parameters[Parameter.P_U_manual] = 65;

            Parameters[Parameter.P_k2] = 0;
            Parameters[Parameter.P_k2] = 0;
            Parameters[Parameter.P_k2] = 0;

            Parameters[Parameter.P_out_max] = 100;
            Parameters[Parameter.P_out_min] = 0;

            Parameters[Parameter.P_is_reverse] = 0;
            Parameters[Parameter.P_is_zero_start] = 1;
        }
    }
}
