﻿using System;
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
			int anzahlEnemies = 5;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			List<Enemy> enemies = new();
			List<Thread> threads = new();
			ConcurrentQueue<Thread> q = new();

			// erzeuge Objekte und füge sie zu einer Liste
			// erzeuge die Gegner
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}

			//Erzeuge den Spieler
			Player player = new();
			player.DrawEntity();

			//erzeuge die Threads
			Thread pMove = new(new ThreadStart(() => player.Move()));
			//Thread shoot = new(new ThreadStart(() => player.Shoot()));
			Threads(pMove);

			//Hauptschleife
			do
			{
				foreach (Enemy e in enemies)
				{
					e.MoveRandom();
				}
				//starte die Threads
				//code
			} while (true);

			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
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
