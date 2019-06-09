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

        public RandomStrategy(string name, Color color, GameController controller)
        {
            Name = name;
            Color = color;
            Score = 0;
            Controller = controller;
        }

        public void AddPoint()
        {
            Score += 1;
        }

        public Tuple<int, int> ChooseNextLocation()
        {
            Random random = new Random();
            List<Tuple<int, int>> locations = GetPossibleLocations();
            if (locations.Count == 0) throw new InvalidOperationException("No possible choices, game should have ended");
            return locations[random.Next(locations.Count)];
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
    }
}
