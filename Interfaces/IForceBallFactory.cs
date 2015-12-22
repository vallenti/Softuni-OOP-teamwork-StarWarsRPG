using RPG.Models;
using RPG.Models.Items;

namespace RPG.Interfaces
{
	public interface IForceBallFactory
	{
		ForceBall CreateForceBall(Position position, ForceBallPower power);
	}
}