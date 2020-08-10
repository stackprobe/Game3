using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;
using Charlotte.Games;
using Charlotte.Tools;

namespace Charlotte.Tests.Games
{
	public class MapTileManagerTest
	{
		public void Test01()
		{
			int index = 0;

			for (; ; )
			{
				if (DDInput.DIR_8.IsPound())
				{
					index -= Consts.SCREEN_MAP_W;
				}
				if (DDInput.DIR_4.IsPound())
				{
					index--;
				}
				if (DDInput.DIR_6.IsPound())
				{
					index++;
				}
				if (DDInput.DIR_2.IsPound())
				{
					index += Consts.SCREEN_MAP_W;
				}
				index += MapTileManager.GetCount();
				index %= MapTileManager.GetCount();

				// 描画 ...

				DDCurtain.DrawCurtain();

				{
					int i = index;

					for (int y = 0; y < Consts.SCREEN_MAP_H; y++)
					{
						for (int x = 0; x < Consts.SCREEN_MAP_W; x++)
						{
							DDDraw.DrawSimple(MapTileManager.GetTile(MapTileManager.GetNames()[i]).Picture, x * MapTile.WH, y * MapTile.WH);

							i++;
							i %= MapTileManager.GetCount();
						}
					}
				}

				DDPrint.SetPrint();
				DDPrint.SetBorder(new I3Color(0, 64, 0));

				for (int i = 0; i < 40; i++)
				{
					DDPrint.PrintLine("[" + i.ToString("D2") + "] " + MapTileManager.GetNames()[(index + i) % MapTileManager.GetCount()]);
				}
				DDPrint.Reset();

				DDEngine.EachFrame();
			}
		}
	}
}
