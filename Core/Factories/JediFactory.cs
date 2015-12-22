using RPG.Interfaces;
using RPG.Models;
using System;

namespace RPG.Core.Factories
{
	internal class JediFactory : IJediFactory
	{

		public ICharacter CreateJedi()
		{
			return new Jedi();
		}
	}
}