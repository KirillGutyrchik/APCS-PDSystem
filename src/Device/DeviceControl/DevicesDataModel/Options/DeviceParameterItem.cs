namespace PDSystem.Device.DeviceControl.DevicesDataModel.Options
{
    public class DeviceParameterItem : DeviceOptionItem
    {
        public override (string FirstColumn, string SecondColumn) DisplayText
            => ($"{parameter.Name}", $"{EditText}");

        public override string EditText => value?.ToString() ?? string.Empty;

        public override bool IsEditable => true;

        public DeviceParameterItem(Parameter parameter, object? value, DeviceOptionsItem parent)
            : base(parent)
        {
            this.parameter = parameter;
            this.value = value;
        }


        private Parameter parameter;
        private object? value;
    }
}
