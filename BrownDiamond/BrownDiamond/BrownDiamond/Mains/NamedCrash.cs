using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Game3Common;
using Charlotte.Tools;

namespace Charlotte.Mains
{
	public class NamedCrash
	{
		public string Name;
		public Crash Crash;

		public NamedCrash(string name, Crash crash)
		{
			this.Name = name;
			this.Crash = crash;
		}
	}
}
