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
            AddPlayingField();
        }

        private void AddPlayingField()
        {
            PlayingField = new PlayingField();
            PlayingField.Dock = DockStyle.Fill;
            FieldPanel.Controls.Add(PlayingField);
            PlayingField.GameController = new GameController(6, 5, 2);
        }
    }
}
