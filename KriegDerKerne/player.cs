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
			X = Console.WindowWidth / 2;
			Y = Console.WindowHeight - 1;
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
					continue;
				}
				Thread.Sleep(10);
			} while (true);
		}

	}
}
