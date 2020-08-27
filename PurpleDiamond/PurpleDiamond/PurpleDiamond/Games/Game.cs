using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class Game : IDisposable
	{
		public Map Map;

		// <---- prm

		public static Game I = null;

		public Game()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		private Player Player = new Player();

		private bool CamSlideMode; // ? モード中
		private int CamSlideCount;
		private int CamSlideX; // -1 ～ 1
		private int CamSlideY; // -1 ～ 1

		public int Frame;

		public void Perform()
		{
			for (; ; this.Frame++)
			{
				{
					double targCamX = this.Player.X - DDConsts.Screen_W / 2 + (this.CamSlideX * DDConsts.Screen_W / 3);
					double targCamY = this.Player.Y - DDConsts.Screen_H / 2 + (this.CamSlideY * DDConsts.Screen_H / 3);

					DDUtils.ToRange(ref targCamX, 0.0, this.Map.W * MapTile.WH - DDConsts.Screen_W);
					DDUtils.ToRange(ref targCamY, 0.0, this.Map.H * MapTile.WH - DDConsts.Screen_H);

					DDUtils.Approach(ref DDGround.Camera.X, targCamX, 0.8);
					DDUtils.Approach(ref DDGround.Camera.Y, targCamY, 0.8);
				}

				// 描画ここから

				this.DrawWall();
				this.DrawMap();
				this.Player.Draw();
				this.DrawEnemies();
				this.DrawWeapons();

				DDEngine.EachFrame();
			}
		}

		private void DrawWall()
		{
			DDCurtain.DrawCurtain(); // kari
		}

		private void DrawMap()
		{
		}

		private void DrawEnemies()
		{
			throw new NotImplementedException();
		}

		private void DrawWeapons()
		{
			throw new NotImplementedException();
		}
	}
}
