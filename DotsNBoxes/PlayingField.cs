using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotsNBoxes
{
    public partial class PlayingField : UserControl
    {
        private int ButtonWidth = 20;
        private Button[,] LineButtons;
        private Panel[,] BoxPanels;

        private GameController _GameController;
        public GameController GameController
        {
            private get => _GameController;
            set
            {
                this._GameController = value;
                _GameController.UpdateLineEvent += new Action<int, int>(UpdateBoard);
                _GameController.UpdateFieldEvent += new Action<int, int>(UpdateField);
                this.LineButtons = new Button[2 * _GameController.GetHeight() + 1, _GameController.GetWidth() + 1];
                this.BoxPanels = new Panel[_GameController.GetHeight(), _GameController.GetWidth()];
                DrawField();
            }
        }

        public PlayingField()
        {
            InitializeComponent();
        }

        private int CalculateButtonSize()
        {
            int gameHeight = _GameController.GetHeight();
            int gameWidth = _GameController.GetWidth();
            int maxForHeight = (this.Height - (gameHeight + 1) * ButtonWidth) / (gameHeight);
            int maxForWidth = (this.Width  - (gameWidth + 1) * ButtonWidth) / (gameWidth);
            return Math.Min(maxForHeight, maxForWidth);
        }

        private void DrawField()
        {
            this.SuspendLayout();
            this.Controls.Clear();
            int buttonSize = CalculateButtonSize();
            for (int row = 0; row < _GameController.GetHeight(); row++)
            {
                for (int col = 0; col < _GameController.GetWidth(); col++)
                {
                    if (row == 0) AddButton(new Tuple<int, int>(0, col), new Point(col * buttonSize + (col + 1) * ButtonWidth, 0), new Size(buttonSize, ButtonWidth));
                    if (col == 0) AddButton(new Tuple<int, int>(2 * row + 1, 0), new Point(0, row * buttonSize + (row + 1) * ButtonWidth), new Size(ButtonWidth, buttonSize));
                    AddButton(new Tuple<int, int>(2 * row + 1, col + 1), new Point((col + 1) * buttonSize + (col + 1) * ButtonWidth, row * buttonSize + (row + 1) * ButtonWidth), new Size(ButtonWidth, buttonSize));
                    AddButton(new Tuple<int, int>(2 * row + 2, col), new Point(col * buttonSize + (col + 1) * ButtonWidth, (row + 1) * buttonSize + (row + 1) * ButtonWidth), new Size(buttonSize, ButtonWidth));
                    AddPanel(new Tuple<int, int>(row, col), new Point(col * buttonSize + (col + 1) * ButtonWidth, row * buttonSize + (row + 1) * ButtonWidth), new Size(buttonSize, buttonSize));
                }
            }
            this.ResumeLayout();
        }

        private void ResizeLineButtons()
        {
            this.SuspendLayout();
            int buttonSize = CalculateButtonSize();
            for (int row = 0; row < LineButtons.GetLength(0); row++)
            {
                for (int col = 0; col < LineButtons.GetLength(1); col++)
                {
                    Button button = LineButtons[row, col];
                    if (button != null) ResizeButton(button, row, col, buttonSize);
                }
            }
            this.ResumeLayout();
        }

        private void ResizePanels()
        {
            this.SuspendLayout();
            int buttonSize = CalculateButtonSize();
            for (int row = 0; row < _GameController.GetHeight(); row++)
            {
                for (int col = 0; col < GameController.GetWidth(); col++)
                {
                    Panel panel = BoxPanels[row, col];
                    panel.Location = new Point(col * buttonSize + (col + 1) * ButtonWidth, row * buttonSize + (row + 1) * ButtonWidth);
                    panel.Size = new Size(buttonSize, buttonSize);
                }
            }
            this.ResumeLayout();
        }

        private void ResizeButton(Button button, int row, int col, int buttonSize)
        {
            if (row % 2 == 0)
            {
                button.Location = new Point((col + 1) * ButtonWidth + col * buttonSize, (row / 2) * buttonSize + (row / 2) * ButtonWidth);
                button.Size = new Size(buttonSize, ButtonWidth);
            }
            else
            {
                button.Location = new Point(col * ButtonWidth + col * buttonSize, (row / 2) * buttonSize + (row - row / 2) * ButtonWidth);
                button.Size = new Size(ButtonWidth, buttonSize);
            }
        }

        private void AddButton(Tuple<int, int> tag, Point location, Size size)
        {
            Button button = new Button();
            button.Tag = tag; 
            button.Location = location;
            button.Size = size;
            button.Click += new EventHandler(ButtonClick);
            LineButtons[tag.Item1, tag.Item2] = button;
            Controls.Add(button);
        }

        private void AddPanel(Tuple<int, int> tag, Point location, Size size)
        {
            Panel panel = new Panel();
            panel.Tag = tag;
            panel.Location = location;
            panel.Size = size;
            BoxPanels[tag.Item1, tag.Item2] = panel;
            Controls.Add(panel);
        }
        
        private void ButtonClick(object sender, EventArgs e)
        {
            if (_GameController.CurrentPlayer is HumanStrategy)
            {
                Button button = (Button)sender;
                Tuple<int, int> loc = (Tuple<int, int>)button.Tag;
                if (!_GameController.LineTaken(loc.Item1, loc.Item2))
                {
                    _GameController.HumanChoseLine(loc.Item1, loc.Item2);
                }
            }
        }


        private void PlayingField_SizeChanged(object sender, EventArgs e)
        {
            if (Controls.Count > 0)
            {
                ResizeLineButtons();
                ResizePanels();
            }
        }

        private void UpdateBoard(int row, int col)
        {
            Color color = _GameController.OwnerOfLine(row, col).GetPlayerColor();
            LineButtons[row, col].BackColor = color;
        }

        private void UpdateField(int row, int col)
        {
            Color color = _GameController.CurrentPlayer.GetPlayerColor();
            BoxPanels[row, col].BackColor = color;
        }
    }
}
