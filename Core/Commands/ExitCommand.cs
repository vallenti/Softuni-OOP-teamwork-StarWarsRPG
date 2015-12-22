using RPG.Interfaces;
using System;

namespace RPG.Core.Commands
{
	internal class ExitCommand : Command
	{
		public ExitCommand(IEngine engine) 
            : base(engine)
		{
		}

		public override void Execute(string[] commandArgs)
		{
			base.Engine.IsRunning = false;
			base.Engine.Writer.Print("May the force be with you!");
		}
	}
}