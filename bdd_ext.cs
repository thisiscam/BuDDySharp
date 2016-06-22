namespace buddysharp {
	// public delegate void bddinthandler(int arg0);
	// public delegate void bddgbchandler(int arg0, global::System.Runtime.InteropServices.HandleRef arg1);
	// public delegate void bdd2inthandler(int arg0, int arg1);
	// public delegate int  bddsizehandler();
	public delegate void bddallsathandler(string arg0, int arg1);

	// public partial class bdd {
	// 	static event bddinthandler bdd_error_handler;
	// 	static event bddgbchandler bdd_gbc_handler;
	// 	static event bdd2inthandler bdd_resize_handler;
	// 	static event bddinthandler bdd_reorder_handler;

	// 	static bdd() {
	// 		bdd_error_hook (bdd_error_handler);
	// 		bdd_gbc_hook (bdd_gbc_handler);
	// 		bdd_resize_hook (bdd_resize_handler);
	// 		bdd_reorder_hook (bdd_reorder_handler);
	// 	}

	// 	// public static int[] bdd_varprofile(int arg0) {
	// 	// 	global::System.IntPtr cPtr = bddPINVOKE.bdd_varprofile(arg0);
	// 	// 	SWIGTYPE_p_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_int(cPtr, false);
	// 	// 	return ret;
	// 	// }
	// }
}