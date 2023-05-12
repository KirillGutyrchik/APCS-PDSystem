using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DevicesTreeModel
    {
        public DevicesTreeModel() 
        {
        
        }

        public void AddDevice(Device device)
        {
            var typeContainer = deviceTree.FirstOrDefault(typeContainer => typeContainer.DeviceType == device.DeviceType);
            if (typeContainer is null)
            {
                typeContainer = new(device.DeviceType);
                deviceTree.Add(typeContainer);
            }
            
            typeContainer.AddDevice(device);
        }

        public List<IDeviceTreeListItem> DeviceTree => deviceTree.Cast<IDeviceTreeListItem>().ToList(); 

        private List<DeviceTypeItem> deviceTree = new();
    }
}
