using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Games;
using Charlotte.Games.Rooms;

namespace Charlotte.Tests.Games
{
	public class GameTest
	{
		public void Test01()
		{
			using (Game game = new Game())
			{
				game.Room = new Room0001();
				game.Perform();
			}
		}
	}
}
