using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceItemSubType : DeviceOptionItem
    {
        public DeviceItemSubType(DeviceOptionsItem parent)
            : base(parent)
        {

        }

        public override (string FirstColumn, string SecondColumn) DisplayText
            => ("Подтип", Device?.DeviceSubType.Name ?? "");

        public override string EditText
        {
            get => string.Empty;
            set { return; }
        }
        public override bool IsEditable => true;

        public override List<string>? ComboBoxData 
            => DeviceSubType.PossibleSubtypes(Device?.DeviceType);
    }
}
