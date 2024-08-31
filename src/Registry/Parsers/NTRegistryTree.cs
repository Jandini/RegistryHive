//=============================================================================
// Module name : NTRegistry.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 02/02/2009 - Created.
//=============================================================================
using System;
using System.IO;
using System.Collections.Specialized;
using Registry.IO;

namespace Registry.Parser
{
	/// <summary>
	/// 
	/// </summary>
	public class NTRegistryTree : IDisposable
	{

		/// <summary>
		/// 
		/// </summary>
		private Stream hiveStream = null;

		/// <summary>
		/// 
		/// </summary>
		private HiveReader hiveReader = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		public NTRegistryTree(Stream hiveStream)
		{
			this.hiveStream = hiveStream;
			this.hiveReader = new HiveReader(hiveStream);
		}


		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			if (this.hiveStream != null)
			{
				this.hiveStream.Close();
				this.hiveStream = null;
			}

			this.hiveReader = null;
		}

		

		/// <summary>
		/// 
		/// </summary>
		public NTRegistryKey GetRootKey()
		{
			HiveHeader headerPage = this.hiveReader.ReadHeader();
			NTRegistryKey result = new NTRegistryKey(this.hiveReader, headerPage.RootKeyOffset);

			return result;
		}
	}

}
