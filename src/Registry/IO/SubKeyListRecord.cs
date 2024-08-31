//=============================================================================
// Module name : SubKeysRecord.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 02/02/2009 - Created.
//=============================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.IO
{
	class SubKeyListRecord : HiveRecord
	{
		/// <summary>
		/// 
		/// </summary>
		private Structures.SubKeyListStructure listHeader;
		
		/// <summary>
		/// 
		/// </summary>
		private Structures.SubKeyListEntryStructure[] listEntries = null;

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		public SubKeyListRecord(byte[] buffer) : base(buffer)
		{
			if (buffer != null)
			{
				listHeader = (Structures.SubKeyListStructure)
					ByteArrayToStructure(buffer, listHeader.GetType());

				int subKeyCount = listHeader.SubKeyCount;

				listEntries = new Registry.IO.Structures.SubKeyListEntryStructure[subKeyCount];

				for (int i = 0; i < subKeyCount; i++)
				{
					listEntries[i] = (Structures.SubKeyListEntryStructure)ByteArrayToStructure(
						buffer, 
						listEntries[i].GetType(),
						Structures.Size.SubKeyListHeader + i * Structures.Size.SubKeyListEntry);
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public ushort SubKeyCount
		{
			get
			{
				return this.listHeader.SubKeyCount;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public uint GetKeyOffset(int index)
		{
			return this.listEntries[index].KeyOffset;
		}

			
	}
}
