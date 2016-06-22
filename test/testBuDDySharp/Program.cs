using System;
using buddysharp;

namespace testBuDDySharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			bdd.bdd_init (100, 1000);
			var t = bdd.bdd_true ();
			Console.WriteLine (t.ToString ());
		}
	}
}
