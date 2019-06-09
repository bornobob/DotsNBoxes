using System;

namespace DotsNBoxes
{
    public class GameController
    {
        public event Action<int, int> UpdateBoardEvent;
        private int[,] Board;
        private int Players;

        public GameController(int width, int height, int nrPlayers)
        {
            InitializeBoard(width, height);
            Players = nrPlayers;
        }

        private void InitializeBoard(int width, int height)
        {
            Board = new int[2 * height + 1, width + 1];
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    Board[row, col] = 0;
                }
            }
        }

        public int GetHeight()
        {
            return (Board.GetLength(0) - 1) / 2;
        }

        public int GetWidth()
        {
            return Board.GetLength(1) - 1;
        }
    }
}
