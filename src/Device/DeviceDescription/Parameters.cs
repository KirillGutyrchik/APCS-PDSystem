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
        public static readonly Parameter NONE = new Parameter(nameof(NONE));

        /// <summary> Номинальная нагрузка в кг. </summary>
        public static readonly Parameter P_NOMINAL_W = new Parameter(nameof(P_NOMINAL_W));

        /// <summary> Рабочий коэффициент передачи </summary>
        public static readonly Parameter P_RKP = new Parameter(nameof(P_RKP));

        /// <summary> Сдвиг нуля. </summary>
        public static readonly Parameter P_C0 = new Parameter(nameof(P_C0));

        /// <summary> Время порогового фильтра. </summary>
        public static readonly Parameter P_DT = new Parameter(nameof(P_DT));

        /// <summary> Время включения. </summary>
        public static readonly Parameter P_ON_TIME = new Parameter(nameof(P_ON_TIME));

        /// <summary> Обратная связь, 1/0 (Да/Нет) </summary>
        public static readonly Parameter P_FB = new Parameter(nameof(P_FB));

        /// <summary> Аварийное значение. </summary>
        public static readonly Parameter P_ERR = new Parameter(nameof(P_ERR));

        /// <summary> Минимальное значение. </summary>
        public static readonly Parameter P_MIN_V = new Parameter(nameof(P_MIN_V));

        /// <summary> Максимальное значение. </summary>
        public static readonly Parameter P_MAX_V = new Parameter(nameof(P_MAX_V));

        /// <summary> Давление, на которое настроен датчик. </summary>
        public static readonly Parameter P_MAX_P = new Parameter(nameof(P_MAX_P));

        /// <summary> Радиус танка. </summary>
        public static readonly Parameter P_R = new Parameter(nameof(P_R));

        /// <summary> Высота конической части танка. </summary>
        public static readonly Parameter P_H_CONE = new Parameter(nameof(P_H_CONE));

        /// <summary> Высота усеченной части танка. </summary>
        public static readonly Parameter P_H_TRUNC = new Parameter(nameof(P_H_TRUNC));

        /// <summary> Минимальное значение для потока. </summary>
        public static readonly Parameter P_MIN_F = new Parameter(nameof(P_MIN_F));

        /// <summary> Максимальное значение для потока. </summary>
        public static readonly Parameter P_MAX_F = new Parameter(nameof(P_MAX_F));

        /// <summary> Параметр k. </summary>
        public static readonly Parameter P_k = new Parameter(nameof(P_k));

        /// <summary> Параметр Ti. </summary>
        public static readonly Parameter P_Ti = new Parameter(nameof(P_Ti));

        /// <summary> Параметр Td. </summary>
        public static readonly Parameter P_Td = new Parameter(nameof(P_Td));

        /// <summary> Интервал расчёта. </summary>
        public static readonly Parameter P_dt = new Parameter(nameof(P_dt));

        /// <summary> Максимальное значение входной величины. </summary>
        public static readonly Parameter P_max = new Parameter(nameof(P_max));

        /// <summary> Минимальное значение входной величины. </summary>
        public static readonly Parameter P_min = new Parameter(nameof(P_min));

        /// <summary> Время выхода на режим регулирования. </summary>
        public static readonly Parameter P_acceleration_time = new Parameter(nameof(P_acceleration_time));

        /// <summary> Ручной режим, 0 - авто, 1 - ручной. </summary>
        public static readonly Parameter P_is_manual_mode = new Parameter(nameof(P_is_manual_mode));

        /// <summary> Заданное ручное значение выходного сигнала. </summary>
        public static readonly Parameter P_U_manual = new Parameter(nameof(P_U_manual));

        /// <summary> Параметр k2. </summary>
        public static readonly Parameter P_k2 = new Parameter(nameof(P_k2));

        /// <summary> Параметр Ti2. </summary>
        public static readonly Parameter P_Ti2 = new Parameter(nameof(P_Ti2));

        /// <summary> Параметр Td2. </summary>
        public static readonly Parameter P_Td2 = new Parameter(nameof(P_Td2));

        /// <summary> Максимальное значение выходной величины. </summary>
        public static readonly Parameter P_out_max = new Parameter(nameof(P_out_max));

        /// <summary> Минимальное значение выходной величины. </summary>
        public static readonly Parameter P_out_min = new Parameter(nameof(P_out_min));

        /// <summary> Обратного (реверсивного) действия, 0 - false, 1 - true. </summary>
        public static readonly Parameter P_is_reverse = new Parameter(nameof(P_is_reverse));

        /// <summary> Нулевое стартовое значение, 0 - false, 1 - true. </summary>
        public static readonly Parameter P_is_zero_start = new Parameter(nameof(P_is_zero_start));

        /// <summary> Диаметр вала, м. </summary>
        public static readonly Parameter P_SHAFT_DIAMETER = new Parameter(nameof(P_SHAFT_DIAMETER));

        /// <summary> Передаточное число </summary>
        public static readonly Parameter P_TRANSFER_RATIO = new Parameter(nameof(P_TRANSFER_RATIO));

        /// <summary> Предельное время отсутствия готовности к работе, секунд. </summary>
        public static readonly Parameter P_READY_TIME = new Parameter(nameof(P_READY_TIME));

        /// <summary> Параметр для обработки ошибки счета импульсов. </summary>
        public static readonly Parameter P_ERR_MIN_FLOW = new Parameter(nameof(P_ERR_MIN_FLOW), "Ошибка счета импульсов");


        protected static readonly Lazy<Dictionary<string, Parameter>> AllParameters;

        static Parameter()
        {
            AllParameters = new Lazy<Dictionary<string, Parameter>>(() =>
            {
                var parameters = typeof(Parameter)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(x => x.FieldType == typeof(Parameter))
                    .Select(x => x.GetValue(null))
                    .Cast<Parameter>()
                    .ToDictionary(x => x.name, x => x);
                return parameters;
            });
        }

        /// <summary>
        /// Конструктор параметра
        /// </summary>
        /// <param name="name">Название параметра (CAD-name)</param>
        /// <param name="description">Описание параметра</param>
        /// <param name="format">Формат string.Format() (единицы измерения) </param>
        public Parameter(string name, string description = "", string format = "{0}")
        {
            this.name = name;
            this.description = description;
            this.format = format;
        }

        /// <summary>
        /// Неявное преобразование названия в параметр по его названию
        /// Если парметр не найден, возвращатся новый параметр с неверным названиемю
        /// </summary>
        /// <param name="parameterName">Название параметра</param>
        public static implicit operator Parameter(string parameterName)
        {
            return AllParameters.Value.GetValueOrDefault(parameterName, new Parameter(parameterName));
        }

        /// <summary>
        /// Неявное преобразование параметра в строку с названием
        /// </summary>
        /// <param name="parameterType">Параметр</param>
        public static implicit operator string(Parameter parameterType)
        {
            return parameterType.name;
        }

        public string Name { get => name; }
        public string Description { get => description; }
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
    public class DeviceParameters
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
                    return parameters[parameter];
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

        /// <summary>
        /// Получение и установка параметра по индексу
        /// </summary>
        /// <param name="parameterId"></param>
        /// <returns></returns>
        public object? this[int parameterId]
        {
            get => this[parameters.Keys.ElementAtOrDefault(parameterId) ?? Parameter.NONE];
            set => this[parameters.Keys.ElementAtOrDefault(parameterId) ?? Parameter.NONE] = value;
        }

        public DeviceParameters()
        {

        }

        /// <summary>
        /// Инициализация параметров по списку параметров, значения = null 
        /// </summary>
        /// <param name="parametersList">Список параметров для инициализации</param>
        public DeviceParameters(List<Parameter> parametersList)
        {
            parameters = parametersList.ToDictionary<Parameter, Parameter, object?>(par => par, par => null);
        }

        private Dictionary<Parameter, object?> parameters = new();
    }
}
