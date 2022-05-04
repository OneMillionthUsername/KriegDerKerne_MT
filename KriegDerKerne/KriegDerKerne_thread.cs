using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace KriegDerKerne
{
	class KriegDerKerne : Entity
	{
		static void Main()
		{
			//initialisiere Variablen und Objekte
			Random rnd = new();
			Console.CursorVisible = false;
			int anzahlEnemies = 5;
			int score = 0;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			List<Enemy> enemies = new();
			List<Thread> threads = new();

			// erzeuge die Gegner
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}

			//Erzeuge Spieler		
			Player player = new();

			//erzeuge Threads
			Thread pMove = new(new ThreadStart(() => player.Move()));
			Threads(pMove);

			//Hauptschleife
			do
			{
				foreach (Enemy e in enemies)
				{
					e.MoveRandom();
				}
				//code
				DrawScore(score);
			} while (true);
			
			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void DrawScore(int score)
		{
			Console.SetCursorPosition(left: 0, top: 0);
			Console.Write(new string(" ").PadRight(Console.WindowWidth));
			Console.SetCursorPosition(left: Console.WindowWidth-$"Punkte: {score}".Length, top: 0);
			Console.WriteLine("Punkte: " + score);
		}
		public static void Threads(params Thread[] threads)
		{
			foreach (Thread thread in threads)
			{
				if (thread.ThreadState != ThreadState.Running)
				{
					thread.Start();
				}
			}
		}
	}
}
