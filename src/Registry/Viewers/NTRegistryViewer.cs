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
	public partial class NTRegistryViewer : Form
	{

		/// <summary>
		/// 
		/// </summary>
		private Stream hiveStream = null;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveBuffer"></param>
		public NTRegistryViewer(byte[] buffer)
		{
			InitializeComponent();

			// Access from memory
			this.hiveStream = new MemoryStream(buffer, false);

			OpenRegistryTree();
		}
		


		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveFileName"></param>
		public NTRegistryViewer(string path)
		{
			InitializeComponent();

			// Access from file
			this.hiveStream = new FileStream(path, FileMode.Open, 
				// These flags allow to open the same file by multiple viewers
				FileAccess.Read, FileShare.Delete | FileShare.ReadWrite);

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
				using (NTRegistryViewer viewer = new NTRegistryViewer(path))
				{
					viewer.ShowDialog();
				}
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
				NTRegistryViewer viewer = new NTRegistryViewer(buffer);
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

			TreeNode node = new TreeNode(rootKey.Name);

			node.Tag = rootKey;

			registryTree.Nodes.Add(node);
			AddNodes(node);

			node.Expand();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		private void AddNodes(TreeNode parent)
		{
			NTRegistryKey parentKey = (NTRegistryKey)parent.Tag;

			if (parentKey != null && parentKey.Tag == null)
			{
				TreeNode[] childNodes = new TreeNode[parentKey.SubKeyCount];

				for (int i = 0; i < parentKey.SubKeyCount; i++)
				{
					NTRegistryKey subKey = parentKey.GetSubKey(i);

					childNodes[i] = new TreeNode(subKey.Name);
					childNodes[i].Tag = subKey;
				}

				parent.Nodes.AddRange(childNodes);

				// Make sure we will add key only once 
				parentKey.Tag = 1;
			}
		}	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		private void AddValues(NTRegistryValue[] values)
		{
			registryValues.BeginUpdate();

			try
			{
				registryValues.Items.Clear();
				
				foreach (NTRegistryValue value in values)
				{
					ListViewItem item = new ListViewItem(value.Name);
					item.SubItems.Add(value.Type.ToString());
					item.SubItems.Add(value.ToString());
					item.ImageIndex = 1;

					switch (value.Type)
					{
						case NTRegistryValueType.REG_NONE:
						case NTRegistryValueType.REG_BINARY:
						case NTRegistryValueType.REG_DWORD:
						case NTRegistryValueType.REG_DWORD_BIG_ENDIAN:
							item.ImageIndex = 0;
							break;
					}


					registryValues.Items.Add(item);
				}

			}
			finally
			{
				if (values.Length > 0)
				{
					foreach (ColumnHeader column in registryValues.Columns)
					{
						column.Width = -1;
					}
				}

				registryValues.EndUpdate();
			}
		
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void registryTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			registryTree.BeginUpdate();

			try
			{
				foreach (TreeNode node in e.Node.Nodes)
				{
					AddNodes(node);
				}
			}
			finally
			{
				registryTree.EndUpdate();
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

			AddValues(keyValues);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void expandTree_Click(object sender, EventArgs e)
		{
			try
			{
				registryTree.BeginUpdate();
				registryTree.Refresh();
				registryTree.ExpandAll();
			}
			finally
			{
				registryTree.EndUpdate();
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				registryTree.BeginUpdate();

				registryTree.CollapseAll();
			}
			finally
			{
				registryTree.EndUpdate();
			}
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
		private void NTRegistryViewer_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Make sure we will close what we have opened
			this.hiveStream.Close();
			this.hiveStream = null;
		}

	}
}