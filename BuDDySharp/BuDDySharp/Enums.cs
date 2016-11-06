using System;
namespace BuDDySharp
{
	partial class BuDDySharp 
	{
		public const int BDD_REORDER_NONE = 0;
		public const int BDD_REORDER_WIN2 = 1;
		public const int BDD_REORDER_WIN2ITE = 2;
		public const int BDD_REORDER_SIFT = 3;
		public const int BDD_REORDER_SIFTITE = 4;
		public const int BDD_REORDER_WIN3 = 5;
		public const int BDD_REORDER_WIN3ITE = 6;
		public const int BDD_REORDER_RANDOM = 7;
		
		public const int BDD_REORDER_FREE = 0;
		public const int BDD_REORDER_FIXED = 1;
	}
	/* Copied from bdd.h */
	public enum bddop {
		and       =0,
		xor       =1,
		or        =2,
		nand      =3,
		nor       =4,
		imp       =5,
		biimp     =6,
		diff      =7,
		less      =8,
		invimp    =9,
		/* Should *not* be used in apply calls !!! */
		not       =10,
		simplify  =11,
	}
}
