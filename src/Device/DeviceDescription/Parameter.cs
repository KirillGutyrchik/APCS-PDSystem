using System.Collections;
using System.Collections.Immutable;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PDSystem.Device
{
    /// <summary>
    /// Описание параметров устройства.
    /// </summary>
    public record class Parameter
    {
        /// <summary> Пустой параметр </summary>
        public static readonly Parameter NONE = new("NONE", string.Empty, string.Empty);

        /// <summary> Номинальная нагрузка в кг. </summary>
        public static readonly Parameter P_NOMINAL_W = new("P_NOMINAL_W", "Номинальная нагрузка", UnitFormat.Kilograms);

        /// <summary> Рабочий коэффициент передачи </summary>
        public static readonly Parameter P_RKP = new("P_RKP", "Рабочий коэффициент передачи", UnitFormat.RKP);

        /// <summary> Сдвиг нуля. </summary>
        public static readonly Parameter P_C0 = new("P_C0", "Сдивг нуля");

        /// <summary> Время порогового фильтра. </summary>
        public static readonly Parameter P_DT = new("P_DT", "Время порогового фильтра", UnitFormat.Milliseconds);

        /// <summary> Время включения. </summary>
        public static readonly Parameter P_ON_TIME = new("P_ON_TIME", "Время включения", UnitFormat.Milliseconds);

        /// <summary> Обратная связь, 1/0 (Да/Нет) </summary>
        public static readonly Parameter P_FB = new("P_FB", "Обратная связь", UnitFormat.Boolean);

        /// <summary> Аварийное значение. </summary>
        public static readonly Parameter P_ERR = new("P_ERR", "Аварийное значение");

        /// <summary> Минимальное значение. </summary>
        public static readonly Parameter P_MIN_V = new("P_MIN_V", "Мин. значение");

        /// <summary> Максимальное значение. </summary>
        public static readonly Parameter P_MAX_V = new("P_MAX_V", "Мак. значение");

        /// <summary> Давление, на которое настроен датчик. </summary>
        public static readonly Parameter P_MAX_P = new("P_MAX_P", "Давление датчика", UnitFormat.Bars);

        /// <summary> Радиус танка. </summary>
        public static readonly Parameter P_R = new("P_R", "Радиус танка", UnitFormat.Meters);

        /// <summary> Высота конической части танка. </summary>
        public static readonly Parameter P_H_CONE = new("P_H_CONE", "Высота конической части танка", UnitFormat.Meters);

        /// <summary> Высота усеченной части танка. </summary>
        public static readonly Parameter P_H_TRUNC = new("P_H_TRUNC", "Высота усеченной части танка", UnitFormat.Meters);

        /// <summary> Минимальное значение для потока. </summary>
        public static readonly Parameter P_MIN_F = new("P_MIN_F", "Мин. значение для потока");

        /// <summary> Максимальное значение для потока. </summary>
        public static readonly Parameter P_MAX_F = new("P_MAX_F", "Макс. значение для потока");

        /// <summary> Коэффициент усиления. </summary>
        public static readonly Parameter P_k = new("P_k", "Коэффициент усиления");

        /// <summary> Время интегрирования. </summary>
        public static readonly Parameter P_Ti = new("P_Ti", "Время интегрирования");

        /// <summary> Время дифференцирования. </summary>
        public static readonly Parameter P_Td = new("P_Td", "Время дифференцирования");

        /// <summary> Интервал расчёта. </summary>
        public static readonly Parameter P_dt = new("P_dt", "Интервал расчета", UnitFormat.Milliseconds);

        /// <summary> Максимальное значение входной величины. </summary>
        public static readonly Parameter P_max = new("P_max", "Макс. входное значение");

        /// <summary> Минимальное значение входной величины. </summary>
        public static readonly Parameter P_min = new("P_min", "Мин. входное значение");

        /// <summary> Время выхода на режим регулирования. </summary>
        public static readonly Parameter P_acceleration_time = new("P_acceleration_time", "Время выхода", UnitFormat.Seconds);

        /// <summary> Ручной режим, 0 - авто, 1 - ручной. </summary>
        public static readonly Parameter P_is_manual_mode = new("P_is_manual_mode", "Ручной режим", UnitFormat.Boolean);

        /// <summary> Заданное ручное значение выходного сигнала. </summary>
        public static readonly Parameter P_U_manual = new("P_U_manual", "Заданное ручное значение", UnitFormat.Percentages);

        /// <summary> Коэффициент усиления 2. </summary>
        public static readonly Parameter P_k2 = new("P_k2", "Коэффициент усиления 2");

        /// <summary> Время интегрирования 2. </summary>
        public static readonly Parameter P_Ti2 = new("P_Ti2", "Время интегрирования 2");

        /// <summary> Время дифференцирования 2 </summary>
        public static readonly Parameter P_Td2 = new("P_Td2", "Время дифференцирования 2");

        /// <summary> Максимальное значение выходной величины. </summary>
        public static readonly Parameter P_out_max = new("P_out_max", "Макс. выходное значение");

        /// <summary> Минимальное значение выходной величины. </summary>
        public static readonly Parameter P_out_min = new("P_out_min", "Мин. выходное значение");

        /// <summary> Обратного (реверсивного) действия, 0 - false, 1 - true. </summary>
        public static readonly Parameter P_is_reverse = new("P_is_reverse", "Выход обратного действия 100-0", UnitFormat.Boolean);

        /// <summary> Нулевое стартовое значение, 0 - false, 1 - true. </summary>
        public static readonly Parameter P_is_zero_start = new("P_is_zero_start", "Выход прямого действия 0-100", UnitFormat.Boolean);

        /// <summary> Диаметр вала, м. </summary>
        public static readonly Parameter P_SHAFT_DIAMETER = new("P_SHAFT_DIAMETER", "Диаметр вала", UnitFormat.Meters);

        /// <summary> Передаточное число </summary>
        public static readonly Parameter P_TRANSFER_RATIO = new("P_TRANSFER_RATIO", "Передаточное число");

        /// <summary> Предельное время отсутствия готовности к работе, секунд. </summary>
        public static readonly Parameter P_READY_TIME = new("P_READY_TIME", "Предельное время отсутсвя готовности к работе", UnitFormat.Seconds);

        /// <summary> Параметр для обработки ошибки счета импульсов. </summary>
        public static readonly Parameter P_ERR_MIN_FLOW = new("P_ERR_MIN_FLOW", "Ошибка счета импульсов");


        /// <summary>
        /// Словарь пораметров по названию 
        /// </summary>
        protected static readonly Lazy<Dictionary<string, Parameter>> AllParameters = InitParameters();

        /// <summary>
        /// Инициализация словаря параметров
        /// </summary>
        private static Lazy<Dictionary<string, Parameter>> InitParameters()
        {
            return new Lazy<Dictionary<string, Parameter>>(() =>
            {
                return typeof(Parameter)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(x => x.FieldType == typeof(Parameter))
                    .Select(x => x.GetValue(null))
                    .Cast<Parameter>()
                    .ToDictionary(x => x.name, x => x);
            });
        }

        /// <summary>
        /// Конструктор параметра
        /// </summary>
        /// <param name="name">Название параметра (Lua)</param>
        /// <param name="description">Описание параметра</param>
        /// <param name="format">Формат string.Format() (единицы измерения) </param>
        private Parameter(string name, string description, string format = UnitFormat.Empty)
        {
            this.name = name;
            this.description = description;
            this.format = format;
        }

        /// <summary>
        /// Неявное преобразование названия в параметр.
        /// Если парметр не найден, возвращатся параметр NONE.
        /// </summary>
        /// <param name="parameterName">Название параметра</param>
        public static implicit operator Parameter(string parameterName)
            => AllParameters.Value.GetValueOrDefault(parameterName, NONE);

        /// <summary>
        /// Неявное преобразование параметра в строку с названием
        /// </summary>
        /// <param name="parameterType">Параметр</param>
        public static implicit operator string(Parameter parameterType)
            => parameterType.name;

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Получение значения параметра в формате
        /// </summary>
        /// <param name="parameter">Параметр</param>
        /// <param name="value">Значение параметра</param>
        /// <returns>Форматированная строка значения параметра</returns>
        public static string GetFormatValue(Parameter parameter, object value)
        {
            if (parameter.description == string.Empty && parameter.format == string.Empty) return value.ToString() ?? string.Empty;

            return string.Format(parameter.format, double.Parse(value.ToString() ?? string.Empty));
        }

        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name { get => name; }

        /// <summary>
        /// Описакние параметра
        /// </summary>
        public string Description { get => description; }

        /// <summary>
        /// Формат единиц измерения
        /// </summary>
        public string Format { get => format; }

        private readonly string name;
        private readonly string description;
        private readonly string format;
    }



    /// <summary>
    /// Параметры устройства
    /// </summary>
    /// <remarks>
    /// Словарь параметр - значение.
    /// Получить параметр: value this[parameter].
    /// Установить параметр: this[parameter] = value.
    /// Добавление новых параметров доступно только при инициализации.
    /// </remarks> 
    public class DeviceParameters : ICloneable
    {
        /// <summary>
        /// val = get[key] - получить значение параметра, если он существует.
        /// set[key] = val - установить значение параметра, если он сущуствует.
        /// </summary>
        /// <param name="parameter">Параметр</param>
        /// <exception cref="ArgumentException">Параметр не найден</exception>
        public object? this[Parameter parameter]
        {
            get
            {
                try
                {
                    return parameters?[parameter];
                }
                catch (Exception)
                {
                    throw new ArgumentException($"\"{parameter.Name}\" - параметр не найден");
                }
            }
            set
            {
                if (parameters.ContainsKey(parameter))
                {
                    parameters[parameter] = value;
                }
                else
                {
                    throw new ArgumentException($"\"{parameter.Name}\" - параметр не найден");
                }
            }
        }

        public object Clone()
        {
            return new DeviceParameters(this.parameters);
        }

        /// <summary>
        /// Конструктор для клонирования параметров
        /// </summary>
        /// <param name="parameters">Словарь параметров для копирования</param>
        private DeviceParameters(Dictionary<Parameter, object?> parameters)
        {
            this.parameters = new(parameters);
        }

        /// <summary>
        /// Конструктор для инициализации параметров устройства из списка параметров
        /// </summary>
        /// <param name="parametersList"></param>
        private DeviceParameters(List<Parameter> parametersList)
        {
            this.parameters = parametersList.ToDictionary<Parameter, Parameter, object?>(par => par, par => null);
        }

        /// <summary>
        /// Инициализация параметров устройства из списка параметров.
        /// </summary>
        /// <param name="parameterList"></param>
        public static implicit operator DeviceParameters(List<Parameter> parameterList)
        {
            return new DeviceParameters(parameterList);
        }

        private readonly Dictionary<Parameter, object?> parameters;
    }
}
