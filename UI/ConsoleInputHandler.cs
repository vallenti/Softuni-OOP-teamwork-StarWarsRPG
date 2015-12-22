using RPG.Interfaces;
using System;

namespace RPG.UI
{
	public class ConsoleInputHandler : IInputHandler
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}