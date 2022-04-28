using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private readonly string _name = "<-O->";

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
					DrawEntity();
					continue;
				}
				Thread.Sleep(10);
			} while (true);
		}
		
	}
}
