using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDSystem.Device.DeviceControl
{
    public partial class DeviceControl : UserControl
    {
        public DeviceControl()
        {
            InitializeComponent();
            deviceControlModel.SetTreeListView(treeListView);
            deviceControlModel.InitializeTreeListView();
        }

        public void Init() => deviceControlModel.InitData();

        DeviceControlModel deviceControlModel = DeviceControlModel.Instance;
    }

}
