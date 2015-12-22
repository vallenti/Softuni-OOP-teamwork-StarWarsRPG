using RPG.Interfaces;
using System;

namespace RPG.Core.Commands
{
	public abstract class Command
	{
		public IEngine Engine { get; set; }

		protected Command(IEngine engine)
		{
			this.Engine = engine;
		}

		public abstract void Execute(string[] commandArgs);
	}
}