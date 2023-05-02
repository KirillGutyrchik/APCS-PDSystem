using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public class DeviceManager
    {
        private DeviceManager() 
        { }

        private static DeviceManager? instance = null;
        public static DeviceManager Instance
        {
            get => instance ??= new DeviceManager();
        }

        private List<Device> devices = new();
    }
}
