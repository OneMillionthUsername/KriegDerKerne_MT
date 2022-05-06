using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private readonly string _name = "|";
		//init props

		//Konstruktor
		public Laser(int x, int y)
		{
			//bringe Cursor in richtiger Position
			//Console.SetCursorPosition(x, y);
			X = x + 2;
			Y = y - 1;
			Name = _name;
			//brauch ich wirklich einen Thread?
			//Thread shoot = new(new ThreadStart(() => Shoot()));
			//shoot.Start();
		}
		// Methoden
		internal bool Shoot()
		{
			//Startposition Laser
			//int i = Y;
			//DrawEntity();
			//shoot
			//DeleteEntity();
			Console.SetCursorPosition(X, Y);
			if (!(Y >= _maxY - 2))
			{
				Y -= 1;
				return true;
			}
			else
				return false;
			
			//verändere den Wert und gib ihn zurück => Zeichne im nächsten Frame
			//DrawEntity();
			//i--;
			//Thread.Sleep(50);
			//DeleteEntity();
		}
	}
}
