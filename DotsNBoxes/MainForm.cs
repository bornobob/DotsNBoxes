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
            AddPlayingField();
            GameController.StartGame();
        }

        private void InitializeGameController()
        {
            List<IPlayerStrategy> players = new List<IPlayerStrategy>();
            players.Add(new HumanStrategy("Bob", Color.Red));
            players.Add(new HumanStrategy("Alice", Color.Blue));
            GameController = new GameController(8, 5, players, 0);
            GameController.NextPlayerEvent += new Action(SetNextPlayerInfo);
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
    }
}
