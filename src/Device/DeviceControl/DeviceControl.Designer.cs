namespace PDSystem.Device.DeviceControl
{
    partial class DeviceControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceControl));
            treeListView = new BrightIdeasSoftware.TreeListView();
            imageList = new ImageList(components);
            toolStrip = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)treeListView).BeginInit();
            toolStrip.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // treeListView
            // 
            treeListView.AlternateRowBackColor = Color.White;
            treeListView.BackColor = Color.FromArgb(252, 252, 252);
            treeListView.Dock = DockStyle.Fill;
            treeListView.GridLines = true;
            treeListView.Location = new Point(3, 28);
            treeListView.Name = "treeListView";
            treeListView.ShowGroups = false;
            treeListView.ShowImagesOnSubItems = true;
            treeListView.Size = new Size(839, 586);
            treeListView.SmallImageList = imageList;
            treeListView.TabIndex = 0;
            treeListView.UseAlternatingBackColors = true;
            treeListView.UseCellFormatEvents = true;
            treeListView.View = View.Details;
            treeListView.VirtualMode = true;
            treeListView.FormatCell += treeListView_FormatCell;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "description.ico");
            imageList.Images.SetKeyName(1, "parameters.ico");
            imageList.Images.SetKeyName(2, "settings.ico");
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.Fill;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(845, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(treeListView, 0, 1);
            tableLayoutPanel1.Controls.Add(toolStrip, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(845, 617);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // DeviceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "DeviceControl";
            Size = new Size(845, 617);
            ((System.ComponentModel.ISupportInitialize)treeListView).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private ImageList imageList;
    }
}
