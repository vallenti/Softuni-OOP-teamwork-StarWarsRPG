using System;

namespace RPG.Interfaces
{
	public interface IAttacker
	{
		bool IsAlive { get; }

		void Attack(ICharacter target);

		void Respond(ICharacter attacker);
	}
}