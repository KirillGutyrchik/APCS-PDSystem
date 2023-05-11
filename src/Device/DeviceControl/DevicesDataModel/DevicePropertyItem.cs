using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{


    public class DevicePropertyItem : DeviceOptionItem
    {
        public DevicePropertyItem(Property property, object? value, DeviceOptionsContainer parent) 
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
