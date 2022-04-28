using System;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	public abstract class Entity
	{
		//Felder
		readonly Random rnd = new();
		private int dice = new();
		private string _Name;
		protected int _x;
		protected int _y;
		public int _maxX = Console.WindowWidth - 1, _maxY = Console.WindowHeight - 1;
		//properties
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		public int Y
		{
			get { return _y; }
			set
			{
				if (Y < 1)
				{
					_y = 1;
				}
				else if (Y > _maxY)
				{
					_y = _maxY;
				}
				else
				{
					_y = value;
				}
			}
		}
		public int X
		{
			get { return _x; }
			set
			{
				if (X < 1)
				{
					_x = 1;
				}
				else if (X > _maxX)
				{
					_x = _maxX;
				}
				else
				{
					_x = value;
				}
			}
		}
		//methods
		public void DrawEntity()
		{
			Console.SetCursorPosition(_x, _y);
			Console.Write(Name);
		}
		//Funktion für Laser
		//public void DrawEntity(int x, int y)
		//{
		//	Console.SetCursorPosition(x, y);
		//	Console.Write(Name + " x: " + x + " y: " + y);
		//	Console.Write(Name);
		//}
		public void DeleteEntity()
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(_x, _y);
			Console.Write(Name);
			Name = temp;
		}
		public void MoveRandom()
		{
			//Lösche Gegner auf pos xy
			DeleteEntity();
			//berechne position neu
			#region POSITION BERECHNEN
			if (Y > 0 && Y < _maxY)
			{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					_y -= 1;
				}
				else
				{
					_y += 1;
				}
			}
			if (X > 0 && X < _maxX)
			{
				dice = rnd.Next(1, 2 + 1);
				if (dice > 1)
				{
					_x -= 1;
				}
				else
				{
					_x += 1;
				}
			}
			DrawEntity();
			//Thread.Sleep(20);
			#endregion
		}

		//Funktion für Laser
		//public void DeleteEntity(int x, int y)
		//{
		//	string temp = Name;
		//	Name = Name.Replace(Name, new String(' ', Name.Length));
		//	Console.SetCursorPosition(x, y);
		//	Console.Write(Name);
		//	Name = temp;
		//}
	}
}
