using System;
using System.Runtime.InteropServices;
using BDD = System.Int32;

namespace BuDDySharp
{
	[StructLayout(LayoutKind.Sequential)]
	public struct bddStat
	{
	   public long produced;
	   public int nodenum;
	   public int maxnodenum;
	   public int freenodes;
	   public int minfreenodes;
	   public int varnum;
	   public int cachesize;
	   public int gbcnum;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct bddGbcStat
	{
	   public int nodes;
	   public int freenodes;
	   public long time;
	   public long sumtime;
	   public int num;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct bddCacheStat
	{
	   public ulong uniqueAccess;
	   public ulong uniqueChain;
	   public ulong uniqueHit;
	   public ulong uniqueMiss;
	   public ulong opHit;
	   public ulong opMiss;
	   public ulong swapCount;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BVEC
	{
		public int bitnum;
		public BDD* bitvec;
	}
}
