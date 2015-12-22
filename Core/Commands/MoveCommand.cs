using RPG.Interfaces;
using RPG.Models;
using RPG.Models.Characters;
using RPG.Models.Items;
using RPG.Models.Items.Weapons;
using System;
using System.Linq;

namespace RPG.Core.Commands
{
	internal class MoveCommand : Command
	{
		public MoveCommand(IEngine engine) 
            : base(engine)
		{
		}



		public override void Execute(string[] commandArgs)
		{
			string str = commandArgs[1];
			Jedi player = base.Engine.GameData.Player;
			player.Move(str);
			base.Engine.Writer.Print(string.Concat("Jedi moved ", str));

            var enemy = this.Engine.GameData.Enemies
                .Where(o => o.Position.X == player.Position.X
                && o.Position.Y == player.Position.Y)
                .FirstOrDefault();
			if (enemy != null)
			{
				this.GetIntoFight(player, enemy);
			}

			this.CheckForLighsaber(player);
            this.CheckForForceBall(player);
		}
        private void CheckForLighsaber(ICharacter player)
        {
          var lightsaber = this.Engine.GameData.Objects
                .Where(o => o is Weapon)
                .Cast<Lightsaber>()
                .Where(o => o.Position.X == player.Position.X
                && o.Position.Y == player.Position.Y
                && o.State == ItemState.Available)
                .FirstOrDefault();

            if (lightsaber != null)
            {
                player.Damage = lightsaber.Damage;
                lightsaber.State = ItemState.NotAvailable;
                base.Engine.Writer.Print(string.Concat("Jedi picked up a light saber. Now his damage is ", player.Damage));
            }
        }
        private void CheckForForceBall(ICharacter p)
        {
            var player = p as Jedi;

            var fb = this.Engine.GameData.Objects
                .Where(o => o is ForceBall)
                .Cast<ForceBall>()
                .Where(o => o.Position.X == player.Position.X
                && o.Position.Y == player.Position.Y
                && o.State == ItemState.Available)
                .FirstOrDefault();
            if (fb != null)
            {
                player.IncreaseForcePoints(fb.ForceRestore);
                fb.State = ItemState.NotAvailable;
                this.Engine.Writer.Print(string.Concat("Jedi felt the force. Force: ", player.ForcePoints));
            }
        }
        private void GetIntoFight(ICharacter player, ICharacter enemy)
		{
			while (enemy.IsAlive)
			{            
                if (!player.IsAlive)
                {
                    this.Engine.Writer.Print("Young jedi died. Game over!");
                    this.Engine.IsRunning = false;
                    break;
                }
                player.Attack(enemy);
			    enemy.Attack(player);
			}
			this.Engine.Writer.Print("One stormtrooper died. Keep going.");
		}
	}
}