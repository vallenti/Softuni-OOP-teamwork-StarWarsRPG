using System;

namespace RPG.Interfaces
{
	public interface IEngine : IRunnable
	{
		ICommandManager CommandManager
		{
			get;
			set;
		}

		IGameData GameData
		{
			get;
			set;
		}

		bool IsRunning
		{
			get;
			set;
		}

		IInputHandler Reader
		{
			get;
		}

		IOutputRenderer Writer
		{
			get;
		}
	}
}