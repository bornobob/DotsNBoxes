using System;
using System.Drawing;

namespace DotsNBoxes
{
    class HumanStrategy : IPlayerStrategy
    {
        private readonly string Name;
        private readonly Color Color;
        private int Score;
        
        public HumanStrategy(string name, Color color)
        {
            Name = name;
            Color = color;
            Score = 0;
        }

        public void AddPoint()
        {
            Score += 1;
        }

        public Tuple<int, int> ChooseNextLocation()
        {
            throw new NotImplementedException("Human player does not automatically choose a location");
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
    }
}
