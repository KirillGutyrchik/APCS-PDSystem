using LuaInterface;
using System.Reflection;
using PDSystem.Device;
using System.Text.Unicode;
using KopiLua;

namespace PDSystem.LUA
{
    public class LuaDeviceReader
    {
        /// <summary>
        /// Название файла с LUA-кодом для инициализации устройств
        /// </summary>
        private static readonly string DeviceReaderLuaFileName = "device_reader.lua";

        /// <summary>
        /// Функция инициализации устройств 
        /// </summary>
        private static readonly string LuaMainFunctionName = "DevicesInit";

        /// <summary>
        /// Имя объекта LuaDeviceManager в Lua
        /// </summary>
        private static readonly string LuaDeviceManagerName = "DeviceManager";

        /// <summary>
        /// Чтение устройств из файла main.io.lua
        /// </summary>
        /// <param name="path">Путь к файлу main.io.lua</param>
        public LuaDeviceReader(string mainIoData)
        {
            LuaManager.Instance.Lua.DoString(mainIoData);

            LuaManager.Instance.Lua.DoFile(Path.Combine(LuaManager.LuaDirectory, DeviceReaderLuaFileName));

            LuaManager.Instance.Lua[LuaDeviceManagerName] = LuaDeviceManager.Instance;
        }

        /// <summary>
        /// Инициализировать устройства
        /// </summary>
        public void InitDevices()
        {
            LuaFunction? init_devices = LuaManager.Instance.Lua[LuaMainFunctionName] as LuaFunction;
            init_devices?.Call();
        }

        /// <summary>
        /// Промежуточный класс для Lua: менеджер устройств
        /// </summary>
        public class LuaDeviceManager
        {
            private static LuaDeviceManager? instance = null;
            private LuaDeviceManager() { }

            public static LuaDeviceManager Instance => instance ??= new();

            /// <summary>
            /// Добавить устройство
            /// </summary>
            /// <param name="name"> Название устройства </param>
            /// <param name="type"> Номер типа </param>
            /// <param name="subType"> Номер подтипа </param>
            /// <param name="description"> Описание </param>
            /// <param name="article"> Изделие </param>
            /// <returns> Добавленное устройство </returns>
            public LuaDevice? AddDevice(string name, int type, int subType, string description, string article)
            {
                var device = DeviceManager.Instance.AddDevice(name, type, subType);
                if (device == null) return null;

                device.Description = description;
                device.ArticleName = article;

                return new LuaDevice(device);
            }

            /// <summary>
            /// Промежуточный класс для Lua: устройство
            /// </summary>
            public class LuaDevice
            {
                private Device.Device tagDevice;

                /// <summary>
                /// Создание промежуточного объекта LuaDevice на основе Device
                /// </summary>
                /// <param name="device"> Device: Устройство проекта </param>
                public LuaDevice(Device.Device device)
                {
                    tagDevice = device;
                }

                /// <summary>
                /// Установить параметры для устройства
                /// </summary>
                /// <param name="parameters">Lua-тиблица со списком значений параметров: par = {1, 5000},</param>
                public void SetParameters(LuaTable parameters)
                {
                    int parameterIndex = 0;
                    foreach (var parameter in parameters.Values)
                    {
                        tagDevice.Parameters[parameterIndex++] = parameter;
                    }
                }

                /// <summary>
                /// Установить канал
                /// </summary>
                /// <param name="channelType"> Тип канала </param>
                /// <param name="index"> Порядковый номер </param>
                /// <param name="node"> Узел </param>
                /// <param name="offset"> Смещение </param>
                /// <param name="physical_port"> Физический порт </param>
                /// <param name="logical_port"> Логический порт </param>
                /// <param name="module_offset"> Смещение модуля </param>
                public void SetChannel(string channelType, int index,
                    int node, int offset, int physical_port,
                    int logical_port, int module_offset)
                {
                    tagDevice.Channels.AllChannels.Where(channel => channel.Name == channelType).ToArray()
                        [index].SetChannel(node, offset, physical_port, logical_port, module_offset);
                }

                /// <summary>
                /// Установить свойство
                /// </summary>
                /// <param name="name">Имя свойства</param>
                /// <param name="value">Значение свойства</param>
                public void SetProperty(string name, string value)
                {
                    tagDevice.Properties[name] = value;
                }
            }
        }

    }
}
