using RPG.Models;
using System;

namespace RPG.Models.EventHandlers
{
	public delegate void ChangingDamageEventHandler(object sender, DamageEventArgs e);
}