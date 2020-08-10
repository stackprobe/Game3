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
		private MapCell[] Cells;

		public int W;
		public int H;

		public Map(int w, int h)
		{
			if (
				w < 1 || IntTools.IMAX < w ||
				h < 1 || IntTools.IMAX < h
				)
				throw new DDError();

			this.Cells = new MapCell[w * h];

			for (int index = 0; index < this.Cells.Length; index++)
				this.Cells[index] = new MapCell();

			this.W = w;
			this.H = h;

			this.DefaultCell_2_Wall.Wall_2.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_4_Wall.Wall_4.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_6_Wall.Wall_6.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_8_Wall.Wall_8.Kind = MapWall.Kind_e.WALL;
		}

		private MapCell DefaultCell = new MapCell();
		private MapCell DefaultCell_2_Wall = new MapCell();
		private MapCell DefaultCell_4_Wall = new MapCell();
		private MapCell DefaultCell_6_Wall = new MapCell();
		private MapCell DefaultCell_8_Wall = new MapCell();

		public MapCell this[int x, int y]
		{
			get
			{
				if (
					x < 0 || this.W <= x ||
					y < 0 || this.H <= y
					)
				{
					if (0 <= y && y < this.H)
					{
						if (x == -1)
							return this.DefaultCell_6_Wall;

						if (x == this.W)
							return this.DefaultCell_4_Wall;
					}
					if (0 <= x && x < this.W)
					{
						if (y == -1)
							return this.DefaultCell_2_Wall;

						if (y == this.H)
							return this.DefaultCell_8_Wall;
					}
					return this.DefaultCell;
				}
				return this.Cells[x + y * this.W];
			}
		}

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

		public bool Find(out int x, out int y, Predicate<MapCell> match)
		{
			for (x = 0; x < this.W; x++)
				for (y = 0; y < this.H; y++)
					if (match(this[x, y]))
						return true;

			x = -1;
			y = -1;

			return false;
		}
	}
}
