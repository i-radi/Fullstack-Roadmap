namespace SnakeAndLadder
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.nudPlayerCount = new System.Windows.Forms.NumericUpDown();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.pnlOverlay = new System.Windows.Forms.Panel();
            this.lblTurnIndicator = new System.Windows.Forms.Label();
            this.btnRollDice = new System.Windows.Forms.Button();
            this.tmrTurnCounter = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).BeginInit();
            this.pnlOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(143, 7);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(70, 20);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Start Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // nudPlayerCount
            // 
            this.nudPlayerCount.Location = new System.Drawing.Point(104, 7);
            this.nudPlayerCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPlayerCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPlayerCount.Name = "nudPlayerCount";
            this.nudPlayerCount.Size = new System.Drawing.Size(33, 20);
            this.nudPlayerCount.TabIndex = 1;
            this.nudPlayerCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(3, 9);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(95, 13);
            this.lblPlayerCount.TabIndex = 2;
            this.lblPlayerCount.Text = "Number of players:";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(222, 600);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(66, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit Game";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // pnlOverlay
            // 
            this.pnlOverlay.BackColor = System.Drawing.Color.Transparent;
            this.pnlOverlay.Controls.Add(this.lblTurnIndicator);
            this.pnlOverlay.Controls.Add(this.btnRollDice);
            this.pnlOverlay.Location = new System.Drawing.Point(294, 600);
            this.pnlOverlay.Name = "pnlOverlay";
            this.pnlOverlay.Size = new System.Drawing.Size(115, 73);
            this.pnlOverlay.TabIndex = 4;
            // 
            // lblTurnIndicator
            // 
            this.lblTurnIndicator.AutoSize = true;
            this.lblTurnIndicator.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTurnIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnIndicator.Location = new System.Drawing.Point(3, 5);
            this.lblTurnIndicator.Name = "lblTurnIndicator";
            this.lblTurnIndicator.Size = new System.Drawing.Size(109, 13);
            this.lblTurnIndicator.TabIndex = 1;
            this.lblTurnIndicator.Text = "It\'s Player 1\'s turn";
            // 
            // btnRollDice
            // 
            this.btnRollDice.Location = new System.Drawing.Point(19, 21);
            this.btnRollDice.Name = "btnRollDice";
            this.btnRollDice.Size = new System.Drawing.Size(65, 46);
            this.btnRollDice.TabIndex = 0;
            this.btnRollDice.Text = "Roll Dice\r\n0";
            this.btnRollDice.UseVisualStyleBackColor = true;
            this.btnRollDice.Click += new System.EventHandler(this.btnRollDice_Click);
            // 
            // tmrTurnCounter
            // 
            this.tmrTurnCounter.Interval = 500;
            this.tmrTurnCounter.Tick += new System.EventHandler(this.tmrTurnCounter_Tick);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 32);
            this.Controls.Add(this.pnlOverlay);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.nudPlayerCount);
            this.Controls.Add(this.btnPlay);
            this.Name = "MainScreen";
            this.Text = "Snake and Ladder";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainScreen_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).EndInit();
            this.pnlOverlay.ResumeLayout(false);
            this.pnlOverlay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.NumericUpDown nudPlayerCount;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel pnlOverlay;
        private System.Windows.Forms.Label lblTurnIndicator;
        private System.Windows.Forms.Button btnRollDice;
        private System.Windows.Forms.Timer tmrTurnCounter;
    }
}

