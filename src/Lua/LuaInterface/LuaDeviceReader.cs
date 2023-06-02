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

            LuaManager.Instance.Lua[LuaDeviceManagerName] = DeviceManager.Instance;
        }

        /// <summary>
        /// Инициализировать устройства
        /// </summary>
        public void InitDevices()
        {
            LuaFunction? DevicesInit = LuaManager.Instance.Lua[LuaMainFunctionName] as LuaFunction;
            DevicesInit?.Call();
        }

    }
}
