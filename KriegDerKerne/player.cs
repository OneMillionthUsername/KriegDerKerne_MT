using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private string _name = "<-O->";

		//init props

		//Konstruktor
		public Player()
		{
			PosX = _maxX / 2;
			PosY = _maxY;
			Name = _name;
		}
		// Methoden

		public void Move()
		{
			do
			{
				if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
				{
					Laser laser = new(PosX, PosY);
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX -= 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX += 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY -= 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY += 1;
					DrawEntity();
					continue;
				}
			} while (true);
		}
		
	}
}
