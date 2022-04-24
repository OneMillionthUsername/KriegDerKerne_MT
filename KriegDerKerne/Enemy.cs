using System;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";
		Random rnd = new();
		private int dice;

		//Konstruktor
		public Enemy(int posX, int posY)
		{
			PosX = posX;
			PosY = posY;
			Name = _name;
		}
		//Methoden

		public void MoveRandom()
		{

			//warte auf Eingabe?
			//starte Bewegung der Gegner - Code aus der Klasse ausführen?
			//Lösche Gegner auf pos xy
			DeleteEntity();
			//berechne position neu
			#region POSITION BERECHNEN
			if (PosY > 0 && PosY < _maxY)
			{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					PosY -= 1;
				}
				else
				{
					PosY += 1;
				}
			}
			else
			{
				if (PosY == 0)
				{
					PosY += 1;
				}
				if (PosY == _maxY)
				{
					PosY -= 1;
				}
			}
			if (PosX > 0 && PosX < _maxX)
			{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					PosX -= 1;
				}
				else
				{
					PosX += 1;
				}
			}
			else
			{
				if (PosX == 0)
				{
					PosX += 1;
				}
				if (PosX == _maxX)
				{
					PosX -= 1;
				}
			}
			DrawEntity();
			#endregion
			Thread.Sleep(10);
		}
	}
}
