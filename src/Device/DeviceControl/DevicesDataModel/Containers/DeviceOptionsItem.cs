namespace PDSystem.Device.DeviceControl
{
    public class DeviceOptionsItem : DeviceTreeListItem
    {
        public DeviceOptionsItem(string name, IconIndex icon, DeviceTreeListItem parent)
        {
            Parent = parent;
            this.name = name;
            this.icon = icon;
        }

        #region DeviceTreeListItem
        public override (string FirstColumn, string SecondColumn) DisplayText => ($"{name} ({items.Count})", string.Empty);

        public override IconIndex IconIndex => icon;

        public override bool IsEditable => false;

        public override List<IDeviceTreeListItem> Items 
            => items.Cast<IDeviceTreeListItem>().ToList();
        #endregion

        public Device? Device => (Parent as DeviceItem)?.Device;

        public void AddOptionItem(DeviceOptionItem item)
        {
            items.Add(item);
        }

        private List<DeviceOptionItem> items = new();
        private string name;
        private IconIndex icon;
    }
}
