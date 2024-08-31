namespace Registry
{
	partial class NTRegistryUSBViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTRegistryUSBViewer));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.pathLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.keyDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.registryTree = new System.Windows.Forms.TreeView();
			this.treeImages = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.usbDevices = new System.Windows.Forms.ListView();
			this.columnFirst = new System.Windows.Forms.ColumnHeader();
			this.columnType = new System.Windows.Forms.ColumnHeader();
			this.valueImages = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.columnVendor = new System.Windows.Forms.ColumnHeader();
			this.columnProduct = new System.Windows.Forms.ColumnHeader();
			this.columnRevision = new System.Windows.Forms.ColumnHeader();
			this.columnId = new System.Windows.Forms.ColumnHeader();
			this.columnLast = new System.Windows.Forms.ColumnHeader();
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
			this.statusStrip.Size = new System.Drawing.Size(695, 22);
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
			this.registryTree.Size = new System.Drawing.Size(176, 406);
			this.registryTree.TabIndex = 1;
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
			this.splitContainer.Panel2.Controls.Add(this.usbDevices);
			this.splitContainer.Size = new System.Drawing.Size(695, 406);
			this.splitContainer.SplitterDistance = 176;
			this.splitContainer.TabIndex = 2;
			// 
			// usbDevices
			// 
			this.usbDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFirst,
            this.columnLast,
            this.columnType,
            this.columnVendor,
            this.columnProduct,
            this.columnRevision,
            this.columnId});
			this.usbDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usbDevices.Location = new System.Drawing.Point(0, 0);
			this.usbDevices.Name = "usbDevices";
			this.usbDevices.Size = new System.Drawing.Size(515, 406);
			this.usbDevices.SmallImageList = this.valueImages;
			this.usbDevices.TabIndex = 0;
			this.usbDevices.UseCompatibleStateImageBehavior = false;
			this.usbDevices.View = System.Windows.Forms.View.Details;
			// 
			// columnFirst
			// 
			this.columnFirst.Text = "First Plug Date";
			this.columnFirst.Width = 100;
			// 
			// columnType
			// 
			this.columnType.Text = "Type";
			// 
			// valueImages
			// 
			this.valueImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("valueImages.ImageStream")));
			this.valueImages.TransparentColor = System.Drawing.Color.Transparent;
			this.valueImages.Images.SetKeyName(0, "usb2.ico");
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
			this.mainMenu.Size = new System.Drawing.Size(695, 21);
			this.mainMenu.TabIndex = 3;
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 17);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// columnVendor
			// 
			this.columnVendor.Text = "Vendor";
			// 
			// columnProduct
			// 
			this.columnProduct.Text = "Product";
			// 
			// columnRevision
			// 
			this.columnRevision.Text = "Revision";
			// 
			// columnId
			// 
			this.columnId.Text = "Device Id";
			// 
			// columnLast
			// 
			this.columnLast.Text = "Last Plug Date";
			this.columnLast.Width = 102;
			// 
			// NTRegistryUSBViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 449);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mainMenu);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NTRegistryUSBViewer";
			this.Text = "Registry USB Devices Viewer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NTRegistryUSBViewer_FormClosed);
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
		private System.Windows.Forms.ListView usbDevices;
		private System.Windows.Forms.ColumnHeader columnFirst;
		private System.Windows.Forms.ColumnHeader columnType;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ImageList valueImages;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnVendor;
		private System.Windows.Forms.ColumnHeader columnProduct;
		private System.Windows.Forms.ColumnHeader columnRevision;
		private System.Windows.Forms.ColumnHeader columnId;
		private System.Windows.Forms.ColumnHeader columnLast;
	}
}