%define %cs_callback(TYPE, CSTYPE) 
        %typemap(ctype) TYPE, TYPE& "void*" 
        %typemap(in) TYPE  %{ $1 = (TYPE)$input; %} 
        %typemap(in) TYPE& %{ $1 = (TYPE*)&$input; %} 
        %typemap(imtype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(cstype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(csin) TYPE, TYPE& "$csinput" 
%enddef 

%module BuDDySharp
%{
	#include "bdd.h"
   typedef bdd* (*bvecmapfun1)(const bdd *);
   typedef bdd* (*bvecmapfun2)(const bdd *left, const bdd *right);
   typedef bdd* (*bvecmapfun3)(const bdd *, const bdd *, const bdd *);
   #include "kernel.h"
   #include "bvec.h"
%}

%include arrays_csharp.i
%include typemaps.i
%include cmalloc.i

%apply void *VOID_INT_PTR { void * }
%csmethodmodifiers free(void*) "protected"
%free(void)

%cs_callback(bddinthandler, bddinthandler)
%cs_callback(bddgbchandler, bddgbchandler)
%cs_callback(bdd2inthandler, bdd2inthandler)
%cs_callback(bddsizehandler, bddsizehandler)
%cs_callback(bddallsathandler, bddallsathandler)
%cs_callback(bvecmapfun1, bvecmapfun1)
%cs_callback(bvecmapfun2, bvecmapfun2)
%cs_callback(bvecmapfun3, bvecmapfun3)

%typemap(imtype, out="System.IntPtr") bddallsathandler, bddallsathandler& "bddallsathandler_wrapped" 
%typemap(csin) bddallsathandler, bddallsathandler& "bddallsathandler_wrapper($csinput)" 

%define %return_int_array(FN_NAME)
   %typemap(imtype) int *numvars "ref int"
   %typemap(csin) int *numvars "ref $csinput" 
   %typemap(cstype) int* FN_NAME() "IntPtr"
   %typemap(cstype) int *numvars "ref int"
   %typemap(csout, excode=SWIGEXCODE) int* FN_NAME %{{
         IntPtr ret = $imcall;$excode
         return ret;
      }%}
   %csmethodmodifiers FN_NAME "protected"
%enddef

%return_int_array(bdd_varprofile_csharp)
%return_int_array(fdd_scanallvar_csharp)

%typemap(imtype) int*& varset "ref global::System.IntPtr"
%typemap(csin) int*& varset "ref $csinput" 
%typemap(cstype) int*& varset "ref IntPtr"
%typemap(imtype) int &varnum "ref int"
%typemap(csin) int &varnum "ref $csinput" 
%typemap(cstype) int &varnum "ref int"
%csmethodmodifiers bdd_scanset "protected"

%rename(Equal) operator =;
%rename(PlusEqual) operator +=;
%rename(MinusEqual) operator -=;
%rename(MultiplyEqual) operator *=;
%rename(DivideEqual) operator /=;
%rename(PercentEqual) operator %=;
%rename(Plus) operator +;
%rename(Minus) operator -;
%rename(Multiply) operator *;
%rename(Divide) operator /;
%rename(Percent) operator %;
%rename(Not) operator !;
%rename(IndexIntoConst) operator[](int) const;
%rename(IndexInto) operator[](int);
%rename(Functor) operator ();
%rename(EqualEqual) operator ==;
%rename(NotEqual) operator !=;
%rename(LessThan) operator <;
%rename(LessThanEqual) operator <=;
%rename(GreaterThan) operator >;
%rename(GreaterThanEqual) operator >=;
%rename(And) operator &&;
%rename(Or) operator ||;
%rename(PlusPlusPrefix) operator++();
%rename(PlusPlusPostfix) operator++(int);
%rename(MinusMinusPrefix) operator--();
%rename(MinusMinusPostfix) operator--(int);
%rename(And) operator&;
%rename(AndEqual) operator&=;
%rename(Or) operator|;
%rename(OrEqual) operator|=;
%rename(Xor) operator^;
%rename(XorEqual) operator^=;
%rename(RightShift) operator>>;
%rename(RightShiftEqual) operator>>=;
%rename(LeftShift) operator<<;
%rename(LeftShiftEqual) operator<<=;
%rename(bvector) bvec; 

%pragma(csharp) moduleimports= %{
using System;
using System.Runtime.InteropServices;
%}

%pragma(csharp) moduleclassmodifiers = "public partial class"
%pragma(csharp) imclassclassmodifiers="[System.Security.SuppressUnmanagedCodeSecurity]\nclass"

%csmethodmodifiers bdd_makesetpp "public unsafe";
%csmethodmodifiers bdd_setpairs "public unsafe";
%csmethodmodifiers bdd_setbddpairs "public unsafe";
%csmethodmodifiers bdd_buildcube "public unsafe";
%csmethodmodifiers bdd_ibuildcubepp "public unsafe";
%csmethodmodifiers bdd_anodecount "public unsafe";
%csmethodmodifiers bdd_fnload "public unsafe";
%csmethodmodifiers bdd_setvarorder "public unsafe";
%csmethodmodifiers fdd_makesetpp "public unsafe";
%csmethodmodifiers bvec_varvecpp "public unsafe";

typedef int BDD;

typedef struct s_bddPair
{
   BDD *result;
   int last;
   int id;
   struct s_bddPair *next;
} bddPair;

typedef struct s_bddStat
{
   long int produced;
   int nodenum;
   int maxnodenum;
   int freenodes;
   int minfreenodes;
   int varnum;
   int cachesize;
   int gbcnum;
} bddStat;

typedef void (*bddallsathandler)(char*, int);

%apply int FIXED[] {
   int *varset,
   int *newvars, 
   int *oldvars, 
   int *vars, int *variables,
   int *neworder,
   int *roots
}

%define %can_throw_exception(FN_SIGNATURE)
   %typemap(cstype) int FN_SIGNATURE "void"
   %typemap(csout, excode=SWIGEXCODE) int FN_SIGNATURE %{{
      int ret = $imcall;$excode
      if(ret != 0) {
         throw new BDDException(ret);
      }
   }%}
%enddef
%define %can_throw_errorcode(FN_SIGNATURE)
   %typemap(csout, excode=SWIGEXCODE) int FN_SIGNATURE %{{
      int ret = $imcall;$excode
      if(ret < 0) {
         throw new BDDException(ret);
      }
      return ret;
   }%}
%enddef

%can_throw_exception(bdd_cpp_init)
%can_throw_exception(bdd_setvarnum)
%can_throw_errorcode(bdd_extvarnum)
%can_throw_errorcode(bdd_setmaxnodenum)
%can_throw_errorcode(bdd_setmaxincrease)
%can_throw_errorcode(bdd_setminfreenodes)
%can_throw_exception(bdd_scanset)
%can_throw_exception(bdd_setpair)
%can_throw_exception(bdd_setpairs)
%can_throw_exception(bdd_setbddpair)
%can_throw_exception(bdd_setbddpairs)
%can_throw_errorcode(bdd_setcacheratio)
%can_throw_exception(bdd_fnprintdot)
%can_throw_exception(bdd_fnsave)
%can_throw_exception(bdd_fnload)
%can_throw_exception(bdd_swapvar)
%can_throw_errorcode(bdd_addvarblock)
%can_throw_errorcode(bdd_intaddvarblock)

%rename("%(regex:/bdd_(([^_]|_(?!csharp))*)_csharp$/\\1/)s", fullname=1) "";
%rename("%(regex:/bdd_(([^_]|_(?!pp))*)pp$/\\1/)s", fullname=1) "";
%rename("%(regex:/bdd_(([^_p]|[_](?!csharp$)|[p](?!p$))*)/\\1/)s", fullname=1) "";
%rename("%(regex:/(fdd_([^_]|_(?!csharp))*)_csharp$/\\1/)s", fullname=1) "";
%rename("%(regex:/(fdd_([^_]|_(?!pp))*)pp$/\\1/)s", fullname=1) "";
%rename("%(regex:/(fdd_([^_p]|[_](?!csharp$)|[p](?!p$))*)/\\1/)s", fullname=1) "";
%rename("%(regex:/(bvec_([^_]|_(?!csharp))*)_csharp$/\\1/)s", fullname=1) "";
%rename("%(regex:/(bvec_([^_]|_(?!pp))*)pp$/\\1/)s", fullname=1) "";
%rename("%(regex:/(bvec_([^_p]|[_](?!csharp$)|[p](?!p$))*)/\\1/)s", fullname=1) "";
%rename(bddtrue) bddtruepp;
%rename(bddfalse) bddfalsepp;

class bvec;

class bdd
{
 public:

   bdd(void)         { root=0; }
   bdd(const bdd &r) { bdd_addref(root=r.root); }
   ~bdd(void)        { bdd_delref(root); }

   int id(void) const;
   
   bdd operator=(const bdd &r);
   
   bdd operator&(const bdd &r) const;
   bdd operator&=(const bdd &r);
   bdd operator^(const bdd &r) const;
   bdd operator^=(const bdd &r);
   bdd operator|(const bdd &r) const;
   bdd operator|=(const bdd &r);
   bdd operator!(void) const;
   bdd operator>>(const bdd &r) const;
   bdd operator>>=(const bdd &r);
   bdd operator-(const bdd &r) const;
   bdd operator-=(const bdd &r);
   bdd operator>(const bdd &r) const;
   bdd operator<(const bdd &r) const;
   bdd operator<<(const bdd &r) const;
   bdd operator<<=(const bdd &r);
   bool operator==(const bdd &r) const;
   bool operator!=(const bdd &r) const;
   
private:
   BDD root;

   bdd(BDD r) { bdd_addref(root=r); }
   bdd operator=(BDD r);

   friend int      bdd_setvarnum(int num);
   friend bdd      bdd_ithvarpp(int i);
   friend bdd      bdd_nithvarpp(int n);
   friend int      bdd_var(const bdd & r);
   friend bdd      bdd_low(const bdd & r);
   friend bdd      bdd_high(const bdd & r);
   friend int      bdd_scanset(const bdd &r, int *& varset, int &varnum);
   friend bdd      bdd_makesetpp(int *varset, int varnum);
   friend int      bdd_setbddpair(bddPair* pair, int oldvar, const bdd &newvar);
   friend int      bdd_setbddpairs(bddPair* pair, int* oldvars, const bdd *newvars, int numvars);
   friend bdd      bdd_buildcube(int value, int width, const bdd *variables);
   friend bdd      bdd_ibuildcubepp(int value, int width, int *variables);
   friend bdd      bdd_not(const bdd &r);
   friend bdd      bdd_simplify(const bdd &f, const bdd &d);
   friend bdd      bdd_apply(const bdd &left, const bdd &right, int op);
   friend bdd      bdd_and(const bdd &left, const bdd &right);
   friend bdd      bdd_or(const bdd &left, const bdd &right);
   friend bdd      bdd_xor(const bdd &left, const bdd &right);
   friend bdd      bdd_imp(const bdd &left, const bdd &right);
   friend bdd      bdd_biimp(const bdd &left, const bdd &right);
   friend bdd      bdd_ite(const bdd &f, const bdd &g, const bdd &h);
   friend bdd      bdd_restrict(const bdd &left, const bdd &right);
   friend bdd      bdd_constrain(const bdd &left, const bdd &right);
   friend bdd      bdd_exist(const bdd &left, const bdd &right);
   friend bdd      bdd_forall(const bdd &left, const bdd &right);
   friend bdd      bdd_unique(const bdd &left, const bdd &right);
   friend bdd      bdd_appex(const bdd &left, const bdd &right, int op, const bdd &var);
   friend bdd      bdd_appall(const bdd &left, const bdd &right, int op, const bdd &var);
   friend bdd      bdd_appuni(const bdd &left, const bdd &right, int op, const bdd &var);
   friend bdd      bdd_replace(const bdd &r, bddPair* pair);
   friend bdd      bdd_compose(const bdd &f, const bdd &g, int var);
   friend bdd      bdd_veccompose(const bdd &f, bddPair* pair);
   friend bdd      bdd_support(const bdd &r);
   friend bdd      bdd_satone(const bdd &r);
   friend bdd      bdd_satoneset(const bdd &r, const bdd &var, const bdd &pol);
   friend bdd      bdd_fullsatone(const bdd &r);
   friend void     bdd_allsat(const bdd &r, bddallsathandler handler);
   friend double   bdd_satcount(const bdd &r);
   friend double   bdd_satcountset(const bdd &r, const bdd &varset);
   friend double   bdd_satcountln(const bdd &r);
   friend double   bdd_satcountlnset(const bdd &r, const bdd &varset);
   friend int      bdd_nodecount(const bdd &r);
   friend int      bdd_anodecountpp(const bdd *rs, int num);
   friend double   bdd_pathcount(const bdd &r);
   
   // friend void   bdd_fprinttable(FILE *, const bdd &);
   friend void   bdd_printtable(const bdd &r);
   // friend void   bdd_fprintset(FILE *, const bdd &);
   friend void   bdd_printset(const bdd &r);
   friend void   bdd_printdot(const bdd &r);
   friend int    bdd_fnprintdot(char* fname, const bdd &r);
   // friend void   bdd_fprintdot(FILE*, const bdd &);
   // friend std::ostream &operator<<(std::ostream &, const bdd &);
   friend int    bdd_fnsave(char* fname, const bdd &r);
   // friend int    bdd_save(FILE*, const bdd &);
   friend int    bdd_fnload(char* fname, bdd &r);
   // friend int    bdd_load(FILE*, bdd &);
   
   friend bdd    fdd_ithvarpp(int var, int val);
   friend bdd    fdd_ithsetpp(int var);
   friend bdd    fdd_domainpp(int var);
   friend int    fdd_scanvar(const bdd &r, int var);
   // friend int*   fdd_scanallvar(const bdd &r);
   friend bdd    fdd_equalspp(int left, int right);
   friend void   fdd_printset(const bdd &r);
   // friend void   fdd_fprintset(FILE*, const bdd &);
   friend bdd    fdd_makesetpp(int* varset, int num);
   // friend int    fdd_scanset(const bdd &, int *&, int &);

   friend int    bdd_addvarblock(const bdd &var, int fixed);

   friend class bvec;
   friend bvec bvec_ite(const bdd& a, const bvec& b, const bvec& c);
   friend bvec bvec_shlfixed(const bvec &e, int pos, const bdd &c);
   friend bvec bvec_shl(const bvec &left, const bvec &right, const bdd &c);
   friend bvec bvec_shrfixed(const bvec &e, int pos, const bdd &c);
   friend bvec bvec_shr(const bvec &left, const bvec &right, const bdd &c);
   friend bdd  bvec_lth(const bvec &left, const bvec &right);
   friend bdd  bvec_lte(const bvec &left, const bvec &right);
   friend bdd  bvec_gth(const bvec &left, const bvec &right);
   friend bdd  bvec_gte(const bvec &left, const bvec &right);
   friend bdd  bvec_equ(const bvec &left, const bvec &right);
   friend bdd  bvec_neq(const bvec &left, const bvec &right);
};

/*=== C++ interface ====================================================*/

%constant bdd bddfalsepp;
%constant bdd bddtruepp;

extern int bdd_cpp_init(int nodesize, int cachesize);

inline void bdd_stats(bddStat& s)
{ bdd_stats(&s); }


%inline %{
inline int* bdd_varprofile_csharp(const bdd &r, int* numvars) {
   *numvars = bdd_varnum();
   return bdd_varprofile(r);
}

inline int* fdd_scanallvar_csharp(const bdd &r, int* numvars) {
   *numvars = bdd_varnum();
   return fdd_scanallvar(r);
}

%}

typedef bdd* (*bvecmapfun1)(const bdd *);
typedef bdd* (*bvecmapfun2)(const bdd *left, const bdd *right);
typedef bdd* (*bvecmapfun3)(const bdd *, const bdd *, const bdd *);

/*=== User BVEC class ==================================================*/

class bvec
{
 public:

   bvec(void)                { roots.bitvec=NULL; roots.bitnum=0; }
   bvec(int bitnum)          { roots=bvec_false(bitnum); }
   bvec(int bitnum, int val) { roots=bvec_con(bitnum,val); }
   bvec(const bvec &v)       { roots=bvec_copy(v.roots); }
   ~bvec(void)               { bvec_free(roots); }

   void set(int i, const bdd &b);
   bdd operator[](int i)  const { return roots.bitvec[i]; }
   int bitnum(void) const       { return roots.bitnum; }
   int empty(void) const        { return roots.bitnum==0; }
   bvec operator=(const bvec &src);
   
private:
   BVEC roots;

   bvec(const BVEC &v) { roots=v; } /* NOTE: Must be a shallow copy! */

   friend bvec bvec_truepp(int bitnum);
   friend bvec bvec_falsepp(int bitnum);
   friend bvec bvec_conpp(int bitnum, int val);
   friend bvec bvec_varpp(int bitnum, int offset, int step);
   friend bvec bvec_varfddpp(int var);
   friend bvec bvec_varvecpp(int bitnum, int *vars);
   friend bvec bvec_coerce(int bitnum, const bvec &v);
   friend int  bvec_isconst(const bvec &e);   
   friend int  bvec_val(const bvec &e);   
   friend bvec bvec_copy(const bvec &v);
   friend bvec bvec_map1_csharp(const bvec &a, bvecmapfun1 f1);
   friend bvec bvec_map2_csharp(const bvec &a, const bvec &b, bvecmapfun2 f2);
   friend bvec bvec_map3_csharp(const bvec &a, const bvec &b, const bvec &c, bvecmapfun3 f3);
   friend bvec bvec_add(const bvec &left, const bvec &right);
   friend bvec bvec_sub(const bvec &left, const bvec &right);
   friend bvec bvec_mulfixed(const bvec &e, int c);
   friend bvec bvec_mul(const bvec &left, const bvec &right);
   friend int  bvec_divfixed(const bvec &e, int c, bvec &res, bvec &rem);
   friend int  bvec_div(const bvec &l, const bvec &r, bvec &res, bvec &rem);
   friend bvec bvec_ite(const bdd& a, const bvec& b, const bvec& c);
   friend bvec bvec_shlfixed(const bvec &e, int pos, const bdd &c);
   friend bvec bvec_shl(const bvec &left, const bvec &right, const bdd &c);
   friend bvec bvec_shrfixed(const bvec &e, int pos, const bdd &c);
   friend bvec bvec_shr(const bvec &left, const bvec &right, const bdd &c);
   friend bdd  bvec_lth(const bvec &left, const bvec &right);
   friend bdd  bvec_lte(const bvec &left, const bvec &right);
   friend bdd  bvec_gth(const bvec &left, const bvec &right);
   friend bdd  bvec_gte(const bvec &left, const bvec &right);
   friend bdd  bvec_equ(const bvec &left, const bvec &right);
   friend bdd  bvec_neq(const bvec &left, const bvec &right);

public:
   bvec operator&(const bvec &a) const { return bvec_map2(*this, a, bdd_and); }
   bvec operator^(const bvec &a) const { return bvec_map2(*this, a, bdd_xor); }
   bvec operator|(const bvec &a) const { return bvec_map2(*this, a, bdd_or); }
   bvec operator!(void) const          { return bvec_map1(*this, bdd_not); }
   bvec operator<<(int a)   const   { return bvec_shlfixed(*this,a,bddfalse); }
   bvec operator<<(const bvec &a) const  { return bvec_shl(*this,a,bddfalse); }
   bvec operator>>(int a)   const   { return bvec_shrfixed(*this,a,bddfalse); }
   bvec operator>>(const bvec &a) const  { return bvec_shr(*this,a,bddfalse); }
   bvec operator+(const bvec &a) const { return bvec_add(*this, a); }
   bvec operator-(const bvec &a) const { return bvec_sub(*this, a); }
   bvec operator*(int a) const         { return bvec_mulfixed(*this, a); }
   bvec operator*(const bvec a) const  { return bvec_mul(*this, a); }
   bdd operator<(const bvec &a) const  { return bvec_lth(*this, a); }
   bdd operator<=(const bvec &a) const { return bvec_lte(*this, a); }
   bdd operator>(const bvec &a) const  { return bvec_gth(*this, a); }
   bdd operator>=(const bvec &a) const { return bvec_gte(*this, a); }
   bdd operator==(const bvec &a) const { return bvec_equ(*this, a); }
   bdd operator!=(const bvec &a) const { return bvec_neq(*this, a); }
};

%inline %{
bvec bvec_map1_csharp(const bvec &a, bvecmapfun1 fun)
{
   bvec res;
   int n;

   res = bvec_false(a.bitnum());
   for (n=0 ; n < a.bitnum() ; n++) {
      const bdd& tmp = a[n];
      res.set(n, *fun(&tmp));
   }
   return res;
}


bvec bvec_map2_csharp(const bvec &a, const bvec &b,
            bvecmapfun2 fun)
{
   bvec res;
   int n;

   if (a.bitnum() != b.bitnum())
   {
      bdd_error(BVEC_SIZE);
      return res;
   }
   
   res = bvec_false(a.bitnum());
   for (n=0 ; n < a.bitnum() ; n++) {
      const bdd& tmp0 = a[n];
      const bdd& tmp1 = b[n];
      res.set(n, *fun(&tmp0, &tmp1) );
   }

   return res;
}


bvec bvec_map3_csharp(const bvec &a, const bvec &b, const bvec &c,
          bvecmapfun3 fun)
{
   bvec res;
   int n;

   if (a.bitnum() != b.bitnum()  ||  b.bitnum() != c.bitnum())
   {
      bdd_error(BVEC_SIZE);
      return res;
   }
   
   res = bvec_false(a.bitnum());
   for (n=0 ; n < a.bitnum() ; n++) {
      const bdd& tmp0 = a[n];
      const bdd& tmp1 = b[n];
      const bdd& tmp2 = c[n];
      res.set(n, *fun(&tmp0, &tmp1, &tmp2) );
   }
   return res;
}
%}


