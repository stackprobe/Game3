using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class MapCell
	{
		public Kind_e Kind = Kind_e.SPACE;
		public MapTile SurfacePicture = null; // null == 画像無し
		public MapTile TilePicture = null; // null == 画像無し

		// <---- prm

		public enum Kind_e
		{
			SPACE = 1,
			OBSTACLE,
			WATER,
		}
	}
}
