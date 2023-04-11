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
        public const string Empty = "{0}";
        public const string Boolean = "{0:Да;-;Нет}";
        public const string Seconds = "{0} c";
        public const string Milliseconds = "{0} мс";
        public const string Meters = "{0} м";
        public const string Kilograms = "{0} кг";
        public const string Bars = "{0} бар";
        public const string RKP = "{0} мВ/В";
        public const string Percentages = "{0} %";
        public const string DegreesCelsius = "{0} °C";
        public const string CubicMeterPerHour = "{0} м3/ч";
    }
}
