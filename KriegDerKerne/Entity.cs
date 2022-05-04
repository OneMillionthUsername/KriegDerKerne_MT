using System;
using System.Threading;

namespace KriegDerKerne
{
	public abstract class Entity
	{
		//Felder
		private string _Name;
		private int _x;
		private int _y;
		private readonly int _maxX = Console.WindowWidth;
		private readonly int _maxY = Console.WindowHeight - 2;

		//constructor

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
				if (value > 0 && value < _maxY + 2)
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
				if (value > 0 && value < _maxX - 5)
				{
					_x = value;
				}
			}
		}
		//methods
		public void DrawEntity()
		{
			Console.SetCursorPosition(X, Y);
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
		//DeleteLine produziert Grafikbugs 
		//public static void DeleteLine()
		//{
		//	Console.SetCursorPosition(left: 0, top: 0);
		//	Console.Write(new string(" ").PadRight(Console.WindowWidth));
		//}
	}
}
