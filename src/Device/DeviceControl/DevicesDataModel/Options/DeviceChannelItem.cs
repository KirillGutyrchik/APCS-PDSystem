namespace PDSystem.Device.DeviceControl
{
    public class DeviceChannelItem : DeviceOptionItem
    {
        public override (string FirstColumn, string SecondColumn) DisplayText
            => ($"{channel.Name} {channel.Comment}", $"({channel.ModuleOffset}:{channel.Offset})");

        public override string EditText => string.Empty;

        public override bool IsEditable => false;

        public DeviceChannelItem(IOChannel channel, DeviceOptionsItem parent)
            : base(parent)
        {
            this.channel = channel;
        }

        private IOChannel channel;
    }
}
