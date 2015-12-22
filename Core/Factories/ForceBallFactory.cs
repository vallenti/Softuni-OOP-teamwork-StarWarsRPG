using RPG.Interfaces;
using RPG.Models;
using RPG.Models.Items;
using System;

namespace RPG.Core.Factories
{
	public class ForceBallFactory : IForceBallFactory
	{

		public ForceBall CreateForceBall(Position position, ForceBallPower power)
		{
			return new ForceBall(position, power);
		}
	}
}