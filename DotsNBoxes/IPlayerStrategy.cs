using System;
using System.Drawing;

namespace DotsNBoxes
{
    public interface IPlayerStrategy
    {
        string GetPlayerName();

        Color GetPlayerColor();

        Tuple<int, int> ChooseNextLocation();
    }
}
