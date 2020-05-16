namespace SlamMatch
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.lblTimerRound = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblNumLives = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pnlWinGame = new System.Windows.Forms.Panel();
            this.lblReplayWinGame = new System.Windows.Forms.Label();
            this.pbThumpsUp = new System.Windows.Forms.PictureBox();
            this.lblWinGame = new System.Windows.Forms.Label();
            this.pnlLoseGame = new System.Windows.Forms.Panel();
            this.lblReplayLoseGame = new System.Windows.Forms.Label();
            this.pbThumbsDown = new System.Windows.Forms.PictureBox();
            this.lblLoseGame = new System.Windows.Forms.Label();
            this.tmrRound = new System.Windows.Forms.Timer(this.components);
            this.pnlWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlGameBoard.SuspendLayout();
            this.pnlWinGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumpsUp)).BeginInit();
            this.pnlLoseGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbsDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWelcome.Controls.Add(this.btnPlay);
            this.pnlWelcome.Controls.Add(this.pbLogo);
            this.pnlWelcome.Controls.Add(this.lblWelcome);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(984, 761);
            this.pnlWelcome.TabIndex = 1;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(358, 567);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(269, 51);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Jouer";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(95, 87);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(795, 366);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(404, 486);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(174, 37);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Bienvenue";
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.AutoScroll = true;
            this.pnlGameBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameBoard.Controls.Add(this.lblTimerRound);
            this.pnlGameBoard.Controls.Add(this.lblLevel);
            this.pnlGameBoard.Controls.Add(this.lblNumLives);
            this.pnlGameBoard.Controls.Add(this.lblPoints);
            this.pnlGameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameBoard.Location = new System.Drawing.Point(0, 0);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(984, 761);
            this.pnlGameBoard.TabIndex = 2;
            // 
            // lblTimerRound
            // 
            this.lblTimerRound.AutoSize = true;
            this.lblTimerRound.BackColor = System.Drawing.Color.Transparent;
            this.lblTimerRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerRound.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimerRound.Location = new System.Drawing.Point(449, 31);
            this.lblTimerRound.Name = "lblTimerRound";
            this.lblTimerRound.Size = new System.Drawing.Size(87, 31);
            this.lblTimerRound.TabIndex = 3;
            this.lblTimerRound.Text = "00:00";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(12, 56);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(55, 15);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "Niveau:";
            // 
            // lblNumLives
            // 
            this.lblNumLives.AutoSize = true;
            this.lblNumLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLives.Location = new System.Drawing.Point(12, 9);
            this.lblNumLives.Name = "lblNumLives";
            this.lblNumLives.Size = new System.Drawing.Size(122, 16);
            this.lblNumLives.TabIndex = 1;
            this.lblNumLives.Text = "Nombre de vies:";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(12, 33);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(51, 15);
            this.lblPoints.TabIndex = 0;
            this.lblPoints.Text = "Points:";
            // 
            // pnlWinGame
            // 
            this.pnlWinGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinGame.Controls.Add(this.lblReplayWinGame);
            this.pnlWinGame.Controls.Add(this.pbThumpsUp);
            this.pnlWinGame.Controls.Add(this.lblWinGame);
            this.pnlWinGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWinGame.Location = new System.Drawing.Point(0, 0);
            this.pnlWinGame.Name = "pnlWinGame";
            this.pnlWinGame.Size = new System.Drawing.Size(984, 761);
            this.pnlWinGame.TabIndex = 3;
            // 
            // lblReplayWinGame
            // 
            this.lblReplayWinGame.AutoSize = true;
            this.lblReplayWinGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplayWinGame.Location = new System.Drawing.Point(371, 437);
            this.lblReplayWinGame.Name = "lblReplayWinGame";
            this.lblReplayWinGame.Size = new System.Drawing.Size(242, 20);
            this.lblReplayWinGame.TabIndex = 3;
            this.lblReplayWinGame.Text = "Appuyez sur espace pour rejouer";
            // 
            // pbThumpsUp
            // 
            this.pbThumpsUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbThumpsUp.Image = global::SlamMatch.Properties.Resources.thumbsup;
            this.pbThumpsUp.Location = new System.Drawing.Point(365, 87);
            this.pbThumpsUp.Name = "pbThumpsUp";
            this.pbThumpsUp.Size = new System.Drawing.Size(213, 210);
            this.pbThumpsUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumpsUp.TabIndex = 2;
            this.pbThumpsUp.TabStop = false;
            // 
            // lblWinGame
            // 
            this.lblWinGame.AutoSize = true;
            this.lblWinGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinGame.Location = new System.Drawing.Point(228, 344);
            this.lblWinGame.Name = "lblWinGame";
            this.lblWinGame.Size = new System.Drawing.Size(529, 73);
            this.lblWinGame.TabIndex = 1;
            this.lblWinGame.Text = "Vous avez gagné";
            // 
            // pnlLoseGame
            // 
            this.pnlLoseGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoseGame.Controls.Add(this.lblReplayLoseGame);
            this.pnlLoseGame.Controls.Add(this.pbThumbsDown);
            this.pnlLoseGame.Controls.Add(this.lblLoseGame);
            this.pnlLoseGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoseGame.Location = new System.Drawing.Point(0, 0);
            this.pnlLoseGame.Name = "pnlLoseGame";
            this.pnlLoseGame.Size = new System.Drawing.Size(984, 761);
            this.pnlLoseGame.TabIndex = 4;
            // 
            // lblReplayLoseGame
            // 
            this.lblReplayLoseGame.AutoSize = true;
            this.lblReplayLoseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplayLoseGame.Location = new System.Drawing.Point(346, 429);
            this.lblReplayLoseGame.Name = "lblReplayLoseGame";
            this.lblReplayLoseGame.Size = new System.Drawing.Size(292, 24);
            this.lblReplayLoseGame.TabIndex = 2;
            this.lblReplayLoseGame.Text = "Appuyez sur espace pour rejouer";
            // 
            // pbThumbsDown
            // 
            this.pbThumbsDown.Image = global::SlamMatch.Properties.Resources.thumbsdown;
            this.pbThumbsDown.Location = new System.Drawing.Point(365, 87);
            this.pbThumbsDown.Name = "pbThumbsDown";
            this.pbThumbsDown.Size = new System.Drawing.Size(213, 210);
            this.pbThumbsDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbsDown.TabIndex = 1;
            this.pbThumbsDown.TabStop = false;
            // 
            // lblLoseGame
            // 
            this.lblLoseGame.AutoSize = true;
            this.lblLoseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoseGame.Location = new System.Drawing.Point(235, 344);
            this.lblLoseGame.Name = "lblLoseGame";
            this.lblLoseGame.Size = new System.Drawing.Size(514, 73);
            this.lblLoseGame.TabIndex = 0;
            this.lblLoseGame.Text = "Vous avez perdu";
            // 
            // tmrRound
            // 
            this.tmrRound.Interval = 1000;
            this.tmrRound.Tick += new System.EventHandler(this.RoundTimerTick);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.pnlLoseGame);
            this.Controls.Add(this.pnlWinGame);
            this.Controls.Add(this.pnlGameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SlamMatch";
            this.Load += new System.EventHandler(this.GameView_Load);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlGameBoard.ResumeLayout(false);
            this.pnlGameBoard.PerformLayout();
            this.pnlWinGame.ResumeLayout(false);
            this.pnlWinGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumpsUp)).EndInit();
            this.pnlLoseGame.ResumeLayout(false);
            this.pnlLoseGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbsDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Panel pnlWinGame;
        private System.Windows.Forms.Panel pnlLoseGame;
        private System.Windows.Forms.Label lblLoseGame;
        private System.Windows.Forms.Label lblWinGame;
        private System.Windows.Forms.Label lblNumLives;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Timer tmrRound;
        private System.Windows.Forms.Label lblTimerRound;
        private System.Windows.Forms.PictureBox pbThumpsUp;
        private System.Windows.Forms.Label lblReplayWinGame;
        private System.Windows.Forms.Label lblReplayLoseGame;
        private System.Windows.Forms.PictureBox pbThumbsDown;
    }
}

