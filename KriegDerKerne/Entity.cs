using System;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	public abstract class Entity
	{
		//Felder
		private string _Name;
		private int _x;
		private int _y;
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
				_y = Y < 1 ? 1 : value;
				_y = Y > _maxY ? _maxY : value;
			}
		}
		public int X
		{
			get { return _x; }
			set
			{
				_x = X < 1 ? 1 : value;
				_x = X > _maxX ? _maxX : value;
			}
		}
		//methods
		public void DrawEntity()
		{
			Console.SetCursorPosition(X, Y);
			Console.Write(Name);
		}
		//Funktion für Laser
		public void DrawEntity(int x, int y)
		{
			X = x;
			Y = y;
			Console.SetCursorPosition(X, Y);
			//Console.Write(Name + " x: " + x + " y: " + y);
			Console.Write(Name);
		}
		public void DeleteEntity()
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(X, Y);
			Console.Write(Name);
			Name = temp;
		}
		//Funktion für Laser
		public void DeleteEntity(int x, int y)
		{
			X = x;
			Y = y;
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(X, Y);
			Console.Write(Name);
			Name = temp;
		}
	}
}
