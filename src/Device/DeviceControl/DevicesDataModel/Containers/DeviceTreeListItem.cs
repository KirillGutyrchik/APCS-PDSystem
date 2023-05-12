﻿namespace PDSystem.Device.DeviceControl
{
    public abstract class DeviceTreeListItem : IDeviceTreeListItem
    {
        public virtual (string FirstColumn, string SecondColumn) DisplayText 
            => (string.Empty, string.Empty);

        public virtual string EditText 
            => string.Empty;

        public virtual bool IsEditable 
            => false;

        public virtual IconIndex IconIndex 
            => IconIndex.NONE;

        public virtual List<IDeviceTreeListItem>? Items
        {
            get => null;
            set => items = value ?? items;
        }

        public virtual IDeviceTreeListItem? Parent
        {
            get => parent;
            set => parent = value;
        }

        private IDeviceTreeListItem? parent = null;
        private List<IDeviceTreeListItem> items = new();
    }
}
