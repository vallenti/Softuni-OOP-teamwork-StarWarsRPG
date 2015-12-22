using RPG.Interfaces;
using System;

namespace RPG.UI
{
	public class ConsoleOutputRenderer : IOutputRenderer
	{
		public void Clear()
		{
			Console.Clear();
		}

		public void Print(string message)
		{
			Console.WriteLine(message);
		}
	}
}