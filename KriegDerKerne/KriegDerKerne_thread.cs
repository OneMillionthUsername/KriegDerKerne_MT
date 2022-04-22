using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace KriegDerKerne
{
	class KriegDerKerne
	{
		static void Main()
		{
			//initialisiere Variablen und Objekte
			Random rnd = new();
			Console.CursorVisible = false;
			int anzahlEnemies = 5, dice = 0;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			List<Enemy> enemies = new();
			List<Thread> threads = new();

			// erzeuge Objekte und füge sie zu einer Liste
			// erzeuge die Gegner
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}
			foreach (Enemy e in enemies)
			{
				e.DrawEntity();
				Thread rndMove = new(new ThreadStart(() => e.MoveRandom()));
				rndMove.Start();
			}

			//Erzeuge den Spieler
			Player player = new();
			player.DrawEntity();

			//erzeuge die Threads
			//Thread playerMove = new(new ThreadStart(() => player.Move()));
			//Thread playerShoot = new(new ThreadStart(() => player.Shoot()));
			Thread checkInput = new(new ThreadStart(() => Input()));
			Thread BufferThread = new(new ThreadStart(() => Buffer(Input(), player)));
			Thread Draw = new(new ThreadStart(() => DrawGraphics(player)));

			//starte die Threads
			Threads(checkInput, BufferThread, Draw);

			do
			{
				foreach (Enemy enemy in enemies)
				{
					DrawGraphics(enemy);
				};
				DrawGraphics(player);
			} while (true);

			//Hauptschleife
			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void Threads(params Thread[] threads)
		{
			ConcurrentQueue<Thread> q = new();

			foreach (Thread thread in threads)
			{
				thread.Start();
				q.Enqueue(thread);
			}
		}
		public static ConsoleKey Input()
		{
			//if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
			//{
			//	return ConsoleKey.Spacebar;
			//}
			if (Console.ReadKey(true).Key == ConsoleKey.A)
			{
				return ConsoleKey.A;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.D)
			{
				return ConsoleKey.D;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.W)
			{
				return ConsoleKey.W;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.S)
			{
				return ConsoleKey.S;
			}
			return ConsoleKey.Spacebar;
		}
		public static void Buffer(ConsoleKey consoleKey, Entity entity)
		{
			do
			{
				if (0 == consoleKey.CompareTo(ConsoleKey.Spacebar))
				{
					//Schussbereit
				}
				if (0 == consoleKey.CompareTo(ConsoleKey.A))
				{
					//move left
					entity.PosX -= 1;
				}
				if (0 == consoleKey.CompareTo(ConsoleKey.S))
				{
					//move down
					entity.PosY -= 1;
				}
				if (0 == consoleKey.CompareTo(ConsoleKey.D))
				{
					//move right
					entity.PosX += 1;
				}
				if (0 == consoleKey.CompareTo(ConsoleKey.W))
				{
					//move up
					entity.PosY += 1;
				}
			} while (true);
		}
		public static void DrawGraphics(Entity entity)
		{
			entity.DeleteEntity();
			entity.DrawEntity();
		}
	}
}
