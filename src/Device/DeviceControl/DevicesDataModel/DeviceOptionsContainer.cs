using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceOptionsContainer : IDeviceTreeListItem
    {
        #region Реализция IDeviceTreeListItem
        public (string FirstColumn, string SecondColumn) DisplayText => ($"{name} ({items.Count})", string.Empty);

        public string EditText => string.Empty;

        public bool IsEditable => false;

        public List<IDeviceTreeListItem> Items => items.Cast<IDeviceTreeListItem>().ToList();

        public IDeviceTreeListItem? Parent => parent;
        #endregion


        public Device Device => parent.Device;

        public DeviceOptionsContainer(string name, DeviceItem parent) 
        {
            this.name = name;
            this.parent = parent;
        }

        public void AddOptionItem(DeviceOptionItem item)
        {
            items.Add(item);
        }

        private List<DeviceOptionItem> items = new();
        private DeviceItem parent;
        private string name;
    }
}
