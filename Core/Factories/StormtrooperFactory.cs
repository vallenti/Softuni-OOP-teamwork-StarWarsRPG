using RPG.Interfaces;
using RPG.Models;
using RPG.Models.Characters;
using System;

namespace RPG.Core.Factories
{
	internal class StormtrooperFactory : IStormtrooperFactory
	{
		public ICharacter CreateStormtrooper(Position position)
		{
			return new Stormtrooper(position);
		}
	}
}