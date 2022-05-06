using System;
using System.Threading;
using System.Collections;
using System.Collections.Concurrent;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly Random rnd = new();
		private int dice = new();
		private readonly string _name = "\\_I_/";

		//Konstruktor
		public Enemy(int x, int y)
		{
			X = x;
			Y = y;
			Name = _name;
		}
		//methods
		public void MoveRandom()
		{
			//Lösche Gegner auf pos xy
			//DeleteEntity();
			//berechne position neu
			dice = rnd.Next(1, 2 + 1);
			if (dice > 1)
			{
				Y -= 1;
			}
			else
			{
				Y += 1;
			}
			dice = rnd.Next(1, 2 + 1);
			if (dice > 1)
			{
				X -= 1;
			}
			else
			{
				X += 1;
			}
			//DrawEntity();
			//Thread.Sleep(20);
		}
	}
}
