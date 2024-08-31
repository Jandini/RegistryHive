//=============================================================================
// Module name : ValueListRecord.cs
// Tab size    : 3
// Author      : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 07/02/2009 - Created.
//=============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.IO
{
	class ValueListRecord : HiveRecord
	{

		/// <summary>
		/// 
		/// </summary>
		private Structures.ValueListEntryStructure[] listEntries = null;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="valueCount"></param>
		public ValueListRecord(byte[] buffer, int valueCount)
			: base(buffer)
		{
			if (buffer != null)
			{
				listEntries = new Registry.IO.Structures.ValueListEntryStructure[valueCount];

				for (int i = 0; i < valueCount; i++)
				{
					listEntries[i] = (Structures.ValueListEntryStructure)ByteArrayToStructure(
						buffer, 
						listEntries[i].GetType(),
						Structures.Size.RecordHeader + i * Structures.Size.ValueListEntry);					
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Structures.ValueListEntryStructure this[int index]
		{
			get
			{
				return listEntries[index];
			}
		}

	}
}
