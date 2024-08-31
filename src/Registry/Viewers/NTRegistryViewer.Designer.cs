namespace Registry
{
	partial class NTRegistryViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTRegistryViewer));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.pathLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.keyDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.registryTree = new System.Windows.Forms.TreeView();
			this.treeImages = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.registryValues = new System.Windows.Forms.ListView();
			this.columnName = new System.Windows.Forms.ColumnHeader();
			this.columnType = new System.Windows.Forms.ColumnHeader();
			this.columnData = new System.Windows.Forms.ColumnHeader();
			this.valueImages = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.expandTree = new System.Windows.Forms.ToolStripMenuItem();
			this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathLabel,
            this.keyDateLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 427);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip.Size = new System.Drawing.Size(606, 22);
			this.statusStrip.TabIndex = 0;
			// 
			// pathLabel
			// 
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(591, 17);
			this.pathLabel.Spring = true;
			this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// keyDateLabel
			// 
			this.keyDateLabel.Name = "keyDateLabel";
			this.keyDateLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// registryTree
			// 
			this.registryTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.registryTree.ImageIndex = 0;
			this.registryTree.ImageList = this.treeImages;
			this.registryTree.Location = new System.Drawing.Point(0, 0);
			this.registryTree.Name = "registryTree";
			this.registryTree.SelectedImageIndex = 1;
			this.registryTree.Size = new System.Drawing.Size(237, 406);
			this.registryTree.TabIndex = 1;
			this.registryTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.registryTree_BeforeExpand);
			this.registryTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.registryTree_AfterSelect);
			// 
			// treeImages
			// 
			this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
			this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
			this.treeImages.Images.SetKeyName(0, "Icon_6.ico");
			this.treeImages.Images.SetKeyName(1, "Icon_7.ico");
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 21);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.registryTree);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.registryValues);
			this.splitContainer.Size = new System.Drawing.Size(606, 406);
			this.splitContainer.SplitterDistance = 237;
			this.splitContainer.TabIndex = 2;
			// 
			// registryValues
			// 
			this.registryValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnType,
            this.columnData});
			this.registryValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.registryValues.Location = new System.Drawing.Point(0, 0);
			this.registryValues.Name = "registryValues";
			this.registryValues.Size = new System.Drawing.Size(365, 406);
			this.registryValues.SmallImageList = this.valueImages;
			this.registryValues.TabIndex = 0;
			this.registryValues.UseCompatibleStateImageBehavior = false;
			this.registryValues.View = System.Windows.Forms.View.Details;
			// 
			// columnName
			// 
			this.columnName.Text = "Name";
			this.columnName.Width = 154;
			// 
			// columnType
			// 
			this.columnType.Text = "Type";
			this.columnType.Width = 100;
			// 
			// columnData
			// 
			this.columnData.Text = "Data";
			this.columnData.Width = 100;
			// 
			// valueImages
			// 
			this.valueImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("valueImages.ImageStream")));
			this.valueImages.TransparentColor = System.Drawing.Color.Transparent;
			this.valueImages.Images.SetKeyName(0, "Icon_9.ico");
			this.valueImages.Images.SetKeyName(1, "Icon_8.ico");
			// 
			// mainMenu
			// 
			this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
			this.mainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mainMenu.Size = new System.Drawing.Size(606, 21);
			this.mainMenu.TabIndex = 3;
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandTree,
            this.collapseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 17);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// expandTree
			// 
			this.expandTree.Name = "expandTree";
			this.expandTree.Size = new System.Drawing.Size(152, 22);
			this.expandTree.Text = "&Expand Tree";
			this.expandTree.Click += new System.EventHandler(this.expandTree_Click);
			// 
			// collapseToolStripMenuItem
			// 
			this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
			this.collapseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.collapseToolStripMenuItem.Text = "&Collapse Tree";
			this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// NTRegistryViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(606, 449);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mainMenu);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NTRegistryViewer";
			this.Text = "Registry Viewer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NTRegistryViewer_FormClosed);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel pathLabel;
		private System.Windows.Forms.TreeView registryTree;
		private System.Windows.Forms.ImageList treeImages;
		private System.Windows.Forms.ToolStripStatusLabel keyDateLabel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ListView registryValues;
		private System.Windows.Forms.ColumnHeader columnName;
		private System.Windows.Forms.ColumnHeader columnType;
		private System.Windows.Forms.ColumnHeader columnData;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expandTree;
		private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ImageList valueImages;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
	}
}