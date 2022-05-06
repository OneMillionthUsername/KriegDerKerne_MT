using System;
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
			int score = new(); ;
			int frame = new();
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			List<Enemy> enemies = new();

			// erzeuge die Gegner
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}
			//Erzeuge Spieler		
			Player player = new();
			Laser laser = new(player.X, player.Y);

			//erzeuge Threads
			//Thread pMove = new(new ThreadStart(() => player.Move()));
			//Threads(pMove);

			//Hauptschleife
			do
			{
				//code
				LöscheDisplay(enemies, player, laser);
				VerändereWerte(enemies, player, laser);
				Ausgabe(enemies, player, laser);
				DrawScore(ref score, ref frame);
				Thread.Sleep(100);
			} while (true);

			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}

		private static void LöscheDisplay(List<Enemy> enemies, Player player, Laser laser)
		{
			foreach (var item in enemies)
			{
				item.DeleteEntity();
			}
			player.DeleteEntity();
		}

		private static void Ausgabe(List<Enemy> enemies, Player player, Laser laser)
		{
			foreach (var item in enemies)
			{
				item.DrawEntity();
			}
			player.DrawEntity();
		}

		private static void VerändereWerte(List<Enemy> enemies, Player player, Laser laser)
		{
			foreach (var item in enemies)
			{
				item.MoveRandom();
			}
			//IF TASTE GEDRÜCKT
			if (Console.KeyAvailable)
			{
				player.Move(); 
			}
		}

		public static void DrawScore(ref int score, ref int frame)
		{
			frame++;
			Console.SetCursorPosition(left: 0, top: 0);
			Console.Write(new string(" ").PadRight(Console.WindowWidth));
			Console.SetCursorPosition(left: Console.WindowWidth - $"Punkte: {score}".Length, top: 0);
			Console.WriteLine($"Punkte: {score}");
			Console.SetCursorPosition(left: 0, top: 0);
			Console.WriteLine($"Frame: {frame}");
		}
	}
}
