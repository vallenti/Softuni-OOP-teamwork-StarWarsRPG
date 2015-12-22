using RPG.Interfaces;
using System;

namespace RPG.Core.Commands
{
	public class HelpCommand : Command
	{
		public HelpCommand(IEngine engine) 
            : base(engine)
		{
		}

		public override void Execute(string[] commandArgs)
		{
            //TODO implement it
		}
	}
}