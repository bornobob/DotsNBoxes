using System;
using System.Collections.Generic;
using System.Drawing;

namespace DotsNBoxes
{
    class RandomStrategy : IPlayerStrategy
    {
        private int Score;
        private readonly string Name;
        private readonly Color Color;
        private readonly GameController Controller;
        private readonly Random Random;

        public RandomStrategy(string name, Color color, GameController controller)
        {
            Name = name;
            Color = color;
            Score = 0;
            Controller = controller;
            Random = new Random(GetHashCode());
        }

        public void AddPoint()
        {
            Score += 1;
        }

        public Tuple<int, int> ChooseNextLocation()
        {
            
            List<Tuple<int, int>> locations = GetPossibleLocations();
            if (locations.Count == 0) throw new InvalidOperationException("No possible choices, game should have ended");
            return locations[Random.Next(locations.Count)];
        }

        public Color GetPlayerColor()
        {
            return Color;
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public int GetScore()
        {
            return Score;
        }

        private List<Tuple<int, int>> GetPossibleLocations()
        {
            List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
            int[,] board = Controller.GetBoard();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == -1) locations.Add(new Tuple<int, int>(row, col));
                }
            }
            return locations;
        }

        public override bool Equals(object obj)
        {
            var strategy = obj as RandomStrategy;
            return strategy != null &&
                   Score == strategy.Score &&
                   Name == strategy.Name &&
                   EqualityComparer<Color>.Default.Equals(Color, strategy.Color);
        }

        public override int GetHashCode()
        {
            var hashCode = 182789875;
            hashCode = hashCode * -1521134295 + Score.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
            return hashCode;
        }
    }
}
