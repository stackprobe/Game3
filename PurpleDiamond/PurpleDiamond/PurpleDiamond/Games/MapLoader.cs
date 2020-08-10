using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class MapLoader
	{
		public static string LastLoadedFile = null; // null == 未読み込み

		public static Map Load(string file)
		{
			LastLoadedFile = file;

			string[] lines = FileTools.TextToLines(Encoding.UTF8.GetString(DDResource.Load(file)));
			int c = 0;

			int w = int.Parse(lines[c++]);
			int h = int.Parse(lines[c++]);

			Map map = new Map(w, h);

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					if (lines.Length <= c)
						goto endLoad;

					MapCell cell = map.GetCell(x, y);
					var tokens = new BluffList<string>(lines[c++].Split('\t')).FreeRange(""); // 項目が増えても良いように -> FreeRange("")
					int d = 0;

					cell.Kind = (MapCell.Kind_e)int.Parse(tokens[d++]);
					cell.SurfacePicture = MapTileManager.GetTile(tokens[d++]);
					cell.TilePicture = MapTileManager.GetTile(tokens[d++]);

					// 新しい項目をここへ追加...
				}
			}
			while (c < lines.Length)
			{
				// memo: Save()時にプロパティ部分も上書きされるので注意してね。

				var tokens = lines[c++].Split("=".ToArray(), 2);

				string name = tokens[0];
				string value = tokens[1];

				map.AddProperty(name, value);
			}
		endLoad:
			return map;
		}

		public static void SaveToLastLoadedFile(Map map)
		{
			if (LastLoadedFile == null)
				throw new DDError();

			Save(map, LastLoadedFile);
		}

		public static void Save(Map map, string file)
		{
			List<string> lines = new List<string>();
			int w = map.W;
			int h = map.H;

			lines.Add("" + w);
			lines.Add("" + h);

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					MapCell cell = map.GetCell(x, y);
					List<string> tokens = new List<string>();

					tokens.Add("" + (int)cell.Kind);
					tokens.Add(cell.SurfacePicture.Name);
					tokens.Add(cell.TilePicture.Name);

					// 新しい項目をここへ追加...

					lines.Add(string.Join("\t", tokens).TrimEnd());
				}
			}
			foreach (KeyValuePair<string, string> pair in map.GetProperties())
			{
				lines.Add(pair.Key + "=" + pair.Value);
			}
			DDResource.Save(file, Encoding.UTF8.GetBytes(FileTools.LinesToText(lines.ToArray())));
		}
	}
}
