using RPG.Models;
using RPG.Models.Items;
using System;
using System.Runtime.CompilerServices;

namespace RPG.Models.Items.Weapons
{
	public abstract class Weapon : Item
	{

		public Weapon(Position position, char symbol, int damage) 
            : base(position, symbol)
		{
			this.Damage = damage;
		}
        public int Damage { get; set; }
    }
}