using System;
using System.Threading;
using System.Collections;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly Random rnd = new();
		private int dice = new();
		private readonly string _name = "\\_I_/";
		private readonly Queue q = new();
		
		//Konstruktor
		public Enemy(int x, int y)
		{
			X = x;
			Y = y;
			Name = _name;
			
			Thread enemyMove = new(new ThreadStart(() => MoveRandom()));
			enemyMove.Start();
			q.Enqueue(enemyMove);
			//Queue.Synchronized(q);
		}
		//methods
		public void MoveRandom()
		{
			do
			{
				//Lösche Gegner auf pos xy
				DeleteEntity();
				//berechne position neu
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					Y -= 1;
				}
				else
				{
					Y += 1;
				}
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					X -= 1;
				}
				else
				{
					X += 1;
				}
				DrawEntity();
				Thread.Sleep(200); 
			} while (true);
		}
	}
}
