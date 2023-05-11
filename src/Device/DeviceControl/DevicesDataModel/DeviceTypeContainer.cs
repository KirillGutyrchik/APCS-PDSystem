using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceTypeContainer : IDeviceTreeListItem
    {
        #region Реализация IDeviceTreeListItem
        public (string FirstColumn, string SecondColumn) DisplayText => ($"{deviceType.Name} ({items.Count})", string.Empty);

        public string EditText => string.Empty;

        public bool IsEditable => false;

        List<IDeviceTreeListItem> IDeviceTreeListItem.Items => items.Cast<IDeviceTreeListItem>().ToList();

        IDeviceTreeListItem? IDeviceTreeListItem.Parent => null;
        #endregion

        public DeviceTypeContainer(DeviceType deviceType)
        {
            this.deviceType = deviceType;
        }

        public void AddDevice(Device device)
        {
            string objectName = device.ObjectName + device.ObjectNumber;

            var objectContainer = items.FirstOrDefault(objectContainer => objectContainer.Name == objectName);
            if (objectContainer is null)
            {
                objectContainer = new(objectName, this);
                items.Add(objectContainer);
            }

            objectContainer.AddDevice(device);  
        }

        public DeviceType DeviceType => deviceType; 

        private readonly DeviceType deviceType;
        private List<DeviceObjectContainer> items = new();
    }
}
