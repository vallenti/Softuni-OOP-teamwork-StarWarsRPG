using System;

namespace RPG.Exceptions
{
	public class ObjectOutOfBoundsException : Exception
	{
		public ObjectOutOfBoundsException(string message) 
            : base(message)
		{
		}
	}
}