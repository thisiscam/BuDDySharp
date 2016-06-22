%define %cs_callback(TYPE, CSTYPE) 
        %typemap(ctype) TYPE, TYPE& "void*" 
        %typemap(in) TYPE  %{ $1 = (TYPE)$input; %} 
        %typemap(in) TYPE& %{ $1 = (TYPE*)&$input; %} 
        %typemap(imtype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(cstype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(csin) TYPE, TYPE& "$csinput" 
%enddef 

%module buddysharp
%{
	#include "bdd.h"
   #include "bvec.h"
%}

%cs_callback(bddallsathandler, bddallsathandler);

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
   int operator==(const bdd &r) const;
   int operator!=(const bdd &r) const;
   
private:
   BDD root;

   bdd(BDD r) { bdd_addref(root=r); }
   bdd operator=(BDD r);

   friend int      bdd_init(int nodesize, int cachesize);
   friend int      bdd_setvarnum(int num);
   friend bdd      bdd_true(void);
   friend bdd      bdd_false(void);
   friend bdd      bdd_ithvarpp(int i);
   friend bdd      bdd_nithvarpp(int n);
   friend int      bdd_var(const bdd & r);
   friend bdd      bdd_low(const bdd & r);
   friend bdd      bdd_high(const bdd & r);
   // friend int      bdd_scanset(const bdd &r, int *&, int &);
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
   // friend int*     bdd_varprofile(const bdd &);
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
   friend int*   fdd_scanallvar(const bdd &r);
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


/*=== BDD constants ====================================================*/

extern const bdd bddfalsepp;
extern const bdd bddtruepp;

#define bddtrue bddtruepp
#define bddfalse bddfalsepp

/*=== C++ interface ====================================================*/

extern int bdd_cpp_init(int, int);

inline void bdd_stats(bddStat& s)
{ bdd_stats(&s); }

inline bdd bdd_ithvarpp(int v)
{ return bdd_ithvar(v); }

inline bdd bdd_nithvarpp(int v)
{ return bdd_nithvar(v); }

inline int bdd_var(const bdd &r)
{ return bdd_var(r.root); }

inline bdd bdd_low(const bdd &r)
{ return bdd_low(r.root); }

inline bdd bdd_high(const bdd &r)
{ return bdd_high(r.root); }

inline int bdd_scanset(const bdd &r, int *&v, int &n)
{ return bdd_scanset(r.root, &v, &n); }

inline bdd bdd_makesetpp(int *v, int n)
{ return bdd(bdd_makeset(v,n)); }

inline int bdd_setbddpair(bddPair *p, int ov, const bdd &nv)
{ return bdd_setbddpair(p,ov,nv.root); }

   /* In bddop.c */

inline bdd bdd_replace(const bdd &r, bddPair *p)
{ return bdd_replace(r.root, p); }

inline bdd bdd_compose(const bdd &f, const bdd &g, int v)
{ return bdd_compose(f.root, g.root, v); }

inline bdd bdd_veccompose(const bdd &f, bddPair *p)
{ return bdd_veccompose(f.root, p); }

inline bdd bdd_restrict(const bdd &r, const bdd &var)
{ return bdd_restrict(r.root, var.root); }

inline bdd bdd_constrain(const bdd &f, const bdd &c)
{ return bdd_constrain(f.root, c.root); }

inline bdd bdd_simplify(const bdd &d, const bdd &b)
{ return bdd_simplify(d.root, b.root); }

inline bdd bdd_ibuildcubepp(int v, int w, int *a)
{ return bdd_ibuildcube(v,w,a); }

inline bdd bdd_not(const bdd &r)
{ return bdd_not(r.root); }

inline bdd bdd_apply(const bdd &l, const bdd &r, int op)
{ return bdd_apply(l.root, r.root, op); }

inline bdd bdd_and(const bdd &l, const bdd &r)
{ return bdd_apply(l.root, r.root, bddop_and); }

inline bdd bdd_or(const bdd &l, const bdd &r)
{ return bdd_apply(l.root, r.root, bddop_or); }

inline bdd bdd_xor(const bdd &l, const bdd &r)
{ return bdd_apply(l.root, r.root, bddop_xor); }

inline bdd bdd_imp(const bdd &l, const bdd &r)
{ return bdd_apply(l.root, r.root, bddop_imp); }

inline bdd bdd_biimp(const bdd &l, const bdd &r)
{ return bdd_apply(l.root, r.root, bddop_biimp); }

inline bdd bdd_ite(const bdd &f, const bdd &g, const bdd &h)
{ return bdd_ite(f.root, g.root, h.root); }

inline bdd bdd_exist(const bdd &r, const bdd &var)
{ return bdd_exist(r.root, var.root); }

inline bdd bdd_forall(const bdd &r, const bdd &var)
{ return bdd_forall(r.root, var.root); }

inline bdd bdd_unique(const bdd &r, const bdd &var)
{ return bdd_unique(r.root, var.root); }

inline bdd bdd_appex(const bdd &l, const bdd &r, int op, const bdd &var)
{ return bdd_appex(l.root, r.root, op, var.root); }

inline bdd bdd_appall(const bdd &l, const bdd &r, int op, const bdd &var)
{ return bdd_appall(l.root, r.root, op, var.root); }

inline bdd bdd_appuni(const bdd &l, const bdd &r, int op, const bdd &var)
{ return bdd_appuni(l.root, r.root, op, var.root); }

inline bdd bdd_support(const bdd &r)
{ return bdd_support(r.root); }

inline bdd bdd_satone(const bdd &r)
{ return bdd_satone(r.root); }

inline bdd bdd_satoneset(const bdd &r, const bdd &var, const bdd &pol)
{ return bdd_satoneset(r.root, var.root, pol.root); }

inline bdd bdd_fullsatone(const bdd &r)
{ return bdd_fullsatone(r.root); }

inline void bdd_allsat(const bdd &r, bddallsathandler handler)
{ bdd_allsat(r.root, handler); }

inline double bdd_satcount(const bdd &r)
{ return bdd_satcount(r.root); }

inline double bdd_satcountset(const bdd &r, const bdd &varset)
{ return bdd_satcountset(r.root, varset.root); }

inline double bdd_satcountln(const bdd &r)
{ return bdd_satcountln(r.root); }

inline double bdd_satcountlnset(const bdd &r, const bdd &varset)
{ return bdd_satcountlnset(r.root, varset.root); }

inline int bdd_nodecount(const bdd &r)
{ return bdd_nodecount(r.root); }

inline int* bdd_varprofile(const bdd &r)
{ return bdd_varprofile(r.root); }

inline double bdd_pathcount(const bdd &r)
{ return bdd_pathcount(r.root); }


   /* I/O extensions */

// inline void bdd_fprinttable(FILE *file, const bdd &r)
// { bdd_fprinttable(file, r.root); }

inline void bdd_printtable(const bdd &r)
{ bdd_printtable(r.root); }

// inline void bdd_fprintset(FILE *file, const bdd &r)
// { bdd_fprintset(file, r.root); }

inline void bdd_printset(const bdd &r)
{ bdd_printset(r.root); }

inline void bdd_printdot(const bdd &r)
{ bdd_printdot(r.root); }

// inline void bdd_fprintdot(FILE* ofile, const bdd &r)
// { bdd_fprintdot(ofile, r.root); }

inline int bdd_fnprintdot(char* fname, const bdd &r)
{ return bdd_fnprintdot(fname, r.root); }

inline int bdd_fnsave(char *fname, const bdd &r)
{ return bdd_fnsave(fname, r.root); }

// inline int bdd_save(FILE *ofile, const bdd &r)
// { return bdd_save(ofile, r.root); }

inline int bdd_fnload(char *fname, bdd &r)
{ int lr,e; e=bdd_fnload(fname, &lr); r=bdd(lr); return e; }

// inline int bdd_load(FILE *ifile, bdd &r)
// { int lr,e; e=bdd_load(ifile, &lr); r=bdd(lr); return e; }

inline int bdd_addvarblock(const bdd &v, int f)
{ return bdd_addvarblock(v.root, f); }

   /* Hack to allow for overloading */
#define bdd_init bdd_cpp_init
#define bdd_ithvar bdd_ithvarpp
#define bdd_nithvar bdd_nithvarpp
#define bdd_makeset bdd_makesetpp
#define bdd_ibuildcube bdd_ibuildcubepp
#define bdd_anodecount bdd_anodecountpp

/*=== Inline C++ functions =============================================*/

inline int bdd::id(void) const
{ return root; }

inline bdd bdd::operator&(const bdd &r) const
{ return bdd_apply(*this,r,bddop_and); }

inline bdd bdd::operator&=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_and)); }

inline bdd bdd::operator^(const bdd &r) const
{ return bdd_apply(*this,r,bddop_xor); }

inline bdd bdd::operator^=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_xor)); }

inline bdd bdd::operator|(const bdd &r) const
{ return bdd_apply(*this,r,bddop_or); }

inline bdd bdd::operator|=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_or)); }

inline bdd bdd::operator!(void) const
{ return bdd_not(*this);}

inline bdd bdd::operator>>(const bdd &r) const
{ return bdd_apply(*this,r,bddop_imp); }

inline bdd bdd::operator>>=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_imp)); }

inline bdd bdd::operator-(const bdd &r) const
{ return bdd_apply(*this,r,bddop_diff); }

inline bdd bdd::operator-=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_diff)); }

inline bdd bdd::operator>(const bdd &r) const
{ return bdd_apply(*this,r,bddop_diff); }

inline bdd bdd::operator<(const bdd &r) const
{ return bdd_apply(*this,r,bddop_less); }

inline bdd bdd::operator<<(const bdd &r) const
{ return bdd_apply(*this,r,bddop_invimp); }

inline bdd bdd::operator<<=(const bdd &r)
{ return (*this=bdd_apply(*this,r,bddop_invimp)); }

inline int bdd::operator==(const bdd &r) const
{ return r.root==root; }

inline int bdd::operator!=(const bdd &r) const
{ return r.root!=root; }

inline bdd bdd::bdd_true(void)
{ return 1; }

inline bdd bdd::bdd_false(void)
{ return 0; }


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
   friend bvec bvec_varvecpp(int bitnum, int *var);
   friend bvec bvec_coerce(int bitnum, const bvec &v);
   friend int  bvec_isconst(const bvec &e);   
   friend int  bvec_val(const bvec &e);   
   friend bvec bvec_copy(const bvec &v);
   friend bvec bvec_map1(const bvec &a,
          bdd (*fun)(const bdd &));
   friend bvec bvec_map2(const bvec &a, const bvec &b,
          bdd (*fun)(const bdd &left, const bdd &right));
   friend bvec bvec_map3(const bvec &a, const bvec &b, const bvec &c,
          bdd (*fun)(const bdd &, const bdd &, const bdd &));
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

std::ostream &operator<<(std::ostream &, const bvec &);

inline bvec bvec_truepp(int bitnum)
{ return bvec_true(bitnum); }

inline bvec bvec_falsepp(int bitnum)
{ return bvec_false(bitnum); }

inline bvec bvec_conpp(int bitnum, int val)
{ return bvec_con(bitnum, val); }

inline bvec bvec_varpp(int bitnum, int offset, int step)
{ return bvec_var(bitnum, offset, step); }

inline bvec bvec_varfddpp(int var)
{ return bvec_varfdd(var); }

inline bvec bvec_varvecpp(int bitnum, int *var)
{ return bvec_varvec(bitnum, var); }

inline bvec bvec_coerce(int bitnum, const bvec &v)
{ return bvec_coerce(bitnum, v.roots); }

inline int  bvec_isconst(const bvec &e)
{ return bvec_isconst(e.roots); }

inline int  bvec_val(const bvec &e)
{ return bvec_val(e.roots); }

inline bvec bvec_copy(const bvec &v)
{ return bvec_copy(v.roots); }

inline bvec bvec_add(const bvec &left, const bvec &right)
{ return bvec_add(left.roots, right.roots); }

inline bvec bvec_sub(const bvec &left, const bvec &right)
{ return bvec_sub(left.roots, right.roots); }

inline bvec bvec_mulfixed(const bvec &e, int c)
{ return bvec_mulfixed(e.roots, c); }

inline bvec bvec_mul(const bvec &left, const bvec &right)
{ return bvec_mul(left.roots, right.roots); }

inline int bvec_divfixed(const bvec &e, int c, bvec &res, bvec &rem)
{ return bvec_divfixed(e.roots, c, &res.roots, &rem.roots); }

inline int bvec_div(const bvec &l, const bvec &r, bvec &res, bvec &rem)
{ return bvec_div(l.roots, r.roots, &res.roots, &rem.roots); }

inline bvec bvec_ite(const bdd& a, const bvec& b, const bvec& c)
{ return bvec_ite(a.root, b.roots, c.roots); }

inline bvec bvec_shlfixed(const bvec &e, int pos, const bdd &c)
{ return bvec_shlfixed(e.roots, pos, c.root); }

inline bvec bvec_shl(const bvec &left, const bvec &right, const bdd &c)
{ return bvec_shl(left.roots, right.roots, c.root); }

inline bvec bvec_shrfixed(const bvec &e, int pos, const bdd &c)
{ return bvec_shrfixed(e.roots, pos, c.root); }

inline bvec bvec_shr(const bvec &left, const bvec &right, const bdd &c)
{ return bvec_shr(left.roots, right.roots, c.root); }

inline bdd  bvec_lth(const bvec &left, const bvec &right)
{ return bvec_lth(left.roots, right.roots); }

inline bdd  bvec_lte(const bvec &left, const bvec &right)
{ return bvec_lte(left.roots, right.roots); }

inline bdd  bvec_gth(const bvec &left, const bvec &right)
{ return bvec_gth(left.roots, right.roots); }

inline bdd  bvec_gte(const bvec &left, const bvec &right)
{ return bvec_gte(left.roots, right.roots); }

inline bdd  bvec_equ(const bvec &left, const bvec &right)
{ return bvec_equ(left.roots, right.roots); }

inline bdd  bvec_neq(const bvec &left, const bvec &right)
{ return bvec_neq(left.roots, right.roots); }


   /* Hack to allow for overloading */
#define bvec_var(a,b,c)  bvec_varpp(a,b,c)
#define bvec_varfdd(a)   bvec_varfddpp(a)
#define bvec_varvec(a,b) bvec_varvecpp(a,b)
#define bvec_true(a)     bvec_truepp(a)
#define bvec_false(a)    bvec_falsepp(a)
#define bvec_con(a,b)    bvec_conpp((a),(b))

