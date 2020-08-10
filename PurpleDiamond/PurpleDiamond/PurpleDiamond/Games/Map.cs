using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class Map
	{
		private DDTable<MapCell> Table;

		public Map(int w, int h)
		{
			this.Table = new DDTable<MapCell>(w, h, (x, y) => new MapCell());
		}

		public int W { get { return this.Table.W; } }
		public int H { get { return this.Table.H; } }

		private Dictionary<string, string> Properties = DictionaryTools.Create<string>();

		public void AddProperty(string name, string value)
		{
			this.Properties.Add(name, value);
		}

		public string GetProperty(string name, string defval = null)
		{
			if (this.Properties.ContainsKey(name) == false)
				return defval;

			return this.Properties[name];
		}

		public IEnumerable<KeyValuePair<string, string>> GetProperties()
		{
			return this.Properties;
		}

		// TablePoint ... I2Point Table用の座標
		// PixelPoint ... D2Point 座標(ピクセル単位)

		public static I2Point ToTablePoint(D2Point pixelPt)
		{
			return ToTablePoint(pixelPt.X, pixelPt.Y);
		}

		public static I2Point ToTablePoint(double pixelX, double pixelY)
		{
			int mapTileX = (int)Math.Floor(pixelX / MapTile.WH);
			int mapTileY = (int)Math.Floor(pixelY / MapTile.WH);

			return new I2Point(mapTileX, mapTileY);
		}

		private MapCell DefaultCell = new MapCell()
		{
			// 初期化子？
		};

		public MapCell GetCellByPixelPoint(double x, double y)
		{
			return this.GetCellByPixelPoint(new D2Point(x, y));
		}

		public MapCell GetCellByPixelPoint(D2Point pt)
		{
			return this.GetCell(ToTablePoint(pt));
		}

		public MapCell GetCell(I2Point pt)
		{
			return this.GetCell(pt, this.DefaultCell);
		}

		public MapCell GetCell(I2Point pt, MapCell defCell)
		{
			return this.GetCell(pt.X, pt.Y, defCell);
		}

		public MapCell GetCell(int x, int y)
		{
			return this.GetCell(x, y, this.DefaultCell);
		}

		public MapCell GetCell(int x, int y, MapCell defCell)
		{
			if (
				x < 0 || this.Table.W <= x ||
				y < 0 || this.Table.H <= y
				)
				return defCell;

			return Table[x, y];
		}
	}
}
