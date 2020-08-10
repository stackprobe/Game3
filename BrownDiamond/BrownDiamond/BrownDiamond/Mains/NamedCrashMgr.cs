using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Game3Common;
using Charlotte.Tools;

namespace Charlotte.Mains
{
	public static class NamedCrashMgr
	{
		private static List<NamedCrash> Crashes = new List<NamedCrash>();

		public static void Clear()
		{
			Crashes.Clear();
		}

		public static Crash LastDrawedCrash;

		public static void AddLastDrawedCrash(string name)
		{
			Add(new NamedCrash(name, LastDrawedCrash));
		}

		public static void Add(NamedCrash crash)
		{
			Crashes.Add(crash);
		}

		public static string GetName(double x, double y, string defval = null)
		{
			return GetName(new D2Point(x, y), defval);
		}

		public static string GetName(D2Point pt, string defval = null)
		{
			Crash ptCrash = CrashUtils.Point(pt);

			foreach (NamedCrash crash in Crashes)
				if (crash.Crash.IsCrashed(ptCrash))
					return crash.Name;

			return defval;
		}
	}
}
