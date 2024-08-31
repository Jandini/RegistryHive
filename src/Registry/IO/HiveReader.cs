//=============================================================================
// Module name : HiveReader.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 10/11/2008 - Chenged ReadHive to ReadPage
// 21/10/2008 - Created.
//=============================================================================
using System;
using System.IO;


namespace Registry.IO
{
	/// <summary>
	/// Summary description for HiveReader.
	/// </summary>
	public class HiveReader : IDisposable
	{

		/// <summary>
		/// 
		/// </summary>
		private Stream stream = null;

		
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="binaryReader"></param>
		public HiveReader(Stream stream)
		{
			this.stream = stream;
		}




		/// <summary>
		/// Read one page and return HeaderPage object
		/// </summary>
		/// <returns></returns>
		public HiveHeader ReadHeader()
		{
			HiveHeader result = null;
			
			try
			{
				// Set file pointer to the beginning
				this.stream.Seek(0, SeekOrigin.Begin);

				// Create buffer for header page
				byte[] headerBuffer = new byte[Structures.Size.HiveHeader];
				
				// Read header page into the buffer
				int readBytes = this.stream.Read(
					headerBuffer, 
					0, 
					Structures.Size.HiveHeader);

				if (readBytes == Structures.Size.HiveHeader)
				{
					result = new HiveHeader(headerBuffer);
				}
			}
			catch
			{

			}
			
			return result;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		public byte[] ReadRecord(uint offset)
		{
			// Allocate buffer for record header
			byte[] recordHeader = new byte[Structures.Size.RecordHeader];

			// Go to the beginning of record within the stream
			this.stream.Seek(Structures.Size.HiveHeader + offset, SeekOrigin.Begin);

			// Read record header into the buffer
			this.stream.Read(recordHeader, 0, Structures.Size.RecordHeader);

			// Create base record object
			HiveRecord record = new HiveRecord(recordHeader);

			// Allocate memory for record data
			byte[] recordBuffer = new byte[record.Size];

			// Copy header into record data buffer
			recordHeader.CopyTo(recordBuffer, 0);

			// Read record body into the buffer
			this.stream.Read(
				recordBuffer,
				Structures.Size.RecordHeader,
				record.Size - Structures.Size.RecordHeader);

			
			return recordBuffer;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="recordOffset"></param>
		/// <returns></returns>
		public HiveRecord GetRecord(uint offset)
		{
			HiveRecord result = null;

			byte[] recordBuffer = ReadRecord(offset);

			if (recordBuffer != null
				&& recordBuffer.Length > Structures.Size.RecordHeader + sizeof(UInt16))
			{
				// Get type of the record
				Int16 type = BitConverter.ToInt16(
					recordBuffer, 
					Structures.Size.RecordHeader);

				switch (type)
				{
					case Structures.KeyRecordType.nk:
						result = new KeyRecord(recordBuffer);
						break;

					case Structures.KeyRecordType.vk:
						result = new ValueRecord(recordBuffer);
						break;

					case Structures.KeyRecordType.lh:
					case Structures.KeyRecordType.lf:
						result = new SubKeyListRecord(recordBuffer);
						break;
				}
			}

			return result;
		}





		/// <summary>
		/// This is called when object is released
		/// </summary>
		public void Dispose()
		{
			
		}
	}
}
