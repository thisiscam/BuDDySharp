using System;
using System.Runtime.InteropServices;
using System.Security;
using BDD = System.Int32;
using BDDVAR = System.Int32;

namespace BuDDySharp
{	
	public static partial class BuDDySharp
	{	
		public delegate void bddinthandler(int arg0);
	    public unsafe delegate void bddgbchandler(int arg0, bddGbcStat* arg1);
		public delegate void bdd2inthandler(int arg0, int arg1);
		public delegate int bddsizehandler();
		public unsafe delegate void bddallsathandler(char* arg0, int arg1);

		const string DLL_NAME = "buddysharp_extension";
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_error_hook")]
		public static extern bddinthandler error_hook(bddinthandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_gbc_hook")]
		public static extern bddgbchandler gbc_hook(bddgbchandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_resize_hook")]
		public static extern bdd2inthandler resize_hook(bdd2inthandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_reorder_hook")]
		public static extern bddinthandler reorder_hook(bddinthandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_init")]
		public static extern int init(int arg0, int arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_done")]
		public static extern void done();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setvarnum")]
		public static extern int setvarnum(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_extvarnum")]
		public static extern int extvarnum(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_isrunning")]
		public static extern int isrunning();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setmaxnodenum")]
		public static extern int setmaxnodenum(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setmaxincrease")]
		public static extern int setmaxincrease(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setminfreenodes")]
		public static extern int setminfreenodes(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_getnodenum")]
		public static extern int getnodenum();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_getallocnum")]
		public static extern int getallocnum();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_getallocnum")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string versionstr();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_versionnum")]
		public static extern int versionnum();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_stats")]
		public static extern void stats(ref bddStat arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_cachestats")]
		public static extern void cachestats(ref bddCacheStat arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fnprintstat")]
		public static extern void fnprintstat(string filename);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printstat")]
		public static extern void printstat();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_default_gbchandler")]
		public unsafe static extern void default_gbchandler(int arg0, bddGbcStat* arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_default_errhandler")]
		public static extern void default_errhandler(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_clear_error")]
		public static extern void clear_error();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_true")]
		public static extern BDD _true();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_false")]
		public static extern BDD _false();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_varnum")]
		public static extern int varnum();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_ithvar")]
		public static extern BDD ithvar(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_nithvar")]
		public static extern BDD nithvar(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_var")]
		public static extern BDDVAR var(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_mark_ithvar_npure_bool")]
		public static extern BDD mark_ithvar_npure_bool(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_not_pure_bool")]
		public static extern bool not_pure_bool(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_low")]
		public static extern BDD low(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_high")]
		public static extern BDD high(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_varlevel")]
		public static extern int varlevel(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_addref")]
		public static extern BDD addref(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_delref")]
		public static extern BDD delref(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_gbc")]
		public static extern void gbc();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_scanset")]
		public static extern int _scanset(BDD arg0, ref IntPtr arg1, ref int arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_makeset")]
		public static extern BDD makeset(int[] arg0, int arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setcacheratio")]
		public static extern int setcacheratio(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_buildcube")]
		public static extern BDD buildcube(int arg0, int arg1, BDD[] arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_ibuildcube")]
		public static extern BDD ibuildcube(int arg0, int arg1, int[] arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_not")]
		public static extern BDD not(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_apply")]
		public static extern BDD apply(BDD arg0, BDD arg1, bddop arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_and")]
		public static extern BDD and(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_or")]
		public static extern BDD or(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_xor")]
		public static extern BDD xor(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_imp")]
		public static extern BDD imp(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_biimp")]
		public static extern BDD biimp(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_ite")]
		public static extern BDD ite(BDD arg0, BDD arg1, BDD arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_restrict")]
		public static extern BDD restrict(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_constrain")]
		public static extern BDD constrain(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_compose")]
		public static extern BDD compose(BDD arg0, BDD arg1, BDD arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_simplify")]
		public static extern BDD simplify(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_exist")]
		public static extern BDD exist(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_forall")]
		public static extern BDD forall(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_unique")]
		public static extern BDD unique(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_appex")]
		public static extern BDD appex(BDD arg0, BDD arg1, int arg2, BDD arg3);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_appall")]
		public static extern BDD appall(BDD arg0, BDD arg1, int arg2, BDD arg3);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_appuni")]
		public static extern BDD appuni(BDD arg0, BDD arg1, int arg2, BDD arg3);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_support")]
		public static extern BDD support(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satone")]
		public static extern BDD satone(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satoneset")]
		public static extern BDD satoneset(BDD arg0, BDD arg1, BDD arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fullsatone")]
		public static extern BDD fullsatone(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_allsat")]
		public static extern void allsat(BDD r, bddallsathandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satcount")]
		public static extern double satcount(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satcountset")]
		public static extern double satcountset(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satcountln")]
		public static extern double satcountln(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_satcountlnset")]
		public static extern double satcountlnset(BDD arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_nodecount")]
		public static extern int nodecount(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_anodecount")]
		public static extern int anodecount(BDD[] arg0, int arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_varprofile")]
		private static extern IntPtr _bdd_varprofile(BDD arg0);
		
		public static int[] varprofile(bdd r) {
            int size = varnum();
            IntPtr tmp = _bdd_varprofile(r.Id);
            int[] ret = new int[size];
            Marshal.Copy(tmp, ret, 0, size);
            free_void(tmp);
            return ret;
        }
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_pathcount")]
		public static extern double pathcount(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printall")]
		public static extern void printall();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fprintall")]
		public static extern void fprintall(string filename);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fprinttable")]
		public static extern void fprinttable(string filename, BDD b);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printtable")]
		public static extern void printtable(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fprintset")]
		public static extern void fprintset(string arg0, BDD arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printset")]
		public static extern void printset(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fnprintdot")]
		public static extern int fnprintdot(string filename, BDD b);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printdot")]
		public static extern void printdot(BDD arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fnsave")]
		public static extern int fnsave(string filename, BDD b);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fnload")]
		public static extern int fnload(string filename, ref BDD b);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_swapvar")]
		public static extern int swapvar(int v1, int v2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_default_reohandler")]
		public static extern void default_reohandler(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_reorder")]
		public static extern void reorder(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_reorder_gain")]
		public static extern int reorder_gain();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_reorder_probe")]
		public static extern bddsizehandler reorder_probe(bddsizehandler handler);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_clrvarblocks")]
		public static extern void clrvarblocks();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_addvarblock")]
		public static extern int addvarblock(BDD arg0, int arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_intaddvarblock")]
		public static extern int intaddvarblock(int arg0, int arg1, int arg2);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_varblockall")]
		public static extern void varblockall();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_autoreorder")]
		public static extern int autoreorder(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_autoreorder_times")]
		public static extern int autoreorder_times(int arg0, int arg1);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_getreorder_times")]
		public static extern int getreorder_times();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_getreorder_method")]
		public static extern int getreorder_method();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_enable_reorder")]
		public static extern void enable_reorder();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_disable_reorder")]
		public static extern void disable_reorder();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_reorder_verbose")]
		public static extern int reorder_verbose(int arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_setvarorder")]
		public static extern void setvarorder(int[] arg0);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_printorder")]
		public static extern void printorder();
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bdd_fnprintorder")]
		public static extern void fnprintorder(string filename);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_copy")]
		public static extern BVEC bvec_copy(BVEC v);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_true")]
		public static extern BVEC bvec_true(int bitnum);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_false")]
		public static extern BVEC bvec_false(int bitnum);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_con")]
		public static extern BVEC bvec_con(int bitnum, int val);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_var")]
		public static extern BVEC bvec_var(int bitnum, int offset, int step);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_varfdd")]
		public static extern BVEC bvec_varfdd(int var);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_varvec")]
		public static extern BVEC bvec_varvec(int bitnum, int[] var);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_coerce")]
		public static extern BVEC bvec_coerce(int bitnum, BVEC v);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_isconst")]
		public static extern int bvec_isconst(BVEC e);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_val")]
		public static extern int bvec_val(BVEC e);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_free")]
		public static extern void bvec_free(BVEC v);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_addref")]
		public static extern BVEC bvec_addref(BVEC v);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_delref")]
		public static extern BVEC bvec_delref(BVEC v);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_add")]
		public static extern BVEC bvec_add(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_sub")]
		public static extern BVEC bvec_sub(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_mulfixed")]
		public static extern BVEC bvec_mulfixed(BVEC e, int c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_mul")]
		public static extern BVEC bvec_mul(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_divfixed")]
		public unsafe static extern int bvec_divfixed(BVEC e, int c, BVEC* res, BVEC* rem);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_div")]
		public unsafe static extern int bvec_div(BVEC left, BVEC right, BVEC* res, BVEC* rem);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_ite")]
		public static extern BVEC bvec_ite(BDD a, BVEC b, BVEC c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_shlfixed")]
		public static extern BVEC bvec_shlfixed(BVEC e, int pos, BDD c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_shl")]
		public static extern BVEC bvec_shl(BVEC l, BVEC r, BDD c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_shrfixed")]
		public static extern BVEC bvec_shrfixed(BVEC e, int pos, BDD c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_shr")]
		public static extern BVEC bvec_shr(BVEC l, BVEC r, BDD c);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_lth")]
		public static extern BDD bvec_lth(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_lte")]
		public static extern BDD bvec_lte(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_gth")]
		public static extern BDD bvec_gth(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_gte")]
		public static extern BDD bvec_gte(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_equ")]
		public static extern BDD bvec_equ(BVEC left, BVEC right);
		
		[SuppressUnmanagedCodeSecurity]		
		[DllImport(DLL_NAME, EntryPoint="bvec_neq")]
		public static extern BDD bvec_neq(BVEC left, BVEC right);
	}
}
