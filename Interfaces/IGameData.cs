using RPG.Models;
using RPG.Models.Characters;
using RPG.Models.Items;
using System;
using System.Collections.Generic;

namespace RPG.Interfaces
{
	public interface IGameData
	{
		IList<Stormtrooper> Enemies { get; }

		char[,] GameBoard{ get; }

        IList<Item> Objects{ get; }

        Jedi Player{ get; }

        void Draw(IOutputRenderer renderer);
	}
}