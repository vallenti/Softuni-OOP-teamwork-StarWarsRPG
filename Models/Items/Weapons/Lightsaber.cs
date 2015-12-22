using RPG.Models;
using System;

namespace RPG.Models.Items.Weapons
{
	public class Lightsaber : Weapon
	{
		private const int LightsaberDamage = 50;

		private const char LightsaberSymbol = '!';

		public Lightsaber(Position position) 
            : base(position, LightsaberSymbol, LightsaberDamage)
		{
		}
	}
}