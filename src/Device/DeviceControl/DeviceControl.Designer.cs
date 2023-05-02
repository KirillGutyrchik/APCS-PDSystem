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
            treeListView1 = new BrightIdeasSoftware.TreeListView();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)treeListView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeListView1
            // 
            treeListView1.Dock = DockStyle.Bottom;
            treeListView1.GridLines = true;
            treeListView1.Location = new Point(0, 52);
            treeListView1.Name = "treeListView1";
            treeListView1.ShowGroups = false;
            treeListView1.Size = new Size(636, 625);
            treeListView1.TabIndex = 0;
            treeListView1.View = View.Details;
            treeListView1.VirtualMode = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(636, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
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
            // DeviceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip1);
            Controls.Add(treeListView1);
            Name = "DeviceControl";
            Size = new Size(636, 677);
            ((System.ComponentModel.ISupportInitialize)treeListView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    }
}
