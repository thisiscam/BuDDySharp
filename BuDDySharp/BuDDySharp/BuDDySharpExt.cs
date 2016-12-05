using System;
using System.Runtime.InteropServices;
using System.Security;
using BDD = System.Int32;

namespace BuDDySharp
{
	public partial class BuDDySharp
	{
		const string EXT_DLL_NAME = "buddysharp_extension";

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "free_void")]
		public static extern void free_void(IntPtr handler);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_low_addref")]
		public static extern BDD bdd_low_addref(BDD root);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_high_addref")]
		public static extern BDD bdd_high_addref(BDD root);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_addref_addref")]
		public static extern BDD bdd_addref_addref(BDD root);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_delref_addref")]
		public static extern BDD bdd_delref_addref(BDD root);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_makeset_addref")]
		public static extern BDD bdd_makeset_addref(int[] varset, int varnum);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_buildcube_addref")]
		public static extern BDD bdd_buildcube_addref(int value, int width, BDD[] vars);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_ibuildcube_addref")]
		public static extern BDD bdd_ibuildcube_addref(int value, int width, int[] vars);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_not_addref")]
		public static extern BDD bdd_not_addref(BDD r);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_apply_addref")]
		public static extern BDD bdd_apply_addref(BDD left, BDD right, bddop op);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_and_addref")]
		public static extern BDD bdd_and_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_or_addref")]
		public static extern BDD bdd_or_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_xor_addref")]
		public static extern BDD bdd_xor_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_imp_addref")]
		public static extern BDD bdd_imp_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_biimp_addref")]
		public static extern BDD bdd_biimp_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_ite_addref")]
		public static extern BDD bdd_ite_addref(BDD f, BDD g, BDD h);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_restrict_addref")]
		public static extern BDD bdd_restrict_addref(BDD left, BDD right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_constrain_addref")]
		public static extern BDD bdd_constrain_addref(BDD left, BDD right);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_compose_addref")]
		public static extern BDD bdd_compose_addref(BDD f, BDD g, int var);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_simplify_addref")]
		public static extern BDD bdd_simplify_addref(BDD left, BDD right);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_exist_addref")]
		public static extern BDD bdd_exist_addref(BDD left, BDD right);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_forall_addref")]
		public static extern BDD bdd_forall_addref(BDD left, BDD right);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_unique_addref")]
		public static extern BDD bdd_unique_addref(BDD left, BDD right);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_appex_addref")]
		public static extern BDD bdd_appex_addref(BDD left, BDD right, int op, BDD var);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_appall_addref")]
		public static extern BDD bdd_appall_addref(BDD left, BDD right, int op, BDD var);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_appuni_addref")]
		public static extern BDD bdd_appuni_addref(BDD left, BDD right, int op, BDD var);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_support_addref")]
		public static extern BDD bdd_support_addref(BDD r);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_satone_addref")]
		public static extern BDD bdd_satone_addref(BDD r);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_satoneset_addref")]
		public static extern BDD bdd_satoneset_addref(BDD r, BDD var, BDD pol);
		
		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bdd_fullsatone_addref")]
		public static extern BDD bdd_fullsatone_addref(BDD r);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_copy_addref")]
		public static extern BVEC bvec_copy_addref(BVEC v);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_con_addref")]
		public static extern BVEC bvec_con_addref(int bitnum, int val);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_var_addref")]
		public static extern BVEC bvec_var_addref(int bitnum, int offset, int step);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_varfdd_addref")]
		public static extern BVEC bvec_varfdd_addref(int var);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_varvec_addref")]
		public static extern BVEC bvec_varvec_addref(int bitnum, int[] vars);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_coerce_addref")]
		public static extern BVEC bvec_coerce_addref(int bitnum, BVEC v);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_addref_addref")]
		public static extern BVEC bvec_addref_addref(BVEC v);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_delref_addref")]
		public static extern BVEC bvec_delref_addref(BVEC v);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_add_addref")]
		public static extern BVEC bvec_add_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_sub_addref")]
		public static extern BVEC bvec_sub_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_mulfixed_addref")]
		public static extern BVEC bvec_mulfixed_addref(BVEC e, int c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_mul_addref")]
		public static extern BVEC bvec_mul_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_ite_addref")]
		public static extern BVEC bvec_ite_addref(BDD a, BVEC b, BVEC c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_shlfixed_addref")]
		public static extern BVEC bvec_shlfixed_addref(BVEC e, int pos, BDD c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_shl_addref")]
		public static extern BVEC bvec_shl_addref(BVEC l, BVEC r, BDD c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_shrfixed_addref")]
		public static extern BVEC bvec_shrfixed_addref(BVEC e, int pos, BDD c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_shr_addref")]
		public static extern BVEC bvec_shr_addref(BVEC l, BVEC r, BDD c);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_lth_addref")]
		public static extern BDD bvec_lth_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_lte_addref")]
		public static extern BDD bvec_lte_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_gth_addref")]
		public static extern BDD bvec_gth_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_gte_addref")]
		public static extern BDD bvec_gte_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_equ_addref")]
		public static extern BDD bvec_equ_addref(BVEC left, BVEC right);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(EXT_DLL_NAME, EntryPoint = "bvec_neq_addref")]
		public static extern BDD bvec_neq_addref(BVEC left, BVEC right);

	}
}
