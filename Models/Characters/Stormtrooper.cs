using RPG.Interfaces;
using RPG.Models;
using System;

namespace RPG.Models.Characters
{
	public class Stormtrooper : Character, IAttacker
	{
		private const string SName = "Stormy";

		private const int SHealth = 20;

		private const int SDamage = 20;

		public Stormtrooper(Position position) 
            : base(SName, position, 'S', SHealth, SDamage)
		{
		}

		public override void Attack(ICharacter target)
		{
			target.Respond(this);
		}

		public override void Respond(ICharacter attacker)
		{
			this.Health -= attacker.Damage;
		}
        public override string ToString()
        {
            return $"Health: {this.Health}, Damage: {this.Damage}";
        }
    }
}