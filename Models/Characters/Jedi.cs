using RPG.Interfaces;
using RPG.Models.Characters;
using System;

namespace RPG.Models
{
	public class Jedi : Character, IAttacker
	{
		private const int JediHealth = 100;
		private const int JediDamage = 10;
		private const int JediForcePoints = 300;
		private readonly static Position JediInitialPosition = new Position(0,0);
		private const string JediName = "Luke";
		private const char JediSymbol = 'J';
		private int forcePoints;

		public Jedi() 
            : base(JediName, JediInitialPosition, JediSymbol, JediHealth, JediDamage)
		{
			this.ForcePoints = JediForcePoints;
		}
        public int ForcePoints
        {
            get
            {
                return this.forcePoints;
            }
            set
            {
                this.forcePoints = value;
                if (this.forcePoints <= 0)
                {
                    this.forcePoints = 0;
                    throw new ArgumentException("not enough force to attack");
                }
            }
        }
        public override void Attack(ICharacter target)
		{
			this.ForcePoints -= this.Damage;
			target.Respond(this);
		}

		public void IncreaseForcePoints(int points)
		{
			this.ForcePoints += points;
		}

		public void Move(string direction)
		{
            switch(direction)
            {
                case "up":
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
                case "down":
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case "left":
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case "right":
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                default:
                    throw new ArgumentException("invalid direction");
            }

			
		}

		public override void Respond(ICharacter attacker)
		{
			this.Health -= attacker.Damage;
		}

		public override string ToString()
		{
            return $"Health: {this.Health}, Damage: {this.Damage}, Force: {this.ForcePoints}";
		}
	}
}