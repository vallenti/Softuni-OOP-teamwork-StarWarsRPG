using RPG.Models;

namespace RPG.Interfaces
{
	internal interface IStormtrooperFactory
	{
		ICharacter CreateStormtrooper(Position position);
	}
}