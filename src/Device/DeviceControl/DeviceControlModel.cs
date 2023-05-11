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

            //// Настройка цвета отключенного компонента в дереве
            //var disabletItemStyle = new SimpleItemStyle();
            //disabletItemStyle.ForeColor = Color.Gray;
            //
            //treeListView.DisabledItemStyle = disabletItemStyle;
            //
            //// Текст подсветки чередующихся строк
            //treeListView.AlternateRowBackColor = Color.FromArgb(250, 250, 250);

            var columnHeader_first = new OLVColumn();
            columnHeader_first.Text = "Название";


            var columnHeader_second = new OLVColumn();
            columnHeader_second.Text = "Описание";

            treeListView.Columns.Add(columnHeader_first);
            treeListView.Columns.Add(columnHeader_second);
        }

        private TreeListView? treeListView = null;

        private DeviceManager deviceManager;
    }
}
