using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private readonly string _name = "|";

		//Konstruktor
		public Laser(int x, int y)
		{
			//bringe Cursor in richtiger Position
			Console.SetCursorPosition(x, y);
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
			do
			{
				// shoot
				DeleteEntity();
				Console.SetCursorPosition(_x, _y);
				_y -= 1;
				DrawEntity();

				if (_y == 0)
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
