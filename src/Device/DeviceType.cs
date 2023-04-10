using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSystem.Ext;

namespace PDSystem.Device
{
    /// <summary>
    /// Тип устройства
    /// </summary>
    public record class DeviceType : Enumeration<DeviceType>
    {
        /// <summary> Неопределенный тип </summary>
        public static readonly DeviceType NONE = new(-1, nameof(NONE));

        /// <summary> Клапан </summary>
        public static readonly DeviceType V = new(0, nameof(V));
        /// <summary> Управляемый клапан </summary>
        public static readonly DeviceType VC = new(1, nameof(VC));
        /// <summary> Двигатель </summary>
        public static readonly DeviceType M = new(2, nameof(M));
        /// <summary> Уровень (есть/нет) </summary>
        public static readonly DeviceType LS = new(3, nameof(LS));
        /// <summary> Температура </summary>
        public static readonly DeviceType TE = new(4, nameof(TE));
        /// <summary> Датчик положения </summary>
        public static readonly DeviceType GS = new(6, nameof(GS));
        /// <summary> Расход (есть/нет) </summary>
        public static readonly DeviceType FS = new(5, nameof(FS));
        /// <summary> Счетчик. </summary>
        public static readonly DeviceType FQT = new(7, nameof(FQT));
        /// <summary> Уровень (значение) </summary>
        public static readonly DeviceType LT = new(8, nameof(LT));
        /// <summary> Концентрация </summary>
        public static readonly DeviceType QT = new(9, nameof(QT));
        /// <summary> Звуковая сигнализация </summary>
        public static readonly DeviceType HA = new(10, nameof(HA));
        /// <summary> Световая сигнализация </summary>
        public static readonly DeviceType HL = new(11, nameof(HL));
        /// <summary> Кнопка </summary>
        public static readonly DeviceType SB = new(12, nameof(SB));
        /// <summary> Дискретный входной сигнал </summary>
        public static readonly DeviceType DI = new(13, nameof(DI));
        /// <summary> Дискретный выходной сигнал </summary>
        public static readonly DeviceType DO = new(14, nameof(DO));
        /// <summary> Аналоговый входной сигнал </summary>
        public static readonly DeviceType AI = new(15, nameof(AI));
        /// <summary> Аналоговый выходной сигнал </summary>
        public static readonly DeviceType AO = new(16, nameof(AO));
        /// <summary> Датчик веса </summary>
        public static readonly DeviceType WT = new(17, nameof(WT));
        /// <summary> Датчик давления </summary>
        public static readonly DeviceType PT = new(18, nameof(PT));
        /// <summary> Автоматический выключатель </summary>
        public static readonly DeviceType F = new(19, nameof(F));
        /// <summary> ПИД-регулятор </summary>
        public static readonly DeviceType C = new(20, nameof(C));
        /// <summary> Сигнальная колонна </summary>
        public static readonly DeviceType HLA = new(21, nameof(HLA));
        /// <summary> Камера </summary>
        public static readonly DeviceType CAM = new(22, nameof(CAM));
        /// <summary> Сигнальный датчик перепада давления </summary>
        public static readonly DeviceType PDS = new(23, nameof(PDS));
        /// <summary> Сигнальный датчик температуры </summary>
        public static readonly DeviceType TS = new(24, nameof(TS));

        // Устройства отсутствующие в контроллере (-2)
        /// <summary> Пневмоостров Festo </summary>
        public static readonly DeviceType Y = new(-2, nameof(Y));

        protected DeviceType(int id, string name)
            : base(id, name)
        {

        }

        
    }
}