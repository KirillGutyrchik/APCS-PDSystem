using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class TypeContainer : IDeviceTreeListItem
    {
        #region Реализация IDeviceTreeListItem
        public (string FirstColumn, string SecondColumn) DisplayText => (type.Name, string.Empty);

        public string EditText => string.Empty;

        public bool IsEditable => false;

        List<IDeviceTreeListItem?> IDeviceTreeListItem.Items => items;

        IDeviceTreeListItem? IDeviceTreeListItem.Parent => null;
        #endregion

        public TypeContainer(DeviceType type)
        {
            this.type = type;
        }

        private readonly DeviceType type;
        private List<IDeviceTreeListItem?> items = new();
    }
}
