using System;
using System.Threading;

namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private string _name = "|";

		private int _laserPosX;
		private int _laserPosY;
		
		public int LaserPosY
		{
			get { return _laserPosY; }
			set { _laserPosY = value; }
		}

		public int LaserPosX
		{
			get { return _laserPosX; }
			set { _laserPosX = value; }
		}

		//Konstruktor
		public Laser(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			//bringe Cursor in richtiger Position
			LaserPosX = x+2;
			LaserPosY = y-1;
			Name = _name;
			Shoot();
		}
		// Methoden
		public void Shoot()
		{
			//SPIELER POSITION WIRD FALSCH AKTUALISIERT!
			//Methode in die Laser Klasse verschieben?
			do
			{
				// shoot
				for (int i = LaserPosY; i < _maxY; i++)
				{
					if (i == _maxY || i >= _maxX)
					{
						DeleteEntity(LaserPosX, LaserPosY);
						break;
					}
					DeleteEntity(LaserPosX, LaserPosY);
					Console.SetCursorPosition(LaserPosX, LaserPosY);
					LaserPosY -= 1;
					DrawEntity(LaserPosX, LaserPosY);

					if (LaserPosY == 0)
					{
						DeleteEntity(LaserPosX, LaserPosY);
						break;
					}
					if (LaserPosY == _maxY)
					{
						DeleteEntity(LaserPosX, LaserPosY);
						break;
					}
					Thread.Sleep(100);
				}
			} while (true);
		}
	}
}
