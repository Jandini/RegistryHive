//=============================================================================
// Module name : Structure.cs
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
	/// Structure
	/// </summary>
	public class HiveIO
	{
		
		/// <summary>
		/// Creates new structure of given type. 
		/// Structure is filled with data from byte array.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static object ByteArrayToStructure(byte[] data, Type type)
		{			
			return HiveIO.ByteArrayToStructure(data, type, 0);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="type"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public static object ByteArrayToStructure(byte[] data, Type type, int offset)
		{
			object result = null;

			int dataSize = Marshal.SizeOf(type);

			if (dataSize <= data.Length)
			{
				IntPtr buffer = Marshal.AllocHGlobal(dataSize);
				Marshal.Copy(data, offset, buffer, dataSize);

				result = Marshal.PtrToStructure(buffer, type);
				Marshal.FreeHGlobal(buffer);
			}

			
			return result;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="index"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public static string GetStringAnsi(byte[] buffer, int index, int len)
		{
			IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, index);

			return Marshal.PtrToStringAnsi(ptr, len);
		}
	}
}
