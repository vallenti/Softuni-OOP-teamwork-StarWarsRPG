using System;

namespace RPG.Models
{
	public class DamageEventArgs : EventArgs
	{
		public DamageEventArgs(int oldDamage, int newDamage)
		{
			this.OldDamage = oldDamage;
			this.NewDamage = newDamage;
		}

        public int NewDamage { get; set; }
        public int OldDamage { get; set; }
    }
}