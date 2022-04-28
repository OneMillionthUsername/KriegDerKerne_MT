using System;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";

		//Konstruktor
		public Enemy(int x, int y)
		{
			_x = x;
			_y = y;
			Name = _name;
		}
	}
}
