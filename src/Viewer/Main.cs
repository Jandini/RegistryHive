using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Viewer
{
	public partial class Main : Form
	{
		public string fileName = string.Empty;


		public Main(string path)
		{
			this.fileName = path;

			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_Load(object sender, EventArgs e)
		{
			Registry.NTRegistryViewer viewer = new Registry.NTRegistryViewer(fileName);
			viewer.Show();

			Registry.NTRegistryUSBViewer usbViewer = new Registry.NTRegistryUSBViewer(fileName);
			usbViewer.Show();

//			Registry.NTRegistryViewer.Open(fileName);
//			Registry.NTRegistryUSBViewer.Open(fileName);
			
			//Application.Exit();
		}
	}
}