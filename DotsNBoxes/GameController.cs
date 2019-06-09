using System;
using System.Collections.Generic;

namespace DotsNBoxes
{
    public class GameController
    {
        public event Action<int, int> UpdateLineEvent;
        public event Action NextPlayerEvent;
        public event Action<int, int> UpdateFieldEvent;

        private int[,] Board;
        private List<IPlayerStrategy> Players;
        private int _CurrentPlayer;
        private int[] Scores;

        public IPlayerStrategy CurrentPlayer
        {
            get => Players[_CurrentPlayer];
        }

        public GameController(int width, int height, List<IPlayerStrategy> players, int firstPlayer)
        {
            InitializeBoard(width, height);
            Players = players;
            _CurrentPlayer = firstPlayer;
            InitializeScores();
        }

        private void InitializeScores()
        {
            Scores = new int[Players.Count];
            for (int i = 0; i < Scores.Length; i++)
            {
                Scores[i] = 0;
            }
        }

        private void InitializeBoard(int width, int height)
        {
            Board = new int[2 * height + 1, width + 1];
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    Board[row, col] = -1;
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

        private void ProcessPlayerTurn()
        {
            IPlayerStrategy currentPlayer = Players[_CurrentPlayer];
            if (!(currentPlayer is HumanStrategy))
            {
                Tuple<int, int> chosenCoords = currentPlayer.ChooseNextLocation();
                Board[chosenCoords.Item1, chosenCoords.Item2] = _CurrentPlayer;
                UpdateLineEvent(chosenCoords.Item1, chosenCoords.Item2);
                if (!CalculateScoresAfterLine(chosenCoords.Item1, chosenCoords.Item2))
                {
                    NextPlayer();
                }
            }
        }

        private void NextPlayer()
        {
            _CurrentPlayer = (_CurrentPlayer + 1) % Players.Count;
            NextPlayerEvent();
            ProcessPlayerTurn();
        }

        public void StartGame()
        {
            NextPlayerEvent();
            ProcessPlayerTurn();
        }

        public bool LineTaken(int row, int col)
        {
            return Board[row, col] != -1;
        }

        public void HumanChoseLine(int row, int col)
        {
            Board[row, col] = _CurrentPlayer;
            UpdateLineEvent(row, col);
            if (!CalculateScoresAfterLine(row, col))
            {
                NextPlayer();
            }
        }
        
        public IPlayerStrategy OwnerOfLine(int row, int col)
        {
            if (LineTaken(row, col))
            {
                return Players[Board[row, col]];
            } else
            {
                return null;
            }
        }

        private bool CalculateScoresAfterLine(int row, int col)
        {
            bool gotPoints = false;
            foreach (Tuple<int, int> field in GetFieldsBesidesLine(row, col))
            {
                bool fullField = true;
                List<Tuple<int, int>> lines = GetLinesBesidesField(field.Item1, field.Item2);
                foreach (Tuple<int, int> line in lines)
                {
                    if (!LineTaken(line.Item1, line.Item2) || !lines.Contains(new Tuple<int, int>(row, col)))
                    {
                        fullField = false;
                        break;
                    }
                }
                if (fullField)
                {
                    Scores[_CurrentPlayer] += 1;
                    UpdateFieldEvent(field.Item1, field.Item2);
                    gotPoints = true;
                }
            }
            return gotPoints;
        }

        private List<Tuple<int, int>> GetLinesBesidesField(int row, int col)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

            coords.Add(new Tuple<int, int>(2 * row, col)); // North
            coords.Add(new Tuple<int, int>(2 * row + 1, col + 1)); // East
            coords.Add(new Tuple<int, int>(2 * row + 2, col)); // South
            coords.Add(new Tuple<int, int>(2 * row + 1, col)); // West

            return coords;
        }

        private List<Tuple<int, int>> GetFieldsBesidesLine(int row, int col)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            if (row % 2 == 0)
            {
                if (row > 0) coords.Add(new Tuple<int, int>((row - 2) / 2, col));
                if (row < Board.GetLength(0) - 1) coords.Add(new Tuple<int, int>((row - 2) / 2 + 1, col));
            } else
            {
                if (col > 0) coords.Add(new Tuple<int, int>((row - 1) / 2, col - 1));
                if (col < Board.GetLength(1) - 1) coords.Add(new Tuple<int, int>((row - 1) / 2, col));
            }
            return coords;
        }
    }
}
