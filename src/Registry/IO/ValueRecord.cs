//=============================================================================
// Module name : ValueRecord.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 21/10/2008 - Created.
//=============================================================================
using System;
using System.Runtime.InteropServices;


namespace Registry.IO
{
	/// <summary>
	/// ValueRecord class
	/// </summary>
	class ValueRecord : HiveRecord
	{

		/// <summary>
		/// 
		/// </summary>
		private Structures.ValueStructure valueRecord;


		/// <summary>
		/// 
		/// </summary>
		private string valueName;


		/// <summary>
		/// 
		/// </summary>
		private string defaultName = "(Default)";

 
		/// <summary>
		/// Class constructor
		/// </summary>
		public ValueRecord(byte[] buffer) : base(buffer)
		{
			if (buffer != null)
			{
				valueRecord = (Structures.ValueStructure)
					ByteArrayToStructure(buffer, valueRecord.GetType());
				
				
				valueName = GetStringAnsi(buffer, 
					Marshal.SizeOf(valueRecord), valueRecord.NameLength);

			}
		}



		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{
				if ((valueRecord.Flag & 1) == 1)
				{
					return valueName;
				}
				else
				{
					return this.defaultName;					
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public int Type
		{
			get
			{
				return valueRecord.ValueType;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public uint DataLength
		{
			get
			{
				return valueRecord.DataLength;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int DataOffset
		{
			get
			{
				return valueRecord.DataOffset;
			}
		}
	}
}
