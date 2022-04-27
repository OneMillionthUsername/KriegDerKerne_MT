using System;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";
		readonly Random rnd = new();
		private int dice;

		private int _x;
		private int _y;

		public int Y
		{
			get { return _y; }
			private set
			{
				_y = _y < 1 ?  1 : value;
				_y = _y > _maxY ? _maxY : value;
			}
		}
		public int X
		{
			get { return _x; }
			private set
			{
				_x = _x < 1 ? 1 : value;
				_x = _x > _maxX ? _maxX : value;
			}
		}

		//Konstruktor
		public Enemy(int x, int y)
		{
			X = x;
			Y = y;
			Name = _name;
		}

		//Methoden
		public void MoveRandom()
		{
			//Lösche Gegner auf pos xy
			DeleteEntity(X, Y);
			//berechne position neu
			#region POSITION BERECHNEN
			//if (Y > 0 && Y < _maxY)
			//{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					Y -= 1;
				}
				else
				{
					Y += 1;
				}
			//}
			//if (X > 0 && X < _maxX)
			//{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					X -= 1;
				}
				else
				{
					X += 1;
				}
			//}
			DrawEntity(X, Y);
			Thread.Sleep(20);
			#endregion
		}
	}
}
