using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;
using Charlotte.Tools;

namespace Charlotte.Games
{
	public static class MapTileManager
	{
		private static List<string> Names = new List<string>();
		private static Dictionary<string, MapTile> Tiles = DictionaryTools.Create<MapTile>();

		public static void INIT()
		{
			Add(Ground.I.Picture.DeepForestA1, "DeepForestA1");
			Add(Ground.I.Picture.DeepForestA2, "DeepForestA2");
			Add(Ground.I.Picture.DeepForestA5, "DeepForestA5");
			Add(Ground.I.Picture.DeepForestB, "DeepForestB");
			Add(Ground.I.Picture.RuinF, "RuinF");
		}

		private static void Add(DDTable<DDPicture> table, string tableName)
		{
			table.GetAllCell((x, y, picture) => Add(picture, string.Format("{0}_{1}_{2}", tableName, x, y)));
		}

		private static void Add(DDPicture picture, string name)
		{
			Names.Add(name);
			Tiles.Add(name, new MapTile()
			{
				Name = name,
				Picture = picture,
			});
		}

		public static MapTile GetTile(string name)
		{
			if (name == "")
				return null;

			if (Tiles.ContainsKey(name) == false)
				throw new DDError("そんなタイルありません。" + name);

			return Tiles[name];
		}

		public static List<string> GetNames()
		{
			return Names;
		}

		public static int GetCount()
		{
			return Names.Count;
		}
	}
}
