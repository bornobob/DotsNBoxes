using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotsNBoxes
{
    public partial class MainForm : Form
    {
        private PlayingField PlayingField;
        private GameController GameController;

        public MainForm()
        {
            InitializeComponent();
            InitializeGameController();
            InitializeScores();
            AddPlayingField();
            GameController.StartGame();
        }

        private void InitializeGameController()
        {
            GameController = new GameController(8, 5, 0);
            GameController.NextPlayerEvent += new Action(SetNextPlayerInfo);
            GameController.ScoresChanged += new Action<int>(UpdateScores);
            GameController.GameFinishedEvent += new Action(GameFinished);
            GameController.AddPlayer(new HumanStrategy("Bob", Color.Red));
            GameController.AddPlayer(new HumanStrategy("Alice", Color.Blue));
            GameController.AddPlayer(new RandomStrategy("Eve", Color.Green, GameController));
        }

        private void InitializeScores()
        {
            foreach (IPlayerStrategy player in GameController.GetPlayers())
            {
                int idx = ScoresGrid.Rows.Add(new object[] { player.GetPlayerName(), "", player.GetScore() });
                ScoresGrid.Rows[idx].Cells["ColorColumn"].Style.BackColor = player.GetPlayerColor();
            }
        }

        private void UpdateScores(int id)
        {
            IPlayerStrategy player = GameController.GetPlayerById(id);
            ScoresGrid.Rows[id].Cells["ScoreColumn"].Value = player.GetScore();
        }

        private void AddPlayingField()
        {
            PlayingField = new PlayingField();
            PlayingField.Dock = DockStyle.Fill;
            FieldPanel.Controls.Add(PlayingField);
            PlayingField.GameController = GameController;
        }

        private void SetNextPlayerInfo()
        {
            CurrentPlayerLabel.Text = GameController.CurrentPlayer.GetPlayerName();
            CurrentPlayerColorPanel.BackColor = GameController.CurrentPlayer.GetPlayerColor();
        }

        private void ScoresGrid_SelectionChanged(object sender, EventArgs e)
        {
            ScoresGrid.ClearSelection();
        }

        private void GameFinished()
        {
            MessageBox.Show("Game finished!");
        }
    }
}
