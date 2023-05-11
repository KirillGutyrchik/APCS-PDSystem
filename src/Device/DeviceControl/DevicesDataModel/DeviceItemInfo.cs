using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceItemInfo : DeviceOptionItem
    {
        public DeviceItemInfo(string name, string value , DeviceOptionsContainer parent) 
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
