namespace PDSystem.Device.DeviceControl
{
    public abstract class DeviceOptionItem : IDeviceTreeListItem
    {
        #region Реализация IDeviceTreeListItem
        public abstract (string FirstColumn, string SecondColumn) DisplayText { get; }

        public abstract string EditText { get; }

        public abstract bool IsEditable { get; }

        public virtual List<IDeviceTreeListItem>? Items => emptyItem;

        public virtual IDeviceTreeListItem? Parent => parent;
        #endregion

        public Device Device => parent.Device;

        public DeviceOptionItem(DeviceOptionsContainer parent)
        {
            this.parent = parent;
        }

        private List<IDeviceTreeListItem> emptyItem = new();

        protected DeviceOptionsContainer parent; 
    }
}
