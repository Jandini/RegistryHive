//=============================================================================
// Module name : HeaderPage.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 02/02/2009 - Added StartOffset property.
// 21/10/2008 - Created.
//=============================================================================
using System;


namespace Registry.IO
{
	/// <summary>
	/// HeaderPage
	/// </summary>
	public class HiveHeader : HiveIO
	{

		/// <summary>
		/// Header page structure
		/// </summary>
		private Structures.HiveHeaderStructure headerPage;


		/// <summary>
		/// Class constructor
		/// </summary>
		public HiveHeader(byte[] buffer)
		{
			if (buffer != null)
			{				
				headerPage = (Structures.HiveHeaderStructure)
					ByteArrayToStructure(buffer, headerPage.GetType());
			}		
		}


		/// <summary>
		/// Return offset of the root key
		/// </summary>
		public UInt32 RootKeyOffset
		{
			get
			{
				return headerPage.RootKeyOffset;
			}
		}
	}
}
