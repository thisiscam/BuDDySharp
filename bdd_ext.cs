namespace buddysharp {
	public delegate void bddinthandler(int arg0);
	public delegate void bddgbchandler(int arg0, SWIGTYPE_p_f_int_p_struct_s_bddGbcStat__void arg1);
	public delegate void bdd2inthandler(int arg0, int arg1);
	public delegate int  bddsizehandler();
	public delegate void bddfilehandler(SWIGTYPE_p_f_p_FILE_int__void arg0, int arg1);
	public delegate void bddallsathandler(SWIGTYPE_p_f_p_char_int__void arg0, int arg1);

	public partial class bdd {
		static event bddinthandler bdd_error_handler;
		static event bddgbchandler bdd_gbc_handler;
		static event bdd2inthandler bdd_resize_handler;
		static event bddinthandler bdd_reorder_handler;
		static event bddfilehandler bdd_file_handler;
		static event bddfilehandler bdd_blockfile_handler;

		static bdd() {
			bdd_error_hook (bdd_error_handler);
			bdd_gbc_hook (bdd_gbc_handler);
			bdd_resize_hook (bdd_resize_handler);
			bdd_reorder_hook (bdd_reorder_handler);
			bdd_file_hook (bdd_file_handler);
			bdd_blockfile_hook (bdd_blockfile_handler);
		}
	}
}