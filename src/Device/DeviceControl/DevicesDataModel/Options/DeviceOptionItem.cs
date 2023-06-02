namespace PDSystem.Device.DeviceControl
{
    public abstract class DeviceOptionItem : IDeviceTreeListItem
    {
        #region Реализация IDeviceTreeListItem
        public abstract (string FirstColumn, string SecondColumn) DisplayText { get; }

        public abstract string EditText { get; set; }

        public virtual IconIndex IconIndex => IconIndex.NONE;
        public abstract bool IsEditable { get; }

        public List<IDeviceTreeListItem>? Items => null;

        public virtual IDeviceTreeListItem? Parent
        {
            get => parent;
            set => parent = value as DeviceOptionsItem ?? throw new ArgumentNullException();
        }

        public virtual List<string>? ComboBoxData => null;
        #endregion

        public Device? Device => parent.Device;

        
        public DeviceOptionItem(DeviceOptionsItem parent)
        {
            this.parent = parent;
        }

        protected DeviceOptionsItem parent; 
    }
}
