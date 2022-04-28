using System;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";
		//readonly Random rnd = new();
		//private int dice;

		//private int _x;
		//private int _y;

		//public new int Y
		//{
		//	get { return _y; }
		//	set
		//	{
		//		if (Y < 1)
		//		{
		//			_y = 1;
		//		}
		//		else if (Y > _maxY)
		//		{
		//			_y = _maxY;
		//		}
		//		else
		//		{
		//			_y = value;
		//		}
		//	}
		//}
		//public new int X
		//{
		//	get { return _x; }
		//	set
		//	{
		//		if (X < 1)
		//		{
		//			_x = 1;
		//		}
		//		else if (X > _maxX)
		//		{
		//			_x = _maxX;
		//		}
		//		else
		//		{
		//			_x = value;
		//		}
		//	}
		//}

		//Konstruktor
		public Enemy(int x, int y)
		{
			_x = x;
			_y = y;
			Name = _name;
		}

		//Methoden
		//public void MoveRandom()
		//{
		//	//Lösche Gegner auf pos xy
		//	DeleteEntity();
		//	//berechne position neu
		//	#region POSITION BERECHNEN
		//	//if (Y > 0 && Y < _maxY)
		//	//{
		//		dice = rnd.Next(1, 2 + 1);
		//		if (dice > 1)
		//		{
		//			_y -= 1;
		//		}
		//		else
		//		{
		//			_y += 1;
		//		}
		//	//}
		//	//if (X > 0 && X < _maxX)
		//	//{
		//		dice = rnd.Next(1, 2 + 1);
		//		if (dice > 1)
		//		{
		//			_x -= 1;
		//		}
		//		else
		//		{
		//			_x += 1;
		//		}
		//	//}
		//	DrawEntity();
		//	Thread.Sleep(20);
		//	#endregion
		//}
	}
}
