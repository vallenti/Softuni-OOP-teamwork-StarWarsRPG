using RPG.Core.Commands;
using RPG.Interfaces;
using System;
using System.Collections.Generic;

namespace RPG.Core
{
	public class CommandManager : ICommandManager
	{
		protected readonly Dictionary<string, Command> commandsByName;

		public IEngine Engine { get; set; }

		public CommandManager()
		{
			this.commandsByName = new Dictionary<string, Command>();
		}

		public void ProcessCommand(string commandString)
		{
			string[] strArrays = commandString.Split(new char[] { ' ' });
			string str = strArrays[0];
			if (!this.commandsByName.ContainsKey(str))
			{
				throw new NotSupportedException(string.Format("Command {0} does not exist.", str));
			}
			this.commandsByName[str].Execute(strArrays);
		}

		public virtual void SeedCommands()
		{
			this.commandsByName["help"] = new HelpCommand(this.Engine);
			this.commandsByName["map"] = new MapCommand(this.Engine);
			this.commandsByName["status"] = new StatusCommand(this.Engine);
			this.commandsByName["move"] = new MoveCommand(this.Engine);
			this.commandsByName["clear"] = new ClearCommand(this.Engine);
			this.commandsByName["exit"] = new ExitCommand(this.Engine);
		}
	}
}