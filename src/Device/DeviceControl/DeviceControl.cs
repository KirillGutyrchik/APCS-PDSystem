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

        private void treeListView_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            e.Item.Font = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);
        }
    }

}
