﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Game3Common;

namespace Charlotte.Games
{
	public interface IWeapon
	{
		void Loaded(D2Point pt);
		bool EachFrame(); // ? 生存
		Crash GetCrash();
		bool Crashed(IEnemy enemy); // ? 生存
		int GetAttackPoint();
		void Draw();
	}
}
