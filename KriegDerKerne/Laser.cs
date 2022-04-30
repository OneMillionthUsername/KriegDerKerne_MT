using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Entity
	{
		//init fields
		private readonly string _name = "|";

		//Konstruktor
		public Laser(int x, int y)
		{
			//bringe Cursor in richtiger Position
			Console.SetCursorPosition(x, y);
			X = x + 2;
			Y = y - 1;
			Name = _name;

			Thread shoot = new(new ThreadStart(() => Shoot()));
			shoot.Start();
		}
		// Methoden
		private void Shoot()
		{
			//Startposition Laser
			int i = Y;
			DrawEntity();
			do
			{
				// shoot
				DeleteEntity();
				Console.SetCursorPosition(X, Y);
				Y -= 1;
				DrawEntity();
				i--;
				Thread.Sleep(50);
			} while (i > 0);
			DeleteEntity();
		}
	}
}
