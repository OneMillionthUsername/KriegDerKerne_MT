using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private readonly string _name = "<-O->";

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
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					DeleteEntity();
					Console.SetCursorPosition(PosX, PosY);
					PosX -= 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					DeleteEntity();
					Console.SetCursorPosition(PosX, PosY);
					PosX += 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					DeleteEntity();
					Console.SetCursorPosition(PosX, PosY);
					PosY -= 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					DeleteEntity();
					Console.SetCursorPosition(PosX, PosY);
					PosY += 1;
					DrawEntity();
				} 
		}
		public void Shoot()
		{
			//SPIELER POSITION WIRD FALSCH AKTUALISIERT!
			//Methode in die Laser Klasse verschieben?
			do
			{
				// Konstruktor und bringe Cursor in richtiger Position
				Laser laser = new(PosX += 2, PosY -= 1);
				// shoot
				for (int i = 0; i < laser._maxY; i++)
				{
					if (laser.PosY == _maxY || laser.PosX >= _maxX)
					{
						laser.DeleteEntity();
						break;
					}
					Console.SetCursorPosition(laser.PosX, laser.PosY);
					laser.DeleteEntity();
					laser.PosY -= 1;
					laser.DrawEntity();
					if (laser.PosY == 0)
					{
						laser.DeleteEntity();
						break;
					}
					if (laser.PosY == laser._maxY)
					{
						laser.DeleteEntity();
						break;
					}
					Thread.Sleep(100);
				}
			} while (true);
		}
	}
}
