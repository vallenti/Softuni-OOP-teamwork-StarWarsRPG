using RPG.Models;
using RPG.Models.Items.Weapons;

namespace RPG.Interfaces
{
	public interface IWeaponFactory
	{
		Weapon CreateWeapon(Position position);
	}
}