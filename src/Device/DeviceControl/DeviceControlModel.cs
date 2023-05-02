using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceControlModel
    {
        private DeviceControlModel()
        {

        }
        private static DeviceControlModel? _instance = null;
        public static DeviceControlModel Instance
        {
            get => _instance ??= new DeviceControlModel();
        }


        private DeviceManager _deviceManager;
    }
}
