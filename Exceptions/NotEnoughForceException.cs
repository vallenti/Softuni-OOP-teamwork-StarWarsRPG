using System;

namespace RPG.Exceptions
{
	internal class NotEnoughForceException : Exception
	{
		public NotEnoughForceException(string message) 
            : base(message)
		{
		}
	}
}