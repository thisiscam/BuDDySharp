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
			//var t = BuDDySharp.bvec_true(12);
			//var f = BuDDySharp.bvec_map1 (t, test);
			//BuDDySharp.bvec_map2 (f, t, (a, b) => {
			//	var tmp = a.Or(b);
			//	Console.WriteLine(tmp.EqualEqual(BuDDySharp.bddtrue));	
			//	return tmp;
			//});

#if TEST_PURE_BOOL
			// Starts with a free set of variables
			bdd v_50 = BuDDySharp.mark_ithvar_npure_bool(50);
			bdd v_51 = BuDDySharp.mark_ithvar_npure_bool(51);
			bdd v_52 = BuDDySharp.ithvar(52);
			bdd v_53 = BuDDySharp.ithvar(53);
			
			check_npure_bool(BuDDySharp.bddtrue, false);
			check_npure_bool(BuDDySharp.bddtrue, false);
			check_npure_bool(v_50, true);
			check_npure_bool(v_52, false);
			check_npure_bool(v_50.And(BuDDySharp.bddtrue), true);
			check_npure_bool(v_52.And(BuDDySharp.bddtrue), false);
			
			check_npure_bool(v_50.And(v_51), true);
			check_npure_bool(v_50.Or(v_51), true);
			check_npure_bool(v_51.Or(v_51), true);
			check_npure_bool(v_50.Or(v_52), true);
			check_npure_bool(v_50.Or(v_52).And(v_51), true);
			check_npure_bool(v_52.And(v_53), false);
#endif

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

#if TEST_PURE_BOOL
		public static void check_npure_bool(bdd x, bool is_pure_bool) {
			if(!BuDDySharp.not_pure_bool(x) == is_pure_bool)
			{
				throw new Exception("Failed");	
			}
		}
	}
#endif
}
