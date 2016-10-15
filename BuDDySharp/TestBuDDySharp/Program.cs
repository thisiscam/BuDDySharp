using System;
using BuDDySharp;
using System.Runtime.InteropServices;

namespace BuDDySharp.Test
{
	class MainClass
	{
		public unsafe static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			BuDDySharp.cpp_init (1000, 1000);
			BuDDySharp.setvarnum (100);
			var t = BuDDySharp.bvec_true(12);
			var f = BuDDySharp.bvec_map1 (t, test);
			BuDDySharp.bvec_map2 (f, t, (a, b) => {
				var tmp = a.Or(b);
				Console.WriteLine(tmp.EqualEqual(BuDDySharp.bddtrue));	
				return tmp;
			});

			// GC test
			var x = BuDDySharp.bddfalse;
			while (true) {
				x = x.Or(BuDDySharp.ithvar(11));
			}
		}
		public static bdd test(bdd x) {
			BuDDySharp.printdot (x);
			return x.And (BuDDySharp.bddfalse);
		}
	}
}
