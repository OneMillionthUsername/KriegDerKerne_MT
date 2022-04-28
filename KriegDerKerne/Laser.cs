using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private readonly string _name = "|";

		//init props
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
		public Laser(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			//bringe Cursor in richtiger Position
			_x = x+2;
			_y = y-1;
			Name = _name;

			Thread shoot = new(new ThreadStart(() => Shoot()));
			shoot.Start();
		}
		// Methoden
		public void Shoot()
		{
			//Startposition Laser
			int i = _y;
			DrawEntity();
			//SPIELER POSITION WIRD FALSCH AKTUALISIERT!
			//Methode in die Laser Klasse verschieben?
			do
			{
				// shoot
				DeleteEntity();
				Console.SetCursorPosition(X, Y);
				Y -= 1;
				DrawEntity();

				if (Y == 0)
				{
					DeleteEntity();
					break;
				}
				if (Y == _maxY)
				{
					DeleteEntity();
					break;
				}
				i--;
				Thread.Sleep(50);
			} while (i > 0);
		}
	}
}
