using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PDSystem.Ext;

namespace PDSystem.Device
{
    /// <summary>
    /// Подтип устройства
    /// </summary>
    public partial record class DeviceSubType : Enumeration<DeviceSubType>
    {
        #region список подтипов
        /// <summary> Неопределенный подтип. </summary>
        public static readonly DeviceSubType NONE = new(0, nameof(NONE));

        #region V   - Клапан
        /// <summary> Клапан с одним каналом управления. </summary>
        public static readonly DeviceSubType V_DO1 = new(SubTypeIdentifier(DeviceType.V) + 1, nameof(V_DO1))
        {
            Parameters = new(){ Parameter.P_MIN_V },
        };
        /// <summary> Клапан с двумя каналами управления. </summary>
        public static readonly DeviceSubType V_DO2 = new(SubTypeIdentifier(DeviceType.V) + 2, nameof(V_DO2));
        /// <summary> Клапан с одним каналом управления и одной обратной связью (выключенное состояние). </summary>
        public static readonly DeviceSubType V_DO1_DI1_FB_OFF = new(SubTypeIdentifier(DeviceType.V) + 3, nameof(V_DO1_DI1_FB_OFF));
        /// <summary> Клапан с одним каналом управления и одной обратной связью (включенное состояние). </summary>
        public static readonly DeviceSubType V_DO1_DI1_FB_ON = new(SubTypeIdentifier(DeviceType.V) + 4, nameof(V_DO1_DI1_FB_ON));
        /// <summary> Клапан с одним каналом управления и двумя обратными связями. </summary>
        public static readonly DeviceSubType V_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 5, nameof(V_DO1_DI2));
        /// <summary> Клапан с двумя каналами управления и двумя обратными связями. </summary>
        public static readonly DeviceSubType V_DO2_DI2 = new(SubTypeIdentifier(DeviceType.V) + 6, nameof(V_DO2_DI2));
        /// <summary> Клапан микспруф. </summary>
        public static readonly DeviceSubType V_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 7, nameof(V_MIXPROOF));
        /// <summary> Клапан с двумя каналами управления и двумя обратными связями с AS интерфейсом (микспруф). </summary>
        public static readonly DeviceSubType V_AS_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 8, nameof(V_AS_MIXPROOF));
        /// <summary> Клапан с промывкой и двумя обратными связями (донный). </summary>
        public static readonly DeviceSubType V_BOTTOM_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 9, nameof(V_BOTTOM_MIXPROOF));
        /// <summary> Клапан с одним каналом управления и двумя обратными связями с AS интерфейсом. </summary>
        public static readonly DeviceSubType V_AS_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 10, nameof(V_AS_DO1_DI2));
        /// <summary> Клапан с двумя каналами управления и двумя обратными связями бистабильный. </summary>
        public static readonly DeviceSubType V_DO2_DI2_BISTABLE = new(SubTypeIdentifier(DeviceType.V) + 11, nameof(V_DO2_DI2_BISTABLE));
        /// <summary> IO-Link VTUG клапан с одним каналом управления. </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1 = new(SubTypeIdentifier(DeviceType.V) + 12, nameof(V_IOLINK_VTUG_DO1));
        /// <summary> IO-Link VTUG клапан с одним каналом управления и одной обратной связью (выключенное состояние). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_FB_OFF = new(SubTypeIdentifier(DeviceType.V) + 13, nameof(V_IOLINK_VTUG_DO1_FB_OFF));
        /// <summary> IO-Link VTUG клапан с одним каналом управления и одной обратной связью (включенное состояние). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_FB_ON = new(SubTypeIdentifier(DeviceType.V) + 14, nameof(V_IOLINK_VTUG_DO1_FB_ON));
        /// <summary> Клапан микспруф с IO-Link. </summary>
        public static readonly DeviceSubType V_IOLINK_MIXPROOF = new(SubTypeIdentifier(DeviceType.V) + 15, nameof(V_IOLINK_MIXPROOF));
        /// <summary> Клапан с одним каналом управления и двумя обратными связями с IO-Link интерфейсом. </summary>
        public static readonly DeviceSubType V_IOLINK_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 16, nameof(V_IOLINK_DO1_DI2));
        /// <summary> IO-Link VTUG клапан с одним каналом управления и двумя обратными связями (включенное и выключенное состояния). </summary>
        public static readonly DeviceSubType V_IOLINK_VTUG_DO1_DI2 = new(SubTypeIdentifier(DeviceType.V) + 17, nameof(V_IOLINK_VTUG_DO1_DI2));
        /// <summary> Виртуальный клапан (без привязки к модулям). </summary>
        public static readonly DeviceSubType V_VIRT = new(SubTypeIdentifier(DeviceType.V) + 18, nameof(V_VIRT));
        /// <summary> Клапан с мини-клапаном промывки. </summary>
        public static readonly DeviceSubType V_MINI_FLUSHING = new(SubTypeIdentifier(DeviceType.V) + 19, nameof(V_MINI_FLUSHING));
        /// <summary> Противосмешивающий клапан с управление от пневмоострова IO-Link </summary>
        public static readonly DeviceSubType V_IOL_TERMINAL_MIXPROOF_DO3 = new(SubTypeIdentifier(DeviceType.V) + 20, nameof(V_IOL_TERMINAL_MIXPROOF_DO3));
        #endregion
        #region VC  - управляемый клапан
        /// <summary> Аналоговый клапан </summary>
        public static readonly DeviceSubType VC = new(SubTypeIdentifier(DeviceType.VC) + 1, nameof(VC));
        /// <summary> IO-Link аналоговый клапан </summary>
        public static readonly DeviceSubType VC_IOLINK = new(SubTypeIdentifier(DeviceType.VC) + 2, nameof(VC_IOLINK));
        /// <summary> Виртуальный аналоговый клапан (без привязки к модулям) </summary>
        public static readonly DeviceSubType VC_VIRT = new(SubTypeIdentifier(DeviceType.VC) + 3, nameof(VC_VIRT));
        #endregion
        #region M   - Двигатель
        /// <summary> Мотор без управления частотой вращения </summary>
        public static readonly DeviceSubType M = new(SubTypeIdentifier(DeviceType.M) + 1, nameof(M));
        /// <summary> Мотор с управлением частотой вращения </summary>
        public static readonly DeviceSubType M_FREQ = new(SubTypeIdentifier(DeviceType.M) + 2, nameof(M_FREQ));
        /// <summary> Мотор с реверсом без управления частотой вращения. Реверс включается совместно </summary>
        public static readonly DeviceSubType M_REV = new(SubTypeIdentifier(DeviceType.M) + 3, nameof(M_REV));
        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается совместно </summary>
        public static readonly DeviceSubType M_REV_FREQ = new(SubTypeIdentifier(DeviceType.M) + 4, nameof(M_REV_FREQ));
        /// <summary> Мотор с реверсом без управления частотой вращения. Реверс включается отдельно </summary>
        public static readonly DeviceSubType M_REV_2 = new(SubTypeIdentifier(DeviceType.M) + 5, nameof(M_REV_2));
        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается отдельно </summary>
        public static readonly DeviceSubType M_REV_FREQ_2 = new(SubTypeIdentifier(DeviceType.M) + 6, nameof(M_REV_FREQ_2));
        /// <summary>  </summary>
        public static readonly DeviceSubType M_REV_2_ERROR = new(SubTypeIdentifier(DeviceType.M) + 7, nameof(M_REV_2_ERROR));
        /// <summary> Мотор с реверсом с управлением частотой вращения. Реверс включается отдельно. Отдельный сигнал аварии </summary>
        public static readonly DeviceSubType M_REV_FREQ_2_ERROR = new(SubTypeIdentifier(DeviceType.M) + 8, nameof(M_REV_FREQ_2_ERROR));
        /// <summary> Мотор управляемый частотником Altivar. Связь с частотником по Ethernet. Реверс и аварии опционально </summary>
        public static readonly DeviceSubType M_ATV = new(SubTypeIdentifier(DeviceType.M) + 9, nameof(M_ATV));
        /// <summary> Виртуальный мотор (без привязки к модулям) </summary>
        public static readonly DeviceSubType M_VIRT = new(SubTypeIdentifier(DeviceType.M) + 10, nameof(M_VIRT));
        /// <summary> Аналогично M_ATV, только есть параметры для расчета линейной скорости </summary>
        public static readonly DeviceSubType M_ATV_LINEAR = new(SubTypeIdentifier(DeviceType.M) + 11, nameof(M_ATV_LINEAR));
        #endregion
        #region LS  - Уровень (есть/нет)
        /// <summary> Подключение по схеме минимум </summary>
        public static readonly DeviceSubType LS_MIN = new(SubTypeIdentifier(DeviceType.LS) + 1, nameof(LS_MIN));
        /// <summary> Подключение по схеме максимум </summary>
        public static readonly DeviceSubType LS_MAX = new(SubTypeIdentifier(DeviceType.LS) + 2, nameof(LS_MAX));
        /// <summary> IO-Link уровень. Подключение по схеме минимум </summary>
        public static readonly DeviceSubType LS_IOLINK_MIN = new(SubTypeIdentifier(DeviceType.LS) + 3, nameof(LS_IOLINK_MIN));
        /// <summary> IO-Link уровень. Подключение по схеме максимум </summary>
        public static readonly DeviceSubType LS_IOLINK_MAX = new(SubTypeIdentifier(DeviceType.LS) + 4, nameof(LS_IOLINK_MAX));
        /// <summary> Виртуальный датчик уровня (без привязки к модулям) </summary>
        public static readonly DeviceSubType LS_VIRT = new(SubTypeIdentifier(DeviceType.LS) + 5, nameof(LS_VIRT));
        #endregion
        #region TE  - Температура
        /// <summary> Текущая температура </summary>
        public static readonly DeviceSubType TE = new(SubTypeIdentifier(DeviceType.TE) + 1, nameof(TE));
        /// <summary> IO-Link текущая температура </summary>
        public static readonly DeviceSubType TE_IOLINK = new(SubTypeIdentifier(DeviceType.TE) + 2, nameof(TE_IOLINK));
        /// <summary> Виртуальный датчик температуры (без привязки к модулям) </summary>
        public static readonly DeviceSubType TE_VIRT = new(SubTypeIdentifier(DeviceType.TE) + 3, nameof(TE_VIRT));
        /// <summary> Аналоговый датчик температуры 4-20 мА </summary>
        public static readonly DeviceSubType TE_ANALOG = new(SubTypeIdentifier(DeviceType.TE) + 4, nameof(TE_ANALOG));
        #endregion
        #region GS  - Датчик положения
        /// <summary> Датчик положения </summary>
        public static readonly DeviceSubType GS = new(SubTypeIdentifier(DeviceType.GS) + 1, nameof(GS));
        /// <summary> Виртуальный датчик положения (без привязки к модулям) </summary>
        public static readonly DeviceSubType GS_VIRT = new(SubTypeIdentifier(DeviceType.GS) + 2, nameof(GS_VIRT));
        #endregion
        #region FS  - Расход (есть/нет)
        /// <summary> Датчик наличия расхода </summary>
        public static readonly DeviceSubType FS = new(SubTypeIdentifier(DeviceType.FS) + 1, nameof(FS));
        /// <summary> Виртуальный датчик наличия расхода (без привязки к модулям) </summary>
        public static readonly DeviceSubType FS_VIRT = new(SubTypeIdentifier(DeviceType.FS) + 2, nameof(FS_VIRT));
        #endregion
        #region FQT - Счетчик
        /// <summary> Счетчик </summary>
        public static readonly DeviceSubType FQT = new(SubTypeIdentifier(DeviceType.FQT) + 1, nameof(FQT));
        /// <summary> Счетчик с расходом </summary>
        public static readonly DeviceSubType FQT_F = new(SubTypeIdentifier(DeviceType.FQT) + 2, nameof(FQT_F));
        // подтип #3 удален
        /// <summary> Виртуальный счётчик (без привязки к модулям) </summary>
        public static readonly DeviceSubType FQT_VIRT = new(SubTypeIdentifier(DeviceType.FQT) + 4, nameof(FQT_VIRT));
        /// <summary> Счетчик IO-Link </summary>
        public static readonly DeviceSubType FQT_IOLINK = new(SubTypeIdentifier(DeviceType.FQT) + 5, nameof(FQT_IOLINK));
        #endregion
        #region LT  - Уровень (значение)
        /// <summary> Текущий уровень без дополнительных параметров </summary>
        public static readonly DeviceSubType LT = new(SubTypeIdentifier(DeviceType.LT) + 1, nameof(LT));
        /// <summary> Текущий уровень для цилиндрического танка </summary>
        public static readonly DeviceSubType LT_CYL = new(SubTypeIdentifier(DeviceType.LT) + 2, nameof(LT_CYL));
        /// <summary> Текущий уровень для танка с конусом </summary>
        public static readonly DeviceSubType LT_CONE = new(SubTypeIdentifier(DeviceType.LT) + 3, nameof(LT_CONE));
        /// <summary> Текущий уровень для танка с усеченным цилиндром </summary>
        public static readonly DeviceSubType LT_TRUNC = new(SubTypeIdentifier(DeviceType.LT) + 4, nameof(LT_TRUNC));
        /// <summary> IO-Link текущий уровень без дополнительных параметров </summary>
        public static readonly DeviceSubType LT_IOLINK = new(SubTypeIdentifier(DeviceType.LT) + 5, nameof(LT_IOLINK));
        /// <summary> Виртуальный текущий уровень (без привязки к модулям) </summary>
        public static readonly DeviceSubType LT_VIRT = new(SubTypeIdentifier(DeviceType.LT) + 6, nameof(LT_VIRT));
        #endregion
        #region QT  - Концентрация
        /// <summary> Концентратомер </summary>
        public static readonly DeviceSubType QT = new(SubTypeIdentifier(DeviceType.QT) + 1, nameof(QT));
        /// <summary> Концентратомер c диагностикой </summary>
        public static readonly DeviceSubType QT_OK = new(SubTypeIdentifier(DeviceType.QT) + 2, nameof(QT_OK));
        /// <summary> IO-Link концентратомер </summary>
        public static readonly DeviceSubType QT_IOLINK = new(SubTypeIdentifier(DeviceType.QT) + 3, nameof(QT_IOLINK));
        /// <summary> Виртуальный концентратомер (без привязки к модулям) </summary>
        public static readonly DeviceSubType QT_VIRT = new(SubTypeIdentifier(DeviceType.QT) + 4, nameof(QT_VIRT));
        #endregion
        #region HA  - Звуковая сигнализация
        /// <summary> Сирена </summary>
        public static readonly DeviceSubType HA = new(SubTypeIdentifier(DeviceType.HA) + 1, nameof(HA));
        /// <summary> Виртуальная сирена (без привязки к модулям) </summary>
        public static readonly DeviceSubType HA_VIRT = new(SubTypeIdentifier(DeviceType.HA) + 2, nameof(HA_VIRT));
        #endregion
        #region HL  - Световая сигнализация
        /// <summary> Лампа </summary>
        public static readonly DeviceSubType HL = new(SubTypeIdentifier(DeviceType.HL) + 1, nameof(HL));
        /// <summary> Виртуальная лампа (без привязки к модулям) </summary>
        public static readonly DeviceSubType HL_VIRT = new(SubTypeIdentifier(DeviceType.HL) + 2, nameof(HL_VIRT));
        #endregion
        #region SB  - Кнопка
        /// <summary> Кнопка </summary>
        public static readonly DeviceSubType SB = new(SubTypeIdentifier(DeviceType.SB) + 1, nameof(SB));
        /// <summary> Виртуальная кнопка (без привязки к модулям) </summary>
        public static readonly DeviceSubType SB_VIRT = new(SubTypeIdentifier(DeviceType.SB) + 2, nameof(SB_VIRT));
        #endregion
        #region DI  - Дискретный входной сигнал
        /// <summary> Дискретный вход с привязкой к модулям. </summary>
        public static readonly DeviceSubType DI = new(SubTypeIdentifier(DeviceType.DI) + 1, nameof(DI));
        /// <summary> Виртуальный дискретный вход (без привязки к модулям). </summary>
        public static readonly DeviceSubType DI_VIRT = new(SubTypeIdentifier(DeviceType.DI) + 2, nameof(DI_VIRT));
        #endregion
        #region DO  - Дискретный выходной сигнал
        /// <summary> Дискретный выход с привязкой к модулям </summary>
        public static readonly DeviceSubType DO = new(SubTypeIdentifier(DeviceType.DO) + 1, nameof(DO));
        /// <summary> Виртуальный дискретный выход(без привязки к модулям) </summary>
        public static readonly DeviceSubType DO_VIRT = new(SubTypeIdentifier(DeviceType.DO) + 2, nameof(DO_VIRT));
        #endregion
        #region AI  - Аналоговый входной сигнал
        
        #endregion
        #region AO  - Аналоговый выходной сигнал
        /// <summary> Аналоговый выход с привязкой к модулям ввода-вывода </summary>
        public static readonly DeviceSubType AO = new(SubTypeIdentifier(DeviceType.AO) + 1, nameof(AO));
        /// <summary> Виртуальный аналоговый выход (без привязки к модулям) </summary>
        public static readonly DeviceSubType AO_VIRT = new(SubTypeIdentifier(DeviceType.AO) + 2, nameof(AO_VIRT));
        #endregion
        #region WT  - Датчик веса
        /// <summary> Весы </summary>
        public static readonly DeviceSubType WT = new(SubTypeIdentifier(DeviceType.WT) + 1, nameof(WT));
        /// <summary> Виртуальные весы </summary>
        public static readonly DeviceSubType WT_VIRT = new(SubTypeIdentifier(DeviceType.WT) + 2, nameof(WT_VIRT));
        /// <summary> Весы с интерфейсом RS-232 </summary>
        public static readonly DeviceSubType WT_RS232 = new(SubTypeIdentifier(DeviceType.WT) + 3, nameof(WT_RS232));
        /// <summary> Весы с ethernet </summary>
        public static readonly DeviceSubType WT_ETH = new(SubTypeIdentifier(DeviceType.WT) + 4, nameof(WT_ETH));
        #endregion
        #region PT  - Датчик давления
        /// <summary> Датчик давления </summary>
        public static readonly DeviceSubType PT = new(SubTypeIdentifier(DeviceType.PT) + 1, nameof(PT));
        /// <summary> IO-Link датчик давления </summary>
        public static readonly DeviceSubType PT_IOLINK = new(SubTypeIdentifier(DeviceType.PT) + 2, nameof(PT_IOLINK));
        /// <summary> Виртуальный датчик давления (без привязки к модулям) </summary>
        public static readonly DeviceSubType PT_VIRT = new(SubTypeIdentifier(DeviceType.PT) + 3, nameof(PT_VIRT));
        #endregion
        #region F   - Автоматический выключатель
        /// <summary> IO-Link автоматический выключатель </summary>
        public static readonly DeviceSubType F = new(SubTypeIdentifier(DeviceType.F) + 1, nameof(F));
        /// <summary> Виртуальный автоматический выключатель (без привязки к модулям) </summary>
        public static readonly DeviceSubType F_VIRT = new(SubTypeIdentifier(DeviceType.F) + 2, nameof(F_VIRT));
        #endregion
        #region HLA - Сигнальная колонна
        /// <summary> Сигнальная колонна (красный, желтый, зеленый и сирена) </summary>
        public static readonly DeviceSubType HLA = new(SubTypeIdentifier(DeviceType.HLA) + 1, nameof(HLA));
        /// <summary> Виртуальная сигнальная колонна (без привязки к модулям) </summary>
        public static readonly DeviceSubType HLA_VIRT = new(SubTypeIdentifier(DeviceType.HLA) + 2, nameof(HLA_VIRT));
        /// <summary> Сигнальная колонна IO-Link (настраиваемая) </summary>
        public static readonly DeviceSubType HLA_IOLINK = new(SubTypeIdentifier(DeviceType.HLA) + 3, nameof(HLA_IOLINK));
        #endregion
        #region CAM - Камера
        /// <summary> Камера с готовностью, результатом обработки и сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI2 = new(SubTypeIdentifier(DeviceType.CAM) + 1, nameof(CAM_DO1_DI2));
        /// <summary> Камера с результатом обработки, сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI1 = new(SubTypeIdentifier(DeviceType.CAM) + 2, nameof(CAM_DO1_DI1));
        /// <summary> Камера с готосностью, 2-мя результатами обработки и сигналом активации </summary>
        public static readonly DeviceSubType CAM_DO1_DI3 = new(SubTypeIdentifier(DeviceType.CAM) + 3, nameof(CAM_DO1_DI3));
        #endregion
        #region PDS - Сигнальный датчик перепада давления
        /// <summary> Сигнальный датчик разницы давления </summary>
        public static readonly DeviceSubType PDS = new(SubTypeIdentifier(DeviceType.PDS) + 1, nameof(PDS));
        /// <summary> Виртуальный сигнальный датчик разницы давления </summary>
        public static readonly DeviceSubType PDS_VIRT = new(SubTypeIdentifier(DeviceType.PDS) + 2, nameof(PDS_VIRT));
        #endregion
        #region TS  - Сигнальный датчик температуры
        /// <summary> Сигнальный датчик температуры </summary>
        public static readonly DeviceSubType TS = new(SubTypeIdentifier(DeviceType.TS) + 1, nameof(TS));
        /// <summary> Виртуальный сигнальный датчик температуры </summary>
        public static readonly DeviceSubType TS_VIRT = new(SubTypeIdentifier(DeviceType.TS) + 2, nameof(TS_VIRT));
        #endregion
        #region Y   - Пневмоостров
        /// <summary> Обычный пневмоостров Festo </summary>
        public static readonly DeviceSubType Y1 = new(SubTypeIdentifier(DeviceType.Y) + 1, nameof(Y1));
        /// <summary> Festo 16 каналов </summary>
        public static readonly DeviceSubType DEV_VTUG_8 = new(SubTypeIdentifier(DeviceType.Y) + 2, nameof(DEV_VTUG_8));
        /// <summary> Festo 32 канала </summary>
        public static readonly DeviceSubType DEV_VTUG_16 = new(SubTypeIdentifier(DeviceType.Y) + 3, nameof(DEV_VTUG_16));
        /// <summary> Festo 48 каналов </summary>
        public static readonly DeviceSubType DEV_VTUG_24 = new(SubTypeIdentifier(DeviceType.Y) + 4, nameof(DEV_VTUG_24));
        #endregion
        #endregion

       
        /// <summary>
        /// Индентификатор подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <returns>Номер типа умноженный на коэффициент</returns>
        private static int SubTypeIdentifier(DeviceType type)
        {
            return typeWeight * type.Id;
        }

        /// <summary>
        /// Номер подтипа.
        /// </summary>
        /// <remarks>
        /// Этот номер не зависит от типа устройства.
        /// </remarks>
        public override int Id
        {
            get
            {
                return id % typeWeight;
            }
        }

        /// <summary>
        /// Получить экземпляр подтипа по типу и номеру подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="id">Номер подтипа</param>
        /// <returns>Подтип устройства (NONE если подтип не найден)</returns>
        public static DeviceSubType FromTypeAndID(DeviceType type, int id)
        {
            if (AllItems.Value.TryGetValue(id + SubTypeIdentifier(type), out var matchingItem))
            {
                return matchingItem;
            }
            return NONE;
        }

        /// <summary>
        /// Получить экземпляр подтипа по типу и названию подтипа
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="subtype">Название подтипа</param>
        /// <returns>Подтип устройства (NONE если подтип не найден)</returns>
        public static DeviceSubType FromTypeAndName(DeviceType type, string subtype)
        {
            if (string.IsNullOrEmpty(subtype))
            {
                return FromTypeAndID(type, defaultID);
            }

            if (AllItemsByName.Value.TryGetValue(subtype, out var matchingItem) 
                && CheckSubType(type, matchingItem) == true)
            {
                    return matchingItem;
            }

            return NONE;
        }

        /// <summary>
        /// Проверка принадлежности подтипа к типу
        /// </summary>
        /// <param name="type">Тип устройства</param>
        /// <param name="subType">Подтип устройства</param>
        /// <returns>true when subtype in type</returns>
        private static bool CheckSubType(DeviceType type, DeviceSubType subType)
        {
            return subType.Id == subType.id - SubTypeIdentifier(type);
        }

        /// <summary>
        /// Описание устройства с пустыми значениями
        /// </summary>
        public DeviceDescription Description => description.Clone();

        /// <summary>
        /// Инициализация параметров для шаблона описания
        /// </summary>
        private List<Parameter> Parameters
        {
            init => description.Parameters = new DeviceParameters(value);
        }

        /// <summary>
        /// Инициализация свойств для шаблона описания
        /// </summary>
        private List<Property> Properties
        {
            init => description.Properties = new DeviceProperties(value);
        }

        /// <summary>
        /// Инициализация каналов ввода-вывода для шаблона описания
        /// </summary>
        private List<IOChannel> Channels
        {
            init => description.Channels = value;
        }

        /// <summary>
        /// Инициализация тегов для шаблона описания
        /// </summary>
        private Dictionary<string, int> DeviceTags
        {
            init => description.DeviceTags = value.ToImmutableDictionary();
        }

        /// <summary>
        /// Конструктор подтипа
        /// </summary>
        /// <param name="id">Номер подтипа</param>
        /// <param name="name">Название подтипа</param>
        /// <param name="description">Конструктор для создания описания устройства</param>
        protected DeviceSubType(int id, string name)
           : base(id, name)
        {
            
        }

        /// <summary>
        /// Шаблон описания устройства (параметры, свойства)
        /// </summary>
        private DeviceDescription description = new();

        /// <summary>
        /// Коэффициент типа ( IDподтипа = №подтипа + IDтипа * коефициент типа )
        /// </summary>
        private const int typeWeight = 1000;

        /// <summary>
        /// Стандартный номер подтипа (если строка подтипа не заполнена)
        /// </summary>
        private const int defaultID = 1;
    }
}