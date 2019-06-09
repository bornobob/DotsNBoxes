using System;
using System.Drawing;

namespace DotsNBoxes
{
    class HumanStrategy : IPlayerStrategy
    {
        private string Name;
        private Color Color;
        
        public HumanStrategy(string name, Color color)
        {
            Name = name;
            Color = color;
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
    }
}
