using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceObjectContainer : IDeviceTreeListItem
    {
        #region реализация IDeviceTreeListItem
        public (string FirstColumn, string SecondColumn) DisplayText => ($"{name} ({items.Count})", string.Empty);

        public string EditText => string.Empty;

        public bool IsEditable => false;

        List<IDeviceTreeListItem> IDeviceTreeListItem.Items => items.Cast<IDeviceTreeListItem>().ToList();

        IDeviceTreeListItem? IDeviceTreeListItem.Parent => parent;
        #endregion


        public DeviceObjectContainer(string name, DeviceTypeContainer parent)
        {
            this.parent = parent;
            this.name = name;
        }

        public void AddDevice(Device device)
        {
            items.Add(new DeviceItem(device, this));
        }

        public string Name => name;

        private DeviceTypeContainer parent;
        private List<DeviceItem> items = new();
        private string name;
    }
}
