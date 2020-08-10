using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Mains;
using Charlotte.Common;

namespace Charlotte.Games.Rooms
{
	public class Room0001 : IRoom
	{
		public void DrawRoom()
		{
			DDDraw.DrawRect(DDGround.GeneralResource.Dummy, 0, 0, 1000, 1000);
		}
	}
}
