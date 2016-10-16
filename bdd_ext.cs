using System;
using System.Runtime.InteropServices;

namespace BuDDySharp {

    delegate void bddallsathandler_wrapped(IntPtr arg0, int arg1);
    
    public delegate void bddallsathandler(sbyte[] arg0);

    public delegate void bddgbchandler(int arg0, IntPtr arg1);
    
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))]
    public delegate bdd bvecmapfun1([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg0);

    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))]
    public delegate bdd bvecmapfun2(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg0, 
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg1);

    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))]
    public delegate bdd bvecmapfun3(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg0,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg1, 
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(BuDDySharp))] bdd arg2);

    public partial class BuDDySharp : ICustomMarshaler {

        public const int BDD_REORDER_NONE     =0;
        public const int BDD_REORDER_WIN2     =1;
        public const int BDD_REORDER_WIN2ITE  =2;
        public const int BDD_REORDER_SIFT     =3;
        public const int BDD_REORDER_SIFTITE  =4;
        public const int BDD_REORDER_WIN3     =5;
        public const int BDD_REORDER_WIN3ITE  =6;
        public const int BDD_REORDER_RANDOM   =7;

        public const int BDD_REORDER_FREE     =0;
        public const int BDD_REORDER_FIXED    =1;

        static bddallsathandler_wrapped bddallsathandler_wrapper(bddallsathandler public_handler) {
            return (arg0, arg1) => {
                sbyte[] buffer = new sbyte[arg1];
                Marshal.Copy (arg0, (byte[]) (Array)buffer, 0, arg1);
                public_handler (buffer);
            };
        }

        public static int[] varprofile(bdd r) {
            int size = 0;
            IntPtr tmp = varprofile(r, ref size);
            int[] ret = new int[size];
            Marshal.Copy(tmp, ret, 0, size);
            free_void(tmp);
            return ret;
        }

        public static int[] scanset(bdd r) {
            int varnum = 0;
            IntPtr varset = IntPtr.Zero;
            scanset(r, ref varset, ref varnum);
            int[] ret = new int[varnum];
            Marshal.Copy(varset, ret, 0, varnum);
            return ret;
        }

        public static int[] fdd_scanallvar(bdd r) {
            int size = 0;
            IntPtr tmp = fdd_scanallvar(r, ref size);
            int[] ret = new int[size];
            Marshal.Copy(tmp, ret, 0, size);
            free_void(tmp);
            return ret;
        }

        #region ICustomMarshaler implementation
        public void CleanUpManagedData (object ManagedObj)
        {
            return;
        }
        public void CleanUpNativeData (IntPtr pNativeData)
        {
            return;
        }
        public int GetNativeDataSize ()
        {
            return IntPtr.Size;
        }
        public IntPtr MarshalManagedToNative (object ManagedObj)
        {
            return bdd.getCPtr ((bdd)ManagedObj).Handle;
        }
        public object MarshalNativeToManaged (IntPtr pNativeData)
        {
            return new bdd (pNativeData, false);
        }
        public static ICustomMarshaler GetInstance(String cookie) {
            return new BuDDySharp();
        } 
        #endregion
    }

    public partial class bdd {
        public override string ToString ()
        {
            if (this.EqualEqual (BuDDySharp.bddtrue)) {
                return "t";
            } else if (this.EqualEqual (BuDDySharp.bddfalse)) {
                return "f";
            } else {
                return String.Format("({0} {1} {2})", BuDDySharp.var(this), BuDDySharp.low(this), BuDDySharp.high(this));
            }
        }
    }
}