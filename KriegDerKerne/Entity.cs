using System;
using System.Threading;

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
		protected int _maxX = Console.WindowWidth - 1, _maxY = Console.WindowHeight - 1;
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
					_y = value;
			}
		}
		public int X
		{
			get { return _x; }
			set
			{
					_x = value;
			}
		}
		//methods
		public void DrawEntity()
		{
			Console.SetCursorPosition(_x, _y);
			Console.Write(Name);
		}
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
			if (_y > 0 && _y < _maxY)
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
			else
			{
				if (_y <= 0)
				{
					_y += 1;
				}
				if (_y >= _maxY)
				{
					_y -= 1;
				}
			}
			if (_x > 0 && _x < _maxX)
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
			else
			{
				if (_x <= 0)
				{
					_x += 1;
				}
				if (_x >= _maxY)
				{
					_x -= 1;
				}
			}
			DrawEntity();
			Thread.Sleep(20);
			#endregion
		}
	}
}
