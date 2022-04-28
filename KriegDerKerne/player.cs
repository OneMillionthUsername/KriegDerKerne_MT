using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private readonly string _name = "<-O->";

		//Konstruktor
		public Player()
		{
			_x = _maxX / 2;
			_y = _maxY;
			Name = _name;
			DrawEntity();
		}

		// Methoden
		public void Move()
		{
			do
			{
				DrawEntity();
				if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
				{
					Laser _ = new(_x, _y);
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					Console.SetCursorPosition(_x, _y);
					DeleteEntity();
					_x -= 1;
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					Console.SetCursorPosition(_x, _y);
					DeleteEntity();
					_x += 1;
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					Console.SetCursorPosition(_x, _y);
					DeleteEntity();
					_y -= 1;
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					Console.SetCursorPosition(_x, _y);
					DeleteEntity();
					_y += 1;
					continue;
				}
				Thread.Sleep(10);
			} while (true);
		}
		
	}
}
