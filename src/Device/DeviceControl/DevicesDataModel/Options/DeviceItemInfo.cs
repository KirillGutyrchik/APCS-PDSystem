using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl.DevicesDataModel.Options
{
    public class DeviceItemInfo : DeviceOptionItem
    {
        public DeviceItemInfo(string name, string value, DeviceOptionsItem parent)
            : base(parent)
        {
            this.name = name;
            this.value = value;
        }

        public override (string FirstColumn, string SecondColumn) DisplayText
            => (name, value);

        public override string EditText => string.Empty;

        public override bool IsEditable => false;

        private string name;
        private string value;
    }
}
