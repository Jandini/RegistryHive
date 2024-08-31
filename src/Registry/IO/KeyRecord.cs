//=============================================================================
// Module name : KeyRecord.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 02/02/2009 - Added IsRootKey and IsNodeKey properties.
// 21/10/2008 - Created.
//=============================================================================
using System;
using System.Runtime.InteropServices;


namespace Registry.IO
{

	
	/// <summary>
	/// KeyRecord class
	/// </summary>
	class KeyRecord : HiveRecord
	{


		/// <summary>
		/// 
		/// </summary>
		private Structures.KeyStructure keyRecord;


		/// <summary>
		/// 
		/// </summary>
		private string keyName;


		/// <summary>
		/// Class constructor
		/// </summary>
		public KeyRecord(byte[] buffer) : base(buffer)
		{
			if (buffer != null)
			{
				keyRecord = (Structures.KeyStructure)
					ByteArrayToStructure(buffer, keyRecord.GetType());
				
				keyName = GetStringAnsi(buffer, Marshal.SizeOf(keyRecord),
					keyRecord.NameLength);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{
				return keyName;
			}
		}



		/// <summary>
		/// 
		/// </summary>
		public int ParentOffset
		{
			get
			{
				return this.keyRecord.ParentOffset;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public int ValueCount
		{
			get
			{
				return this.keyRecord.ValueCount;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public int SubKeyCount
		{
			get
			{
				return this.keyRecord.SubKeyCount;
			}
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		public long SubKeyListOffset
		{
			get
			{
				return this.keyRecord.SubKeyListOffset;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public long ValueListOffset
		{
			get
			{
				return (uint)this.keyRecord.ValueListOffset;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public long LastModified
		{
			get
			{
				return (long)this.keyRecord.LastModified;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public bool IsRootKey
		{
			get
			{
				return this.keyRecord.KeyLevel == Structures.KeyRecordLevel.Root;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public bool IsNodeKey
		{
			get
			{
				return this.keyRecord.KeyLevel == Structures.KeyRecordLevel.Node;
			}
		}		
	}
}
