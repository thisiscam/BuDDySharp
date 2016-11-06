#include <stdlib.h>

#include "bdd.h"
#include "bvec.h"

void free_void(void* arg0) {
	free(arg0);
}

/* bdd addrefs */
BDD bdd_low_addref(BDD root)
   { return bdd_addref(bdd_low(root)); }
BDD bdd_high_addref(BDD root)
   { return bdd_addref(bdd_high(root)); }
BDD bdd_addref_addref(BDD root)
   { return bdd_addref(bdd_addref(root)); }
BDD bdd_delref_addref(BDD root)
   { return bdd_addref(bdd_delref(root)); }
BDD bdd_makeset_addref(int *varset, int varnum)
   { return bdd_addref(bdd_makeset(varset, varnum)); }
BDD bdd_buildcube_addref(int value, int width, BDD *vars)
   { return bdd_addref(bdd_buildcube(value, width, vars)); }
BDD bdd_ibuildcube_addref(int value, int width, int *vars)
   { return bdd_addref(bdd_ibuildcube(value, width, vars)); }
BDD bdd_not_addref(BDD r)
   { return bdd_addref(bdd_not(r)); }
BDD bdd_apply_addref(BDD left, BDD right, int op)
   { return bdd_addref(bdd_apply(left, right, op)); }
BDD bdd_and_addref(BDD left, BDD right)
   { return bdd_addref(bdd_and(left, right)); }
BDD bdd_or_addref(BDD left, BDD right)
   { return bdd_addref(bdd_or(left, right)); }
BDD bdd_xor_addref(BDD left, BDD right)
   { return bdd_addref(bdd_xor(left, right)); }
BDD bdd_imp_addref(BDD left, BDD right)
   { return bdd_addref(bdd_imp(left, right)); }
BDD bdd_biimp_addref(BDD left, BDD right)
   { return bdd_addref(bdd_biimp(left, right)); }
BDD bdd_ite_addref(BDD f, BDD g, BDD h)
   { return bdd_addref(bdd_ite(f, g, h)); }
BDD bdd_restrict_addref(BDD left, BDD right)
   { return bdd_addref(bdd_restrict(left, right)); }
BDD bdd_constrain_addref(BDD left, BDD right)
   { return bdd_addref(bdd_constrain(left, right)); }
BDD bdd_replace_addref(BDD r, bddPair* pair)
   { return bdd_addref(bdd_replace(r, pair)); }
BDD bdd_compose_addref(BDD f, BDD g, int var)
   { return bdd_addref(bdd_compose(f, g, var)); }
BDD bdd_veccompose_addref(BDD f, bddPair* pair)
   { return bdd_addref(bdd_veccompose(f, pair)); }
BDD bdd_simplify_addref(BDD left, BDD right)
   { return bdd_addref(bdd_simplify(left, right)); }
BDD bdd_exist_addref(BDD left, BDD right)
   { return bdd_addref(bdd_exist(left, right)); }
BDD bdd_forall_addref(BDD left, BDD right)
   { return bdd_addref(bdd_forall(left, right)); }
BDD bdd_unique_addref(BDD left, BDD right)
   { return bdd_addref(bdd_unique(left, right)); }
BDD bdd_appex_addref(BDD left, BDD right, int op, BDD var)
   { return bdd_addref(bdd_appex(left, right, op, var)); }
BDD bdd_appall_addref(BDD left, BDD right, int op, BDD var)
   { return bdd_addref(bdd_appall(left, right, op, var)); }
BDD bdd_appuni_addref(BDD left, BDD right, int op, BDD var)
   { return bdd_addref(bdd_appuni(left, right, op, var)); }
BDD bdd_support_addref(BDD r)
   { return bdd_addref(bdd_support(r)); }
BDD bdd_satone_addref(BDD r)
   { return bdd_addref(bdd_satone(r)); }
BDD bdd_satoneset_addref(BDD r, BDD var, BDD pol)
   { return bdd_addref(bdd_satoneset(r, var, pol)); }
BDD bdd_fullsatone_addref(BDD r)
   { return bdd_addref(bdd_fullsatone(r)); }

int* bdd_varprofile_csharp(BDD r, int* numvars) {
   *numvars = bdd_varnum();
   return bdd_varprofile(r);
}
/* end bdd addref */

/* bvec addrefs */
BVEC bvec_copy_addref(BVEC v) {
   return bvec_addref(bvec_copy(v));
}
BVEC bvec_con_addref(int bitnum, int val) {
   return bvec_addref(bvec_con(bitnum, val));
}
BVEC bvec_var_addref(int bitnum, int offset, int step) {
   return bvec_addref(bvec_var(bitnum, offset, step));
}
BVEC bvec_varfdd_addref(int var) {
   return bvec_addref(bvec_varfdd(var));
}
BVEC bvec_varvec_addref(int bitnum, int *vars) {
   return bvec_addref(bvec_varvec(bitnum, vars));
}
BVEC bvec_coerce_addref(int bitnum, BVEC v) {
   return bvec_addref(bvec_coerce(bitnum, v));
}
BVEC bvec_addref_addref(BVEC v) {
   return bvec_addref(bvec_addref(v));
}
BVEC bvec_delref_addref(BVEC v) {
   return bvec_addref(bvec_delref(v));
}
BVEC bvec_add_addref(BVEC left, BVEC right) {
   return bvec_addref(bvec_add(left, right));
}
BVEC bvec_sub_addref(BVEC left, BVEC right) {
   return bvec_addref(bvec_sub(left, right));
}
BVEC bvec_mulfixed_addref(BVEC e, int c) {
   return bvec_addref(bvec_mulfixed(e, c));
}
BVEC bvec_mul_addref(BVEC left, BVEC right) {
   return bvec_addref(bvec_mul(left, right));
}
BVEC bvec_ite_addref(BDD a, BVEC b, BVEC c) {
   return bvec_addref(bvec_ite(a, b, c));
}
BVEC bvec_shlfixed_addref(BVEC e, int pos, BDD c) {
   return bvec_addref(bvec_shlfixed(e, pos, c));
}
BVEC bvec_shl_addref(BVEC l, BVEC r, BDD c) {
   return bvec_addref(bvec_shl(l, r, c));
}
BVEC bvec_shrfixed_addref(BVEC e, int pos, BDD c) {
   return bvec_addref(bvec_shrfixed(e, pos, c));
}
BVEC bvec_shr_addref(BVEC l, BVEC r, BDD c) {
   return bvec_addref(bvec_shr(l, r, c));
}
BDD  bvec_lth_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_lth(left, right));
}
BDD  bvec_lte_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_lte(left, right));
}
BDD  bvec_gth_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_gth(left, right));
}
BDD  bvec_gte_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_gte(left, right));
}
BDD  bvec_equ_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_equ(left, right));
}
BDD  bvec_neq_addref(BVEC left, BVEC right) {
   return bdd_addref( bvec_neq(left, right));
}
/*end bvec addref */