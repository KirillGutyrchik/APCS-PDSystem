using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    /// <summary>
    /// Форматы единиц измерения для параметров
    /// </summary>
    public static class UnitFormat
    {
        ///<summary> Без единицы измерения </summary>
        public const string Empty = "{0}";
        ///<summary> Булевый(Да/Нет) </summary>
        public const string Boolean = "{0:Да;-;Нет}";
        ///<summary> Секунды </summary>
        public const string Seconds = "{0} c";
        ///<summary> Миллисекунды </summary>
        public const string Milliseconds = "{0} мс";
        ///<summary> Метры </summary>
        public const string Meters = "{0} м";
        ///<summary> Киллограммы </summary>
        public const string Kilograms = "{0} кг";
        ///<summary> Бары </summary>
        public const string Bars = "{0} бар";
        ///<summary> Рабочий коэффициент передачи (миливльт/вольт) </summary>
        public const string RKP = "{0} мВ/В";
        ///<summary> Проценты </summary>
        public const string Percentages = "{0} %";
        ///<summary> Градусы цельсия </summary>
        public const string DegreesCelsius = "{0} °C";
        ///<summary> Метры кубические в час </summary>
        public const string CubicMeterPerHour = "{0} м3/ч";
    }
}
