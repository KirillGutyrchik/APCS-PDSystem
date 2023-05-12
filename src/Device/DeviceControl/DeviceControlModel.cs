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

            treeListView.Expanded += TreeListView_ExpandedOrCollapsed;
            treeListView.Collapsed += TreeListView_ExpandedOrCollapsed;

            treeListView.FormatCell += TreeListView_FormatCell;

            var columnHeader_first = new OLVColumn
            {
                Text = "Название",
                MinimumWidth = 100,
                Sortable = false,
                IsEditable = false,
                AspectGetter = item => (item as IDeviceTreeListItem)?.DisplayText.FirstColumn,
                ImageGetter = item => (int)((item as IDeviceTreeListItem)?.IconIndex ?? IconIndex.NONE),
            };

            var columnHeader_second = new OLVColumn
            {
                Text = "Описание",
                MinimumWidth = 100,
                Sortable = false,
                IsEditable = false,
                AspectGetter = item => (item as IDeviceTreeListItem)?.DisplayText.SecondColumn,
            };


            treeListView.Columns.Add(columnHeader_first);
            treeListView.Columns.Add(columnHeader_second);
        }

        private void TreeListView_FormatCell(object? sender, FormatCellEventArgs e)
        {
            e.Item.Font = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);
        }

        private void TreeListView_ExpandedOrCollapsed(object? sender, EventArgs e)
        {
            treeListView?.Columns[0].AutoResize(
                ColumnHeaderAutoResizeStyle.ColumnContent);
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
