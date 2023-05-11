using LuaInterface;
using System.Reflection;
using PDSystem.Device;
using System.Text.Unicode;
using KopiLua;

namespace PDSystem.LUA
{
    public class LuaDeviceReader
    {
        private static readonly string DeviceReaderLuaFileName = "Lua\\device_reader.lua";

        public LuaDeviceReader()
        {

            //LuaManager.Instance.Lua.DoFile("C:\\Users\\gutyr\\Desktop\\ptusa_test_prj\\main.io.lua");
            LuaManager.Instance.Lua.DoString(System.IO.File.ReadAllText("C:\\Users\\gutyr\\Desktop\\ptusa_test_prj\\main.io.lua", Encoding.UTF8));

            LuaManager.Instance.Lua.DoFile(Path.Combine(Path.GetDirectoryName(Assembly
                .GetExecutingAssembly().Location) ?? "", DeviceReaderLuaFileName));

            LuaManager.Instance.Lua["DeviceManager"] = new LuaDeviceManager();
        }

        public void InitDevices()
        {
            LuaFunction? init_devices = LuaManager.Instance.Lua["DevicesInit"] as LuaFunction;
            init_devices?.Call();
        }

        
        public class LuaDeviceManager
        {
            public LuaDevice? AddDevice(string name, int type, int subType, string description, string article)
            {
                var device = DeviceManager.Instance.AddDevice(name, type, subType);
                if (device == null) return null;

                device.Description = description;
                device.ArticleName = article;

                return new LuaDevice(device);
            }


            public class LuaDevice
            {
                private Device.Device tagDevice;

                public LuaDevice(Device.Device device)
                {
                    tagDevice = device;
                }

                public void SetParameters(LuaTable? parameters)
                {
                    if (parameters is null) return;

                    int parameterIndex = 0;
                    foreach (var parameter in parameters.Values)
                    {
                        tagDevice.Parameters[parameterIndex++] = parameter;
                    }
                }

                public void SetChannel(string channelType, int index,
                    int node, int offset, int physical_port,
                    int logical_port, int module_offset)
                {
                    tagDevice.Channels.Where(channel => channel.Name == channelType).ToArray()
                        [index].SetChannel(node, offset, physical_port, logical_port, module_offset);
                }
            }
        }

    }
}
