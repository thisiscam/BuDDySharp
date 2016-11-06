using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BDD = System.Int32;

namespace BuDDySharp
{
	public sealed class bdd
	{
		public static readonly bdd bddtrue = new bdd(BuDDySharp._true());
		public static readonly bdd bddfalse = new bdd(BuDDySharp._false());
		
		BDD _id;
		
		public BDD Id { get { return _id; } }
		
		public bdd(BDD id):this(id, true) { }
		
		public bdd(BDD id, bool addref)
		{
			this._id = id;
			if(addref) {
				BuDDySharp.addref(this._id);
			}
		}
		
		~bdd()
		{
			BuDDySharp.delref(this._id);
		}

		public bdd And(bdd r)
		{
			return new bdd(BuDDySharp.bdd_and_addref(this._id, r._id), false);
		}

		public bdd Xor(bdd r)
		{
			return new bdd(BuDDySharp.bdd_xor_addref(this._id, r._id), false);
		}

		public bdd Or(bdd r)
		{
			return new bdd(BuDDySharp.bdd_or_addref(this._id, r._id), false);
		}

		public bdd Not()
		{
			return new bdd(BuDDySharp.bdd_not_addref(this._id), false);
		}

		public bdd Imp(bdd r)
		{
			return new bdd(BuDDySharp.bdd_imp_addref(this._id, r._id), false);
		}
		
		public bdd Biimp(bdd r)
		{
			return new bdd(BuDDySharp.bdd_biimp_addref(this._id, r._id), false);
		}

		public bdd Diff(bdd r)
		{
			return new bdd(BuDDySharp.bdd_apply_addref(this.Id, r.Id, bddop.diff), false);
		}

		public bdd GreaterThan(bdd r)
		{
			return new bdd(BuDDySharp.bdd_apply_addref(this.Id, r.Id, bddop.diff), false);
		}

		public bdd LessThan(bdd r)
		{
			return new bdd(BuDDySharp.bdd_apply_addref(this.Id, r.Id, bddop.less), false);
		}

		public bdd InvImplies(bdd r)
		{
			return new bdd(BuDDySharp.bdd_apply_addref(this.Id, r.Id, bddop.invimp), false);
		}
		
		public bool EqualEqual(bdd r)
		{
			return this._id == r._id;
		}

		public bool NotEqual(bdd r)
		{
			return this._id != r._id;
		}
		
#region extensions
		public static bdd ithvar(int arg0) {
			return new bdd(BuDDySharp.ithvar(arg0), false);
		}
		
		public static bdd nithvar(int arg0) {
			return new bdd(BuDDySharp.nithvar(arg0), false);
		}
		
		public static bdd mark_ithvar_npure_bool(int arg0) {
			return new bdd(BuDDySharp.mark_ithvar_npure_bool(arg0), false);
		}
		
		public bool not_pure_bool() {
			return BuDDySharp.not_pure_bool(_id);
		}
		
		public static bdd makeset(int[] arg0, int arg1) {
			return new bdd(BuDDySharp.bdd_makeset_addref(arg0, arg1), false);
		}
		
		public bdd Low() {
			return new bdd(BuDDySharp.bdd_low_addref(this.Id), false);
		}
		
		public bdd High() {
			return new bdd(BuDDySharp.bdd_high_addref(this.Id), false);
		}
		
		public int[] Scanset() {
            int varnum = 0;
            IntPtr varset = IntPtr.Zero;
            BuDDySharp._scanset(_id, ref varset, ref varnum);
            int[] ret = new int[varnum];
            Marshal.Copy(varset, ret, 0, varnum);
            return ret;
        }
        
        public int Var() {
        	return BuDDySharp.var(this._id);
		}
        
        private string ToStringHelper(Dictionary<BDD, string> cache)
        {
        	if (this.EqualEqual (bddtrue)) {
                return "t";
            } else if (this.EqualEqual (bddfalse)) {
                return "f";
            } else {
            	if(cache.ContainsKey(_id)) {
	                var ret = String.Format("({0} {1} {2})", Var(), Low().ToStringHelper(cache), High().ToStringHelper(cache));
	                cache[_id] = ret;
                }
                return cache[_id];
            }
        }
        
        public override string ToString()
		{
            return ToStringHelper(new Dictionary<BDD, string>());
		}
		
		public void PrintDot()
		{
			BuDDySharp.printdot(_id);
		}
#endregion
	}
}
