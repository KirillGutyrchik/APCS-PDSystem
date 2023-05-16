using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KopiLua.Lua;

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

            treeListView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            treeListView.CellEditStarting += TreeListView_CellEditStarting;
            //treeListView.CellEditFinishing += TreeListView_CellEditFinishing; ;
            //treeListView.CellEdit

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
                IsEditable = true,
                AspectGetter = item => (item as IDeviceTreeListItem)?.DisplayText.SecondColumn,
                AspectPutter = AspectPutter,
                //
                //(item, value) =>
                //{
                //    (item as IDeviceTreeListItem).EditText = value.ToString();
                //    treeListView.Unfreeze();
                //}
            };

            treeListView.Columns.Add(columnHeader_first);
            treeListView.Columns.Add(columnHeader_second);
        }

        private void AspectPutter(object item, object value)
        {
            var deviceTreeListItem = item as IDeviceTreeListItem;
            if (deviceTreeListItem is not null)
            {
                deviceTreeListItem.EditText = value.ToString() ?? string.Empty;
            }

            treeListView?.Unfreeze();
        }

        private void TreeListView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            IDeviceTreeListItem? item = e.RowObject as IDeviceTreeListItem;
            if (treeListView is null ||
                item is null || 
                item.IsEditable is false)
            {
                e.Cancel = true;
                return;
            }

            if (item is DeviceChannelItem)
            {
                // bind channel
                e.Cancel = true;
                return;
            }


            if (item.ComboBoxData is not null)
            {
                // Инициализация редактора с выпадающим списком для клетки
                comboBoxCellEditor = new ComboBox();
                comboBoxCellEditor.Items.AddRange(item.ComboBoxData.ToArray());
                comboBoxCellEditor.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxCellEditor.Sorted = true;
                comboBoxCellEditor.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBoxCellEditor.AutoCompleteMode = AutoCompleteMode.Append;
                comboBoxCellEditor.Enabled = true;
                comboBoxCellEditor.Visible = true;
                comboBoxCellEditor.Text = e.Value.ToString();
                comboBoxCellEditor.Bounds = e.CellBounds;
                e.Control = comboBoxCellEditor;
                comboBoxCellEditor.GotFocus += (sender, e) => comboBoxCellEditor.DroppedDown = true;
                comboBoxCellEditor.Focus();
                treeListView.Freeze();
            }
            else
            {
                // Инициализация редактора для клетки
                textBoxCellEditor = new TextBox();
                textBoxCellEditor.Enabled = true;
                textBoxCellEditor.Visible = true;
                textBoxCellEditor.Text = item.EditText;
                textBoxCellEditor.Bounds = e.CellBounds;
                e.Control = textBoxCellEditor;
                textBoxCellEditor.Focus();
                treeListView.Freeze();
            }
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
            deviceTree.AddRangeDevices(deviceManager.Devices);
            treeListView.Roots = deviceTree.Roots;

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

        private TextBox textBoxCellEditor;
        private ComboBox comboBoxCellEditor;

        private DeviceManager deviceManager = DeviceManager.Instance;
        private DevicesTreeModel deviceTree = new();
    }
}
