using RPG.Interfaces;
using System;

namespace RPG.Core.Commands
{
	internal class MapCommand : Command
	{
		public MapCommand(IEngine engine) 
            : base(engine)
		{
		}

		public override void Execute(string[] commandArgs)
		{
			base.Engine.GameData.Draw(base.Engine.Writer);
		}
	}
}