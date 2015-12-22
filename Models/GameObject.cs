using RPG.Core;
using RPG.Exceptions;


namespace RPG.Models
{
	public class GameObject
	{
		private Position position;

        public GameObject(Position position, char symbol)
        {
            this.Position = position;
            this.Symbol = symbol;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if ((value.X < 0 
                    || value.Y < 0 
                    || value.X >= GameData.MapWidth 
                    || value.Y >= GameData.MapHeight))
                {
                    throw new ObjectOutOfBoundsException("Specified coordinates are outside map.");
                }
                this.position = value;
            }
        }

		public char Symbol { get; set; }

	}
}