using RPG.Interfaces;
using RPG.Models;
using RPG.Models.EventHandlers;
using System;

namespace RPG.Core
{
	public class Engine : IEngine, IRunnable
	{
		public ICommandManager CommandManager { get; set; }
		public IGameData GameData{ get; set; }
        public bool IsRunning{ get; set; }
        public IInputHandler Reader{ get; set; }     
		public IOutputRenderer Writer{ get; set; }

        public Engine(
            IInputHandler reader,
            IOutputRenderer writer, 
            IGameData gameData, 
            ICommandManager commandManager)
		{
			this.Reader = reader;
			this.Writer = writer;
			this.GameData = gameData;
			this.CommandManager = commandManager;
		}

		private void PrintInfo(object sender, DamageEventArgs e)
		{
			this.Writer.Print(string.Format("Damage changed from {0} to {1}", e.OldDamage, e.NewDamage));
		}

		public void Run()
		{
			this.IsRunning = true;
			this.CommandManager.Engine = this;
			this.CommandManager.SeedCommands();
			this.GameData.Player.OnDamageChange += new ChangingDamageEventHandler(this.PrintInfo);
			do
			{
				string str = this.Reader.ReadLine();
				try
				{
					this.CommandManager.ProcessCommand(str);
				}
				catch (Exception exception)
				{
					this.Writer.Print(exception.Message);
				}
			}
			while (this.IsRunning);
		}
	}
}