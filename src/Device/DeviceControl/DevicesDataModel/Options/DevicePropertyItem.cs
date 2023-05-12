namespace PDSystem.Device.DeviceControl.DevicesDataModel.Options
{


    public class DevicePropertyItem : DeviceOptionItem
    {
        public DevicePropertyItem(Property property, object? value, DeviceOptionsItem parent)
            : base(parent)
        {
            this.property = property;
            this.value = value;
        }

        public override (string FirstColumn, string SecondColumn) DisplayText
            => ($"{property.Name}", value?.ToString() ?? string.Empty);

        public override string EditText => value?.ToString() ?? string.Empty;

        public override bool IsEditable => true;

        private Property property;
        private object? value;
    }
}
