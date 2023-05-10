using LuaInterface;
using System.Reflection;
using PDSystem.Device;

namespace PDSystem.LUA
{
    public class LuaDeviceReader
    {
        private static readonly string DeviceReaderLuaFileName = "Lua\\device_reader.lua";

        public LuaDeviceReader()
        {
                    
            LuaManager.Instance.Lua.DoFile("C:\\Users\\gutyr\\Desktop\\ptusa_test_prj\\main.io.lua");

            LuaManager.Instance.Lua.DoFile(Path.Combine(Path.GetDirectoryName(Assembly
                .GetExecutingAssembly().Location) ?? "", DeviceReaderLuaFileName));

            LuaManager.Instance.Lua["DeviceManager"] = DeviceManager.Instance;
        }

        public void InitDevices()
        {
            LuaFunction? init_devices = LuaManager.Instance.Lua["DevicesInit"] as LuaFunction;
            init_devices?.Call();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Стили именования")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
        public class device_manager
        {
            public device? add_device(string name, int subType, string description, string article)
            {
                var device = DeviceManager.Instance.AddDevice(name, subType);
                if (device == null) return null;
                
                device.Description = description;
                device.ArticleName = article;

                return new device(device);
            }


            public class device
            {
                Device.Device tagDevice;

                public device(Device.Device device)
                {
                    tagDevice = device;
                }

                public void set_parameter(int parameter_id, object? value)
                {

                }
            }
        }

    }
}
