namespace PDSystem.Device
{
    /// <summary>
    /// Параметр времени выполнения устройства.
    /// </summary>
    public class RuntimeParameter
    {
        /// <summary>
        /// Номер клапана на пневмоострове
        /// </summary>
        public static readonly RuntimeParameter R_VTUG_NUMBER = new(nameof(R_VTUG_NUMBER));

        /// <summary>
        /// Размер области клапана для пневмоострова
        /// </summary>
        public static readonly RuntimeParameter R_VTUG_SIZE = new(nameof(R_VTUG_SIZE));

        /// <summary>
        /// Номер клапана в AS-i.
        /// </summary>
        public static readonly RuntimeParameter R_AS_NUMBER = new(nameof(R_AS_NUMBER));

        /// <summary>
        /// Тип красного сигнала устройства при подаче на него сигнала DO. 
        /// (Постоянный или мигающий). 0 - мигающий, 1 - постоянный.
        /// </summary>
        public static readonly RuntimeParameter R_CONST_RED = new(nameof(R_CONST_RED));

        /// <summary>
        /// Номер клеммы пневмоострова для сигнала "Открыть"
        /// </summary>
        public static readonly RuntimeParameter R_ID_ON = new(nameof(R_ID_ON));

        /// <summary>
        /// Номер клеммы пневмоострова для сигнала "Открыть верхнее седло"
        /// </summary>
        public static readonly RuntimeParameter R_ID_UPPER_SEAT = new(nameof(R_ID_UPPER_SEAT));

        /// <summary>
        /// Номер клеммы пневмоострова для сигнала "Открыть нижнее седло"
        /// </summary>
        public static readonly RuntimeParameter R_ID_LOWER_SEAT = new(nameof(R_ID_LOWER_SEAT));

        private RuntimeParameter(string name) 
        {
            this.name = name;
        }

        public string Name => name;

        private string name;
    }

    public class DeviceRuntimeParameters
    {

        /// <summary>
        /// val = get[key] - получить значение парметра, если он существует.
        /// set[key] = val - установить значение параметра, если он сущуствует.
        /// </summary>
        /// <param name="parameter">Параметр</param>
        /// <exception cref="ArgumentException">Параметр не найден</exception>
        public object? this[RuntimeParameter rtparameter]
        {
            get
            {
                try
                {
                    return runtimeParameters[rtparameter];
                }
                catch (Exception)
                {
                    throw new ArgumentException($"\"{rtparameter.Name}\" - параметр не найдено");
                }
            }
            set
            {
                if (runtimeParameters.ContainsKey(rtparameter))
                {
                    runtimeParameters[rtparameter] = value;
                }
                else
                {
                    throw new ArgumentException($"\"{rtparameter.Name}\" - параметр не найден");
                }
            }
        }

        /// <summary>
        /// Получить список параметров
        /// </summary>
        public List<RuntimeParameter> ToList()
        {
            return runtimeParameters.Select(rtpar => rtpar.Key).ToList();
        }


        public DeviceRuntimeParameters()
        {

        }

        /// <summary>
        /// Конструктор для инициализации свойств из списка свойств
        /// </summary>
        /// <param name="parametersList">Список свойств</param>
        public DeviceRuntimeParameters(List<RuntimeParameter> rtparametersList)
        {
            runtimeParameters = rtparametersList.ToDictionary<RuntimeParameter, RuntimeParameter, object?>(par => par, par => null);
        }

        public delegate void PropertyChanged();

        private Dictionary<RuntimeParameter, object?> runtimeParameters = new();
    }
}
