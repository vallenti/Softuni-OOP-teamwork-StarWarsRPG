using System;

namespace RPG.Interfaces
{
	public interface IOutputRenderer
	{
		void Clear();

		void Print(string message);
	}
}