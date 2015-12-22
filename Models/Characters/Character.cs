using RPG.Interfaces;
using RPG.Models.EventHandlers;

namespace RPG.Models.Characters
{
	public abstract class Character : GameObject, ICharacter, IAttacker
	{
		private int damage;

        public Character(string name, Position position, char symbol, int health, int damage)
            : base(position, symbol)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public int Damage
		{
			get
			{
				return this.damage;
			}
			set
			{
                
                if (this.OnDamageChange != null)
				{
					this.OnDamageChange(this, new DamageEventArgs(this.damage, value));
                    
                }
                this.damage = value;
            }
		}

		public int Health { get; set; }



		public bool IsAlive
		{
			get
			{
				return this.Health > 0;
			}
		}

		public string Name { get; set; }


		public abstract void Attack(ICharacter target);

		public abstract void Respond(ICharacter attacker);

		public event ChangingDamageEventHandler OnDamageChange;
	}
}