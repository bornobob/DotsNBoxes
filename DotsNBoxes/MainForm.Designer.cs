namespace DotsNBoxes
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FieldPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentPlayerColorPanel = new System.Windows.Forms.Panel();
            this.CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScoresGroupBox = new System.Windows.Forms.GroupBox();
            this.ScoresGrid = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.ScoresGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoresGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldPanel
            // 
            this.FieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FieldPanel.Location = new System.Drawing.Point(1, 2);
            this.FieldPanel.Name = "FieldPanel";
            this.FieldPanel.Size = new System.Drawing.Size(557, 447);
            this.FieldPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Player: ";
            // 
            // CurrentPlayerColorPanel
            // 
            this.CurrentPlayerColorPanel.Location = new System.Drawing.Point(91, 16);
            this.CurrentPlayerColorPanel.Name = "CurrentPlayerColorPanel";
            this.CurrentPlayerColorPanel.Size = new System.Drawing.Size(13, 13);
            this.CurrentPlayerColorPanel.TabIndex = 2;
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(110, 16);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(16, 13);
            this.CurrentPlayerLabel.TabIndex = 3;
            this.CurrentPlayerLabel.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CurrentPlayerLabel);
            this.groupBox1.Controls.Add(this.CurrentPlayerColorPanel);
            this.groupBox1.Location = new System.Drawing.Point(564, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 41);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // ScoresGroupBox
            // 
            this.ScoresGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoresGroupBox.Controls.Add(this.ScoresGrid);
            this.ScoresGroupBox.Location = new System.Drawing.Point(564, 59);
            this.ScoresGroupBox.Name = "ScoresGroupBox";
            this.ScoresGroupBox.Size = new System.Drawing.Size(224, 142);
            this.ScoresGroupBox.TabIndex = 5;
            this.ScoresGroupBox.TabStop = false;
            this.ScoresGroupBox.Text = "Scores";
            // 
            // ScoresGrid
            // 
            this.ScoresGrid.AllowUserToAddRows = false;
            this.ScoresGrid.AllowUserToDeleteRows = false;
            this.ScoresGrid.AllowUserToResizeColumns = false;
            this.ScoresGrid.AllowUserToResizeRows = false;
            this.ScoresGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoresGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ColorColumn,
            this.ScoreColumn});
            this.ScoresGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoresGrid.Location = new System.Drawing.Point(3, 16);
            this.ScoresGrid.Name = "ScoresGrid";
            this.ScoresGrid.ReadOnly = true;
            this.ScoresGrid.RowHeadersVisible = false;
            this.ScoresGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ScoresGrid.Size = new System.Drawing.Size(218, 123);
            this.ScoresGrid.TabIndex = 0;
            this.ScoresGrid.SelectionChanged += new System.EventHandler(this.ScoresGrid_SelectionChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NameColumn.Width = 135;
            // 
            // ColorColumn
            // 
            this.ColorColumn.HeaderText = "";
            this.ColorColumn.Name = "ColorColumn";
            this.ColorColumn.ReadOnly = true;
            this.ColorColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColorColumn.Width = 28;
            // 
            // ScoreColumn
            // 
            this.ScoreColumn.HeaderText = "Score";
            this.ScoreColumn.Name = "ScoreColumn";
            this.ScoreColumn.ReadOnly = true;
            this.ScoreColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScoreColumn.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScoresGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FieldPanel);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Dots \'n Boxes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ScoresGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScoresGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FieldPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel CurrentPlayerColorPanel;
        private System.Windows.Forms.Label CurrentPlayerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ScoresGroupBox;
        private System.Windows.Forms.DataGridView ScoresGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreColumn;
    }
}

