using System;

namespace RPG.Interfaces
{
	public interface ICommandManager
	{
		IEngine Engine { get; set; }


		void ProcessCommand(string command);

		void SeedCommands();
	}
}