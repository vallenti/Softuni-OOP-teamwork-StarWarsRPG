using RPG.Interfaces;
using RPG.Models;
using RPG.Models.Items.Weapons;
using System;

namespace RPG.Core.Factories
{
	public class WeaponFactory : IWeaponFactory
	{
		public Weapon CreateWeapon(Position position)
		{
			return new Lightsaber(position);
		}
	}
}