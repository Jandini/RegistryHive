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
using System.Collections.Generic;
using System.Text;
using Registry.IO;

namespace Registry.Parser
{
	public class NTRegistryKey : IDisposable
	{

		/// <summary>
		/// 
		/// </summary>
		private HiveReader hiveReader = null;

		/// <summary>
		/// 
		/// </summary>
		private KeyRecord keyRecord = null;

		/// <summary>
		/// 
		/// </summary>
		private SubKeyListRecord subkeyListRecord = null;

		/// <summary>
		/// 
		/// </summary>
		private ValueListRecord valueListRecord = null;

		/// <summary>
		/// 
		/// </summary>
		private object tag = null;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveReader"></param>
		/// <param name="keyOffset"></param>
		public NTRegistryKey(HiveReader hiveReader, uint keyOffset)
		{
			this.hiveReader = hiveReader;
						
			HiveRecord record = hiveReader.GetRecord(keyOffset);

			if (record != null && record is KeyRecord)
			{
				keyRecord = record as KeyRecord;
				
				if (keyRecord.SubKeyCount > 0)
				{
					record = hiveReader.GetRecord((uint)keyRecord.SubKeyListOffset);

					if (record != null && record is SubKeyListRecord)
					{
						subkeyListRecord = record as SubKeyListRecord;
					}
				}


				if (keyRecord.ValueCount > 0 && keyRecord.ValueListOffset != -1)
				{
					byte[] valueListBuffer = hiveReader.ReadRecord((uint)keyRecord.ValueListOffset);					

					if (valueListBuffer != null && valueListBuffer.Length > 0)
					{
						valueListRecord = new ValueListRecord(valueListBuffer, keyRecord.ValueCount);


					}
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			this.keyRecord = null;
			this.subkeyListRecord = null;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public NTRegistryKey GetSubKey(int index)
		{
			NTRegistryKey result = null;

			if (subkeyListRecord != null)
			{
				result = new NTRegistryKey(
					this.hiveReader,
					subkeyListRecord.GetKeyOffset(index));
			}

			return result;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public NTRegistryKey GetSubKey(string name)
		{
			NTRegistryKey result = null;

			if (subkeyListRecord != null)
			{
				int i = 0;
				while (i < subkeyListRecord.SubKeyCount && result == null)
				{
					result = new NTRegistryKey(
						this.hiveReader,
						subkeyListRecord.GetKeyOffset(i));

					if (result.Name != name)
					{
						result = null;
					}

					i++;
				}
			}

			return result;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public NTRegistryValue[] GetValues()
		{
			int valueCount = this.ValueCount;

			NTRegistryValue[] values = new NTRegistryValue[valueCount];

			if (valueCount > 0 && this.valueListRecord != null)
			{
				values = new NTRegistryValue[valueCount];

				for (int i = 0; i < valueCount; i++)
				{
					values[i] = new NTRegistryValue(
						this.hiveReader,
						(uint)this.valueListRecord[i].ValueOffset);
				}
			}

			return values;
		}


		/// <summary>
		/// 
		/// </summary>
		public int SubKeyCount
		{
			get
			{
				int result = 0;

				if (this.subkeyListRecord != null)
				{
					result = this.subkeyListRecord.SubKeyCount;
				}

				return result;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public int ValueCount
		{
			get
			{
				int result = 0;

				if (this.keyRecord != null)
				{
					result = this.keyRecord.ValueCount;
				}

				return result;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{
				string result = string.Empty;
			
				if (this.keyRecord != null)
				{
					result = this.keyRecord.Name;
				}

				return result;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime LastModified
		{
			get
			{
				return DateTime.FromFileTimeUtc(this.keyRecord.LastModified);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public object Tag
		{
			get
			{
				return this.tag;
			}

			set
			{
				this.tag = value;
			}
		}

	}
}
