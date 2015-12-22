using RPG.Core.Factories;
using RPG.Interfaces;
using RPG.Models;
using RPG.Models.Characters;
using RPG.Models.Items;
using RPG.Models.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    public class GameData : IGameData
    {
        public static int MapHeight = 10;

        public static int MapWidth = 10;

        private Random rGen = new Random();

        private IStormtrooperFactory sFactory;                                   
        private IForceBallFactory fFactory;                   
        private IWeaponFactory wFactory;
        public IList<Stormtrooper> Enemies { get; set; }
        public IList<Item> Objects { get; set; }
        public char[,] GameBoard { get; set; }
        public Jedi Player{ get; set; }

        
		public GameData()
		{
			this.GameBoard = new char[GameData.MapHeight, GameData.MapWidth];
			this.Player = new Jedi();
			this.Enemies = new List<Stormtrooper>();
			this.Objects = new List<Item>();
            sFactory = new StormtrooperFactory();
            fFactory = new ForceBallFactory();
            wFactory = new WeaponFactory();
			this.GenerateEnemies();
			this.GenerateObjects();
		}

        public void Draw(IOutputRenderer renderer)
        {
            for (int row = 0; row < this.GameBoard.GetLength(0); row++)
            {
                StringBuilder line = new StringBuilder();
                for (int col = 0; col < this.GameBoard.GetLength(1); col++)
                {
                    this.GameBoard[row, col] = '.';
                    if(row == Player.Position.X && col == Player.Position.Y)
                    {
                        this.GameBoard[row, col] = Player.Symbol;
                    }

                    var enemies = this.Enemies.Where(e => e.IsAlive);
                    foreach (var enemy in enemies)
                    {
                        if (row == enemy.Position.X && col == enemy.Position.Y)
                        {
                            this.GameBoard[row, col] = enemy.Symbol;
                        }
                    }

                    var fbs = this.Objects.Where(o => o.State == ItemState.Available);
                    foreach (var fb in fbs)
                    {
                        if (row == fb.Position.X && col == fb.Position.Y)
                        {
                            this.GameBoard[row, col] = fb.Symbol;
                        }
                    }

                    line.Append(GameBoard[row, col]);
                }
                renderer.Print(line.ToString());
            }
        }

		protected void GenerateEnemies()
		{
			for (int i = 0; i < 10; i++)
			{
				Position pos = this.GetRandomPosition();
                if(pos.X == this.Player.Position.X && pos.Y == this.Player.Position.Y)
                {
                    i--;
                    continue;
                }

                var character = this.sFactory.CreateStormtrooper(pos);
                this.Enemies.Add(character as Stormtrooper);
			}
		}

		protected void GenerateObjects()
		{
			for (int i = 0; i < 5; i++)
			{
				Position pos = this.GetRandomPosition();
                if (pos.X == this.Player.Position.X && pos.Y == this.Player.Position.Y)
                {
                    i--;
                    continue;
                }
                var forceBall = this.fFactory.CreateForceBall(pos, ForceBallPower.Medium);
                this.Objects.Add(forceBall);
            }
			Position position = this.GetRandomPosition();
			Weapon weapon = this.wFactory.CreateWeapon(position);
			this.Objects.Add(weapon);
		}

		private Position GetRandomPosition()
		{
			int x = this.rGen.Next(0, GameData.MapHeight);
			int y = this.rGen.Next(0, GameData.MapWidth);
			return new Position(x, y);
		}
	}
}