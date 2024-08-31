//=============================================================================
// Module name : NTRegistryValue.cs
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
using Registry.IO;
//using Registry.IO.Structures;

namespace Registry.Parser
{

	public enum NTRegistryValueType
	{
		REG_NONE,
		REG_SZ,
		REG_EXPAND_SZ,
		REG_BINARY,
		REG_DWORD,
		REG_DWORD_BIG_ENDIAN,
		REG_LINK,
		REG_MULTI_SZ,
		REG_RESOURCE_LIST,
		REG_FULL_RESOURCE_DESCRIPTOR,
		REG_RESOURCE_REQUIREMENTS_LIST
	}

	public class NTRegistryValue
	{
		/// <summary>
		/// 
		/// </summary>
		private HiveReader hiveReader = null;

		/// <summary>
		/// 
		/// </summary>
		private ValueRecord valueRecord = null;


		/// <summary>
		/// 
		/// </summary>
		private byte[] dataBuffer = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hiveReader"></param>
		/// <param name="valueOffset"></param>
		public NTRegistryValue(HiveReader hiveReader, uint valueOffset)
		{
			this.hiveReader = hiveReader;

			HiveRecord record = hiveReader.GetRecord(valueOffset);

			if (record != null && record is ValueRecord)
			{
				valueRecord = record as ValueRecord;
				if ((valueRecord.DataLength & 0x80000000) == 0x80000000)
				{
					this.dataBuffer = BitConverter.GetBytes(
						(uint)valueRecord.DataOffset);
				}
				else
				{
					byte[] buffer = hiveReader.ReadRecord(
						(uint)valueRecord.DataOffset);

					// Keep only value data
					this.dataBuffer = new byte[buffer.Length 
						- Registry.IO.Structures.Size.RecordHeader];

					// Get rid of record header
					for (int i = 0; i < dataBuffer.Length; i++)
					{
						this.dataBuffer[i] = buffer[i 
							+ Registry.IO.Structures.Size.RecordHeader];
					}

				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string result = string.Empty;

			switch (this.Type)
			{
				case NTRegistryValueType.REG_BINARY:
					foreach (byte b in dataBuffer)
					{
						result += string.Format("{0:X2} ", b);
					}
					break;

				case NTRegistryValueType.REG_DWORD:
					result = string.Format("0x{0:X8} ({0})", BitConverter.ToInt32(this.dataBuffer, 0));
					break;

				case NTRegistryValueType.REG_DWORD_BIG_ENDIAN:
					long x = BitConverter.ToInt32(this.dataBuffer, 0);
					long little = ((x & 0x000000FF) << 24) 
						| ((x & 0x0000FF00) << 8) 
						| ((x & 0x00FF0000) >> 8) 
						| ((x & 0xFF000000) >> 24);

					result = little.ToString();
					break;

				case NTRegistryValueType.REG_SZ:
				case NTRegistryValueType.REG_MULTI_SZ:
					UnicodeEncoding encoding = new UnicodeEncoding();
					
					result = encoding.GetString(this.dataBuffer);
					break;

				
				case NTRegistryValueType.REG_NONE:				
				case NTRegistryValueType.REG_EXPAND_SZ:
				case NTRegistryValueType.REG_LINK:
				case NTRegistryValueType.REG_RESOURCE_LIST:		
				case NTRegistryValueType.REG_FULL_RESOURCE_DESCRIPTOR:
				case NTRegistryValueType.REG_RESOURCE_REQUIREMENTS_LIST:
					result = this.Type.ToString() + " cannot be displayed"; 
					break;
			}
			
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{
				return valueRecord.Name;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public NTRegistryValueType Type
		{
			get
			{
				return (NTRegistryValueType)valueRecord.Type;
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
		public byte[] DataBuffer
		{
			get
			{
				return this.dataBuffer;
			}
		}
	}
}
