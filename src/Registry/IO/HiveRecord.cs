//=============================================================================
// Module name : BaseRecord.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 10/11/2008 - Added Offset property.
// 21/10/2008 - Created.
//=============================================================================
using System;
using System.Runtime.InteropServices;


namespace Registry.IO
{
	/// <summary>
	/// BaseRecord class
	/// </summary>
	public class HiveRecord : IO.HiveIO
	{
		
		/// <summary>
		/// 
		/// </summary>
		private Structures.RecordHeaderStructure recordHeader;


		/// <summary>
		/// Class constructor
		/// </summary>
		public HiveRecord(byte[] buffer)
		{
			if (buffer != null)
			{
				recordHeader = (Structures.RecordHeaderStructure)ByteArrayToStructure(
					buffer, 
					recordHeader.
					GetType());
			}
		}


		/// <summary>
		/// Size of whole record
		/// </summary>
		public Int32 Size
		{
			get
			{
				return Math.Abs(recordHeader.Size);
			}		
		}
	}
}