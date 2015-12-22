using RPG.Core;
using RPG.Interfaces;
using RPG.UI;

namespace RPG
{
	internal class Program
	{
		public Program()
		{
		}

		private static void Main(string[] args)
		{
			IInputHandler consoleInputHandler = new ConsoleInputHandler();
			IOutputRenderer consoleOutputRenderer = new ConsoleOutputRenderer();
            IGameData data = new GameData();
            ICommandManager cm = new CommandManager();
            IEngine engine = new Engine(
                consoleInputHandler,
                consoleOutputRenderer,
                data,
                cm);

            engine.Run();
		}
	}
}