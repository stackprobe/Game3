using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;
using Charlotte.Games;

namespace Charlotte
{
	public static class Consts
	{
		public const int SCREEN_MAP_W = DDConsts.Screen_W / MapTile.WH; // == 25
		public const int SCREEN_MAP_H = DDConsts.Screen_H / MapTile.WH; // == 20
	}
}
