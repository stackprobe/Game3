using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;
using System.Text.RegularExpressions;
using System.IO;

namespace Charlotte.Games
{
	public static class MapLoader
	{
		public static Map Load(string file)
		{
			file = Path.Combine("Map", file);

			string[] lines = FileTools.TextToLines(StringTools.ENCODING_SJIS.GetString(DDResource.Load(file)));
			int c = 0;

			string[] mapLines;

			{
				List<string> dest = new List<string>();

				while (c < lines.Length)
				{
					string line = lines[c++];

					if (line == "")
						break;

					dest.Add(line);
				}
				mapLines = dest.ToArray();
			}

			Dictionary<string, string> mapScripts = DictionaryTools.Create<string>();

			while (c < lines.Length)
			{
				string line = lines[c++];

				if (line.StartsWith(";")) // ? コメント
					continue;

				if (line == "")
					break;

				var tokens = line.Split("=".ToArray(), 2);

				string name = tokens[0].Trim();
				string value = tokens[1].Trim();

				if (Regex.IsMatch(name, @"^[0-9A-Za-z]{2}(:[2468])?$") == false)
					throw new DDError();

				if (value == "")
					throw new DDError();

				mapScripts.Add(name, value);
			}

			Map map = LoadMap(mapLines, mapScripts);

			while (c < lines.Length)
			{
				string line = lines[c++];

				if (line.StartsWith(";")) // ? コメント
					continue;

				var tokens = line.Split("=".ToArray(), 2);

				string name = tokens[0].Trim();
				string value = tokens[1].Trim();

				if (name == "") throw new DDError();
				if (value == "") throw new DDError();

				map.AddProperty(name, value);
			}
			return map;
		}

		private static Map LoadMap(string[] mapLines, Dictionary<string, string> mapScripts)
		{
			if (mapLines.Length < 3)
				throw new DDError();

			if (mapLines.Length % 2 != 1)
				throw new DDError();

			if (mapLines.Select(line => line.Length).Distinct().Count() != 1)
				throw new DDError();

			for (int y = 0; y < mapLines.Length; y++)
			{
				string mapLine = mapLines[y];

				if (y == 0 || y == mapLines.Length - 1)
				{
					if (Regex.IsMatch(mapLine, @"^\+(--\+)+$") == false)
						throw new DDError();
				}
				else if (y % 2 == 0)
				{
					if (Regex.IsMatch(mapLine, @"^\+((  |--|G-)\+)+$") == false)
						throw new DDError();
				}
				else
				{
					if (Regex.IsMatch(mapLine, @"^\|((  |[0-9A-Za-z]{2})[ \|G])+$") == false || mapLine.EndsWith("|") == false)
						throw new DDError();
				}
			}
			int w = mapLines[0].Length / 3;
			int h = mapLines.Length / 2;

			Map map = new Map(w, h);

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					string s8 = mapLines[y * 2 + 0].Substring(x * 3 + 1, 2);
					string s5 = mapLines[y * 2 + 1].Substring(x * 3 + 1, 2);
					string s2 = mapLines[y * 2 + 2].Substring(x * 3 + 1, 2);
					string s4 = mapLines[y * 2 + 1].Substring(x * 3 + 0, 1);
					string s6 = mapLines[y * 2 + 1].Substring(x * 3 + 3, 1);

					MapCell cell = map[x, y];

					LoadWall_NS(cell.Wall_8, s8);
					LoadWall_NS(cell.Wall_2, s2);
					LoadWall_WE(cell.Wall_4, s4);
					LoadWall_WE(cell.Wall_6, s6);

					if (s5 == "  ")
					{
						// noop
					}
					else
					{
						string s5_2 = s5 + ":2";
						string s5_4 = s5 + ":4";
						string s5_6 = s5 + ":6";
						string s5_8 = s5 + ":8";

						LoadScript(mapScripts, s5_2, s => cell.Wall_2.Script = s);
						LoadScript(mapScripts, s5_4, s => cell.Wall_4.Script = s);
						LoadScript(mapScripts, s5_6, s => cell.Wall_6.Script = s);
						LoadScript(mapScripts, s5_8, s => cell.Wall_8.Script = s);
						LoadScript(mapScripts, s5, s => cell.Script = s);
					}
				}
			}
			return map;
		}

		private static void LoadWall_NS(MapWall wall, string s)
		{
			switch (s)
			{
				case "  ": wall.Kind = MapWall.Kind_e.NONE; break;
				case "--": wall.Kind = MapWall.Kind_e.WALL; break;
				case "G-": wall.Kind = MapWall.Kind_e.GATE; break;

				default:
					throw null; // never
			}
		}

		private static void LoadWall_WE(MapWall wall, string s)
		{
			switch (s)
			{
				case " ": wall.Kind = MapWall.Kind_e.NONE; break;
				case "|": wall.Kind = MapWall.Kind_e.WALL; break;
				case "G": wall.Kind = MapWall.Kind_e.GATE; break;

				default:
					throw null; // never
			}
		}

		private static void LoadScript(Dictionary<string, string> mapScripts, string s, Action<string> setScript)
		{
			if (mapScripts.ContainsKey(s))
			{
				setScript(mapScripts[s]);
			}
		}
	}
}
