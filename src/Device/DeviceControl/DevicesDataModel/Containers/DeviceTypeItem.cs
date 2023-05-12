namespace PDSystem.Device.DeviceControl
{
    public class DeviceTypeItem : DeviceTreeListItem
    {
        public DeviceTypeItem(DeviceType deviceType)
        {
            this.deviceType = deviceType;
        }

        #region DeviceTreeListItem
        public override (string FirstColumn, string SecondColumn) DisplayText 
            => ($"{deviceType.Name} ({items.Count})", string.Empty);

        public override string EditText => string.Empty;

        public override bool IsEditable => false;

        public override List<IDeviceTreeListItem> Items => items.Cast<IDeviceTreeListItem>().ToList();

        public override IDeviceTreeListItem? Parent => null;
        #endregion

        

        public void AddDevice(Device device)
        {
            string objectName = device.ObjectName + device.ObjectNumber;

            var objectItem = items.FirstOrDefault(objectContainer => objectContainer.Name == objectName);
            if (objectItem is null)
            {
                objectItem = new(objectName, this);
                items.Add(objectItem);
            }

            objectItem.AddDevice(device);  
        }

        public DeviceType DeviceType => deviceType;

        

        private readonly DeviceType deviceType;
        private List<DeviceObjectItem> items = new();
    }
}
