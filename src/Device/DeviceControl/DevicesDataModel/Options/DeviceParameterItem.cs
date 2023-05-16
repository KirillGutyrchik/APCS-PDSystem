namespace PDSystem.Device.DeviceControl.DevicesDataModel.Options
{
    public class DeviceParameterItem : DeviceOptionItem
    {
        public override (string FirstColumn, string SecondColumn) DisplayText
            => ($"{parameter.Name}", $"{EditText}");

        public override string EditText
        { 
            get => value?.ToString() ?? string.Empty;
            set
            {
                Device.Parameters[parameter] = value;
                this.value = Device.Parameters[parameter];
            }
        }

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
