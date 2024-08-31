//=============================================================================
// Module name : Structures.cs
// Tab size    : 3
// Engineer(s) : Matthew Janda
// Description : 
//
// ----------------------------------------------------------------------------
// 07/02/2009 - Added ValueEntry structure.
// 02/02/2009 - Added SubKeysRecord and SubKeyEntry structures.
// 21/10/2008 - Created.
//=============================================================================
using System;
using System.Runtime.InteropServices;


namespace Registry.IO.Structures
{

	/// <summary>
	/// Constant size of structures
	/// </summary>
	internal struct Size
	{
		/// <summary>
		/// Header page size has aways 4K
		/// </summary>
		public const int HiveHeader = 4096;

		/// <summary>
		/// 
		/// </summary>
		public const int RecordHeader = 4;

		/// <summary>
		/// 
		/// </summary>
		public const int SubKeyListHeader = 8;

		/// <summary>
		/// 
		/// </summary>
		public const int SubKeyListEntry = 8;


		/// <summary>
		/// 
		/// </summary>
		public const int ValueListEntry = 4;

	}



	/// <summary>
	/// List of record types
	/// </summary>
	internal struct KeyRecordType 
	{
		public const Int16 nk = 0x6B6E;
		public const Int16 vk = 0x6B76;
		public const Int16 lf = 0x666C;
		public const Int16 lh = 0x686C;
		public const Int16 sk = 0x6B73;
	}


	/// <summary>
	/// List of key levels
	/// </summary>
	internal struct KeyRecordLevel
	{
		public const Int16 Root = 0x002C;
		public const Int16 Node = 0x0020;
	}


	/// <summary>
	/// List of all types of values
	/// </summary>
	internal struct ValueRecordType
	{
		public const Int16 NONE									= 0;
		public const Int16 SZ									= 1;
		public const Int16 EXPAND_SZ							= 2;
		public const Int16 BINARY								= 3;
		public const Int16 DWORD								= 4;
		public const Int16 DWORD_BIG_ENDIAN					= 5;
		public const Int16 LINK									= 6;
		public const Int16 MULTI_SZ							= 7;
		public const Int16 RESOURCE_LIST						= 8;
		public const Int16 FULL_RESOURCE_DESCRIPTOR		= 9;
		public const Int16 RESOURCE_REQUIREMENTS_LIST	= 10;
	}

	


	/// <summary>
	/// Hive header block
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct HiveHeaderStructure
	{
		public UInt32	Signature;

		public UInt32	Unknown_1;
		public UInt32	Unknown_2;

		public UInt64	LastModified;

		public UInt32	VersionMajor;
		public UInt32	VersionMinor;
		public UInt32	VersionBuild;
		public UInt32	VersionPart;

		public UInt32	RootKeyOffset;
		public UInt32	DataPagesSize;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4052)]
		public byte[]	Pad;
	}

	


	/// <summary>
	/// Common record header
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct RecordHeaderStructure
	{
		public Int32 Size;		
	}



	/// <summary>
	/// Registry key node record structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct KeyStructure
	{
		public RecordHeaderStructure	Header;
		public Int16 Type;

		/// <summary>
		/// 0x002C - root key, 0x0020 - node key
		/// </summary>
		public UInt16	KeyLevel;
		public UInt64	LastModified;

		public Int32	Pad_0;
	
		public Int32	ParentOffset;
		public Int32	SubKeyCount;
	
		/// <summary>
		/// 0x00
		/// </summary>
		public Int32	Pad_1;						
	
		public Int32	SubKeyListOffset;
	
		/// <summary>
		/// 0xffffffff  almost always
		/// </summary>
		public Int32	Pad_2;							
	
		public Int32	ValueCount;
		public Int32	ValueListOffset;
		public Int32	OffsetToSKrecord;

		/// <summary>
		/// Can be -1 when no classname is specified
		/// </summary>
		public Int32	OffsetToClassName;
		public Int32	LongestSubkeySizex2;
		public Int32	LongestClassSizex2;
		public Int32	LongestVNameSizex2;
		public Int32	LongestValueSizex2;
		public Int32	UnknownIndex;
	
		public Int16	NameLength;

		/// <summary>
		/// 0 if offset -1
		/// </summary>
		public Int16	ClassNameLength;		

	} 
	


	/// <summary>
	/// Value record disk structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ValueStructure
	{  
		public RecordHeaderStructure	Header;
		
		public UInt16	Type;
		public Int16	NameLength;

		/// <summary>
		/// top bit set indicates data in place in DataOffset
		/// </summary>
		public UInt32	DataLength;
		public Int32	DataOffset;
		public Int32	ValueType; 

		/// <summary>
		/// bit 0 indicates a name is present. Otherwise default
		/// </summary>
		public Int16	Flag;				
		public Int16	Unused;

	} 


	/// <summary>
	/// SubKeys records record 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct SubKeyListStructure
	{
		public RecordHeaderStructure Header;

		public UInt16 Type;
		public UInt16 SubKeyCount;
	}


	/// <summary>
	/// SubKeys records record 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct SubKeyListEntryStructure
	{
		public UInt32 KeyOffset;
		public UInt32 KeyHash;
	}


	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ValueListEntryStructure
	{
		public Int32 ValueOffset;
	}

}
