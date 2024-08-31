using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using Registry.IO;
using Registry.Parser;

namespace Reader
{
	class Program
	{

		static int ident = 0;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		static void EnumRegistry(NTRegistryKey key)
		{
			int subKeyCount = key.SubKeyCount;
			int subKeyIndex = 0;

			for (int i = 0; i < ident; i++)
			{
				Console.Write("\t");
			}

			Console.WriteLine(key.Name);

			for (; subKeyIndex < subKeyCount; subKeyIndex++)
			{
				NTRegistryKey subKey = key.GetSubKey(subKeyIndex);

				if (subKey != null)
				{
					ident++;
					EnumRegistry(subKey);
					ident--;
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{			

			using (Stream stream = new FileStream(args[0], FileMode.Open))
			{
				using (NTRegistryTree registry = new NTRegistryTree(stream))
				{
					NTRegistryKey root = registry.GetRootKey();

					//Console.WriteLine(root["Select"].Values);
					EnumRegistry(root);
					
				}
			}
							
			
		}


	}
}
