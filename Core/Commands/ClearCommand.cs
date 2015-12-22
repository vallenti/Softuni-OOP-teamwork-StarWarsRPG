using RPG.Interfaces;
using System;

namespace RPG.Core.Commands
{
	internal class ClearCommand : Command
	{
		public ClearCommand(IEngine engine)
            : base(engine)
		{
		}

		public override void Execute(string[] commandArgs)
		{
			base.Engine.Writer.Clear();
		}
	}
}