using RPG.Models;
using System;
using System.Runtime.CompilerServices;

namespace RPG.Models.Items
{
	public class ForceBall : Item
	{
		private const char FBSymbol = 'O';

		public ForceBall(Position position, ForceBallPower power) 
            : base(position, FBSymbol)
		{
			this.Power = power;
			base.State = ItemState.Available;
		}
        public int ForceRestore
        {
            get
            {
                return (int)this.Power;
            }
        }

        public ForceBallPower Power { get; set; }

    }
}