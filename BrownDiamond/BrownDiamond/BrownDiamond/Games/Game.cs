using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class Game : IDisposable
	{
		public IRoom Room;

		// <---- prm

		public static Game I;

		public Game()
		{
			I = this;
		}

		public void Dispose()
		{
			this.RoomScreen.Dispose();
			this.RoomScreen = null;

			I = null;
		}

		private DDSubScreen RoomScreen = new DDSubScreen(Consts.ROOM_W, Consts.ROOM_H);

		public void Perform()
		{
			DDEngine.FreezeInput();

			for (; ; )
			{
				DDMouse.UpdatePos();

				if (DDMouse.L.GetInput() == 1)
					break;

				using (this.RoomScreen.Section())
				{
					this.Room.DrawRoom();
				}

				// Draw ...

				DDDraw.DrawSimple(this.RoomScreen.ToPicture(), 0, 0);

				DDEngine.EachFrame();
			}
		}
	}
}
