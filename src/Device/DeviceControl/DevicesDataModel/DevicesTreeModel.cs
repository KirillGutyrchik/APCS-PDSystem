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
            var typeContainer = roots.FirstOrDefault(typeContainer => typeContainer.DeviceType == device.DeviceType);
            if (typeContainer is null)
            {
                typeContainer = new(device.DeviceType);
                roots.Add(typeContainer);
            }
            
            typeContainer.AddDevice(device);
        }

        public void AddRangeDevices(List<Device> devices)
        {
            foreach (var device in devices) 
            {
                AddDevice(device);
            }
        }

        public List<IDeviceTreeListItem> Roots => roots.Cast<IDeviceTreeListItem>().ToList(); 

        private List<DeviceTypeItem> roots = new();
    }
}
