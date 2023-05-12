namespace PDSystem.Device.DeviceControl
{
    public class DeviceObjectItem : DeviceTreeListItem
    {
        public DeviceObjectItem(string name, DeviceTreeListItem parent)
        {
            Parent = parent;
            this.name = name;
        }

        #region DeviceTreeListItem
        public override (string FirstColumn, string SecondColumn) DisplayText => ($"{name} ({items.Count})", string.Empty);

        public override List<IDeviceTreeListItem> Items => items.Cast<IDeviceTreeListItem>().ToList();
        #endregion

        public void AddDevice(Device device)
        {
            items.Add(new DeviceItem(device, this));
        }

        public string Name => name;

        private List<DeviceItem> items = new();
        private string name;
    }
}
