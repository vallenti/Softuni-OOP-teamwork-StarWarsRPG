using RPG.Models;
using System;
using System.Runtime.CompilerServices;

namespace RPG.Models.Items
{
	public abstract class Item : GameObject
	{
		public Item(Position position, char symbol) 
            : base(position, symbol)
		{
			this.State = ItemState.Available;
		}
        public ItemState State { get; set; }
    }
}