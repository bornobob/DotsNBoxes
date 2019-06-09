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
        }

        private void InitializeGameController()
        {
            GameController = new GameController(8, 5, 2);
        }

        private void AddPlayingField()
        {
            PlayingField = new PlayingField();
            PlayingField.Dock = DockStyle.Fill;
            FieldPanel.Controls.Add(PlayingField);
            PlayingField.GameController = GameController;
        }
    }
}
