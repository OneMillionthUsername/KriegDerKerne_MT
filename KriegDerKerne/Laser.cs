using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private readonly string _name = "|";

		//init props
		private int _x;
		private int _y;
		public new int Y
		{
			get { return _y; }
			set
			{
				_y = Y < 0 ? 0 : value;
				_y = Y > _maxY ? _maxY : value;
			}
		}
		public new int X
		{
			get { return _x; }
			set
			{
				_x = X < 0 ? 0 : value;
				_x = X > _maxX ? _maxX : value;
			}
		}

		//Konstruktor
		public Laser(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			//bringe Cursor in richtiger Position
			X = x+2;
			Y = y-1;
			Name = _name;

			Thread shoot = new(new ThreadStart(() => Shoot()));
			shoot.Start();
		}
		// Methoden
		public void Shoot()
		{
			//Startposition Laser
			int i = Y;
			DrawEntity(X, Y);
			//SPIELER POSITION WIRD FALSCH AKTUALISIERT!
			//Methode in die Laser Klasse verschieben?
			do
			{
				// shoot
				DeleteEntity(X, Y);
				Console.SetCursorPosition(X, Y);
				Y -= 1;
				DrawEntity(X, Y);

				if (Y == 0)
				{
					DeleteEntity(X, Y);
					break;
				}
				if (Y == _maxY)
				{
					DeleteEntity(X, Y);
					break;
				}
				i--;
				Thread.Sleep(50);
			} while (i > 0);
		}
	}
}
