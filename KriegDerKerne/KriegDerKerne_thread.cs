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

			//Erzeuge den Spieler
			Player player = new();

			//erzeuge die Threads
			//Thread playerMove = new(new ThreadStart(() => player.Move()));
			//Thread playerShoot = new(new ThreadStart(() => player.Shoot()));
			Thread checkInput = new(new ThreadStart(() => Input(player)));
			Thread Draw = new(new ThreadStart(() => DrawGraphics(player)));
			Thread pMove = new(new ThreadStart(() => player.Move()));

			//Hauptschleife

			do
			{
				foreach (Enemy e in enemies)
				{
					//e.DrawEntity();
					e.MoveRandom();
					//Thread rndMove = new(new ThreadStart(() => e.MoveRandom()));
					//Thread DrawEnemy = new(new ThreadStart(() => DrawGraphics(e)));
					//Threads(rndMove);
				}

				//starte die Threads
				Threads(Draw, pMove);
				//code
			} while (true);
			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void Threads(params Thread[] threads)
		{
			ConcurrentQueue<Thread> q = new();

			foreach (Thread thread in threads)
			{
				if(thread.ThreadState != ThreadState.Running)
				{
					thread.Start();
					q.Enqueue(thread); 
				} 
			}
		}
		public static void Input(Entity entity)
		{
			if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
			{

			}
			if (Console.ReadKey(true).Key == ConsoleKey.A)
			{
				//move left
				entity.PosX -= 1;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.D)
			{
				//move right
				entity.PosX += 1;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.W)
			{
				//move up
				entity.PosY += 1;
			}
			if (Console.ReadKey(true).Key == ConsoleKey.S)
			{
				//move down
				entity.PosY -= 1;
			}
		}
		public static void Buffer(ConsoleKey consoleKey, Entity entity)
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
		}
		public static void DrawGraphics(Entity entity)
		{
			entity.DeleteEntity();
			entity.DrawEntity();
		}
	}
}
