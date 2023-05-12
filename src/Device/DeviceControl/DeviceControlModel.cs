using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceControlModel
    {
        private DeviceControlModel()
        {

        }

        private static DeviceControlModel? instance = null;
        public static DeviceControlModel Instance
        {
            get => instance ??= new DeviceControlModel();
        }


        public void SetTreeListView(TreeListView tlv)
        {
            treeListView = tlv;
        }

        public void InitializeTreeListView()
        {
            if (treeListView is null) return;

            treeListView.CellToolTipGetter = CellToolTipGetter;
            treeListView.CanExpandGetter = item => (item as IDeviceTreeListItem)?.Items?.Count > 0;
            treeListView.ChildrenGetter = item => (item as IDeviceTreeListItem)?.Items;

            var columnHeader_first = new OLVColumn();
            columnHeader_first.Text = "Название";
            columnHeader_first.Sortable = false;
            columnHeader_first.IsEditable = false;
            columnHeader_first.AspectGetter = item => (item as IDeviceTreeListItem)?.DisplayText.FirstColumn;
            columnHeader_first.ImageGetter = item => (int)(item as IDeviceTreeListItem)?.IconIndex;

            var columnHeader_second = new OLVColumn();
            columnHeader_second.Text = "Описание";
            columnHeader_second.Sortable = false;
            columnHeader_second.IsEditable = false;
            columnHeader_second.AspectGetter = item => (item as IDeviceTreeListItem)?.DisplayText.SecondColumn;

            treeListView.Columns.Add(columnHeader_first);
            treeListView.Columns.Add(columnHeader_second);
        }

        public void InitData()
        {
            if (treeListView is null) return;

            treeListView.BeginUpdate();
            deviceManager.InitDevicesTreeModel();
            treeListView.Roots = deviceManager.DeviceTree.DeviceTree;

            treeListView.EndUpdate();
        }

        public string? CellToolTipGetter(OLVColumn column, object displayingObject)
        {
            var item = displayingObject as IDeviceTreeListItem;
            if (item is null) return null;

            return column.Index switch
            {
                0 => item.DisplayText.FirstColumn,
                1 => item.DisplayText.SecondColumn,
                _ => null,
            };
        }

        private TreeListView? treeListView = null;

        private DeviceManager deviceManager = DeviceManager.Instance;
    }
}
