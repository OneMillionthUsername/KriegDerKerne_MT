using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private readonly string _name = "<-O->";

		//init props
		private int _x;
		private int _y;
		public int Y
		{
			get { return _y; }
			set
			{
				_y = Y < 1 ? 1 : value;
				_y = Y > _maxY ? _maxY : value;
			}
		}
		public int X
		{
			get { return _x; }
			set
			{
				_x = X < 1 ? 1 : value;
				_x = X > _maxX ? _maxX : value;
			}
		}

		//Konstruktor
		public Player()
		{
			X = _maxX / 2;
			Y = _maxY;
			Name = _name;
			DrawEntity(X, Y);
		}

		// Methoden
		public void Move()
		{
			do
			{
				DrawEntity();
				if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
				{
					Laser _ = new(X, Y);
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					Console.SetCursorPosition(X, Y);
					DeleteEntity();
					X -= 1;

					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					Console.SetCursorPosition(X, Y);
					DeleteEntity();
					X += 1;
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					Console.SetCursorPosition(X, Y);
					DeleteEntity();
					Y -= 1;
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					Console.SetCursorPosition(X, Y);
					DeleteEntity();
					Y += 1;
					DrawEntity();
					continue;
				}
				Thread.Sleep(10);
			} while (true);
		}
		
	}
}
