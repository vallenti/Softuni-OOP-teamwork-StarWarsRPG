using RPG.Models;
using System;

namespace RPG.Interfaces
{
	public interface ICharacter : IAttacker
	{
		int Damage { get; set; }

		int Health { get; }

		string Name { get; }

		Position Position { get; }

    }
}