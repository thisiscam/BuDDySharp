using System;
using System.Runtime.InteropServices;

namespace BuDDySharp
{
	public partial class BuDDySharp
	{
		const string EXTENSION_DLL_NAME = "buddysharp_extension";
		
		[DllImport(EXTENSION_DLL_NAME, EntryPoint="free_void")]
		public static extern void free_void(IntPtr handler);
	}
}
