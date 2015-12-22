using RPG.Interfaces;

namespace RPG.Core.Commands
{
	internal class StatusCommand : Command
	{
		public StatusCommand(IEngine engine) 
            : base(engine)
		{
		}

		public override void Execute(string[] commandArgs)
		{
			base.Engine.Writer.Print(base.Engine.GameData.Player.ToString());
		}
	}
}