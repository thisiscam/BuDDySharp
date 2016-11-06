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
		
		public bdd(BDD id)
		{
			this._id = id;
			BuDDySharp.addref(this._id);
		}

		~bdd()
		{
			BuDDySharp.delref(this._id);
		}

		public bdd And(bdd r)
		{
			return new bdd(BuDDySharp.and(this._id, r._id));
		}

		public bdd Xor(bdd r)
		{
			return new bdd(BuDDySharp.xor(this._id, r._id));
		}

		public bdd Or(bdd r)
		{
			return new bdd(BuDDySharp.or(this._id, r._id));
		}

		public bdd Not()
		{
			return new bdd(BuDDySharp.not(this._id));
		}

		public bdd Imp(bdd r)
		{
			return new bdd(BuDDySharp.imp(this._id, r._id));
		}
		
		public bdd Biimp(bdd r)
		{
			return new bdd(BuDDySharp.biimp(this._id, r._id));
		}

		public bdd Diff(bdd r)
		{
			return new bdd(BuDDySharp.apply(this.Id, r.Id, bddop.diff));
		}

		public bdd GreaterThan(bdd r)
		{
			return new bdd(BuDDySharp.apply(this.Id, r.Id, bddop.diff));
		}

		public bdd LessThan(bdd r)
		{
			return new bdd(BuDDySharp.apply(this.Id, r.Id, bddop.less));
		}

		public bdd InvImplies(bdd r)
		{
			return new bdd(BuDDySharp.apply(this.Id, r.Id, bddop.invimp));
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
			return new bdd(BuDDySharp.ithvar(arg0));
		}
		
		public static bdd nithvar(int arg0) {
			return new bdd(BuDDySharp.nithvar(arg0));
		}
		
		public static int ithvar(bdd arg0) {
			return BuDDySharp.var(arg0.Id);
		}
		
		public static bdd mark_ithvar_npure_bool(int arg0) {
			return new bdd(BuDDySharp.mark_ithvar_npure_bool(arg0));
		}
		
		public static bool not_pure_bool(BDD arg0) {
			return BuDDySharp.not_pure_bool(arg0);
		}
		
		public bdd Low() {
			return new bdd(BuDDySharp.low(this.Id));
		}
		
		public bdd High() {
			return new bdd(BuDDySharp.high(this.Id));
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
