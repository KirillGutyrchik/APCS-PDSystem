using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public interface IDeviceTreeListItem
    {
        (string FirstColumn, string SecondColumn) DisplayText { get; }

        string EditText { get; }

        bool IsEditable { get; }

        IconIndex IconIndex { get; }

        List<IDeviceTreeListItem>? Items { get; }

        IDeviceTreeListItem? Parent { get; }
    }
}
