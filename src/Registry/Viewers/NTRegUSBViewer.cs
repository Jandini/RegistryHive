using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Registry.Parser;

namespace Registry
{
	public partial class NTRegistryUSBViewer : Form
	{

		/// <summary>
		/// 
		/// </summary>
		private Stream hiveStream = null;

		/// <summary>
		/// 
		/// </summary>
		private const string strCurrentControlSet = "ControlSet";
		
		/// <summary>
		/// 
		/// </summary>
		private const string strEnum = "Enum";
		
		/// <summary>
		/// 
		/// </summary>
		private const string strUsbStor = "USBSTOR";
		
		/// <summary>
		/// 
		/// </summary>
		private const string strDeviceParameters = "Device Parameters";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveBuffer"></param>
		public NTRegistryUSBViewer(byte[] buffer)
		{
			InitializeComponent();

			// Access from memory
			this.hiveStream = new MemoryStream(buffer);

			OpenRegistryTree();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveFileName"></param>
		public NTRegistryUSBViewer(string path)
		{
			InitializeComponent();

			// Access from file
			this.hiveStream = new FileStream(path, FileMode.Open);

			OpenRegistryTree();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		static private void ErrorMessage(string message)
		{
			MessageBox.Show(message,
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		static public void Open(string path)
		{
			try
			{
				NTRegistryUSBViewer viewer = new NTRegistryUSBViewer(path);
				viewer.ShowDialog();
			}
			catch (Exception ex)
			{
				ErrorMessage(ex.Message);
			}
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		static public void Open(byte[] buffer)
		{
			try
			{
				NTRegistryUSBViewer viewer = new NTRegistryUSBViewer(buffer);
				viewer.ShowDialog();
			}
			catch (Exception ex)
			{
				ErrorMessage(ex.Message);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public void OpenRegistryTree()
		{
			NTRegistryTree ntRegistryTree = new NTRegistryTree(this.hiveStream);

			NTRegistryKey rootKey = ntRegistryTree.GetRootKey();

			TreeNode rootNode = new TreeNode(rootKey.Name);
			rootNode.Tag = rootKey;


			for (int i = 0; i < rootKey.SubKeyCount; i++)
			{
				NTRegistryKey subKey = rootKey.GetSubKey(i);

				if (String.Compare(subKey.Name, 0, strCurrentControlSet, 0, strCurrentControlSet.Length) == 0)
				{
					TreeNode controlNode = new TreeNode(subKey.Name);
					controlNode.Tag = subKey;

					rootNode.Nodes.Add(controlNode);
				}
			}

			registryTree.Nodes.Add(rootNode);
			registryTree.ExpandAll();
		}





		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		private void ParseUsbStor(NTRegistryKey key)
		{
			usbDevices.BeginUpdate();

			try
			{
				usbDevices.Items.Clear();

				NTRegistryKey enumKey = key.GetSubKey(strEnum);

				if (enumKey != null)
				{
					NTRegistryKey usbStorKey = enumKey.GetSubKey(strUsbStor);

					if (usbStorKey != null)
					{
						for (int j = 0; j < usbStorKey.SubKeyCount; j++)
						{
							NTRegistryKey deviceKey = usbStorKey.GetSubKey(j);

							if (deviceKey != null)
							{

								string[] items = new string[10];
								string[] devices = deviceKey.Name.Split(new char[] { '&' });


								devices[1] = devices[1].Replace("Ven_", "");
								devices[2] = devices[2].Replace("Prod_", "");
								devices[3] = devices[3].Replace("Rev_", "");

								for (int i = 0; i < devices.Length; i++)
								{
									devices[i] = devices[i].Replace('_', ' ');
								}

								devices.CopyTo(items, 2);



								NTRegistryKey deviceIdKey = deviceKey.GetSubKey(0);

								if (deviceIdKey != null)
								{

									NTRegistryKey deviceParametersKey = deviceIdKey.GetSubKey(strDeviceParameters);

									if (deviceParametersKey != null)
									{
										items[0] = deviceParametersKey.LastModified.ToString();
										items[1] = deviceIdKey.LastModified.ToString();

										items[6] = deviceIdKey.Name;

										ListViewItem item = new ListViewItem(items, 0);
										usbDevices.Items.Add(item);
									}
								}
							}
						}
					}
				}

			}
			finally
			{
				if (usbDevices.Items.Count > 0)
				{
					foreach (ColumnHeader column in usbDevices.Columns)
					{
						column.Width = -1;
					}
				}

				usbDevices.EndUpdate();
			}

		}





		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void registryTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			NTRegistryKey selectedKey = e.Node.Tag as NTRegistryKey;

			pathLabel.Text = "Key " + e.Node.FullPath +
				" was last modified on " + selectedKey.LastModified.ToLongDateString();

			NTRegistryValue[] keyValues = selectedKey.GetValues();

			pathLabel.Text += " and has " + keyValues.Length.ToString() + " value(s)";

			ParseUsbStor(selectedKey);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NTRegistryUSBViewer_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Make sure we will close what we have opened
			this.hiveStream.Close();
			this.hiveStream = null;
		}

	}
}
