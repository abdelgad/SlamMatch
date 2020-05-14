namespace SlamMatch
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblNickname = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblNumLives = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pnlWinGame = new System.Windows.Forms.Panel();
            this.lblWinGame = new System.Windows.Forms.Label();
            this.pnlLoseGame = new System.Windows.Forms.Panel();
            this.lblLoseGame = new System.Windows.Forms.Label();
            this.pnlWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlGameBoard.SuspendLayout();
            this.pnlWinGame.SuspendLayout();
            this.pnlLoseGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWelcome.Controls.Add(this.lblNickname);
            this.pnlWelcome.Controls.Add(this.txtNickname);
            this.pnlWelcome.Controls.Add(this.pbLogo);
            this.pnlWelcome.Controls.Add(this.lblWelcome);
            this.pnlWelcome.Controls.Add(this.btnPlay);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(800, 450);
            this.pnlWelcome.TabIndex = 1;
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(253, 333);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(74, 13);
            this.lblNickname.TabIndex = 4;
            this.lblNickname.Text = "Votre Pseudo:";
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(333, 330);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(135, 20);
            this.txtNickname.TabIndex = 3;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(170, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(465, 217);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(315, 253);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(174, 37);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Bienvenue";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(285, 372);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(230, 48);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Jouer";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.AutoScroll = true;
            this.pnlGameBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameBoard.Controls.Add(this.lblLevel);
            this.pnlGameBoard.Controls.Add(this.lblNumLives);
            this.pnlGameBoard.Controls.Add(this.lblPoints);
            this.pnlGameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameBoard.Location = new System.Drawing.Point(0, 0);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(800, 450);
            this.pnlGameBoard.TabIndex = 2;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(21, 426);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(55, 15);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "Niveau:";
            // 
            // lblNumLives
            // 
            this.lblNumLives.AutoSize = true;
            this.lblNumLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLives.Location = new System.Drawing.Point(21, 386);
            this.lblNumLives.Name = "lblNumLives";
            this.lblNumLives.Size = new System.Drawing.Size(111, 15);
            this.lblNumLives.TabIndex = 1;
            this.lblNumLives.Text = "Nombre de vies:";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(21, 405);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(51, 15);
            this.lblPoints.TabIndex = 0;
            this.lblPoints.Text = "Points:";
            // 
            // pnlWinGame
            // 
            this.pnlWinGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinGame.Controls.Add(this.lblWinGame);
            this.pnlWinGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWinGame.Location = new System.Drawing.Point(0, 0);
            this.pnlWinGame.Name = "pnlWinGame";
            this.pnlWinGame.Size = new System.Drawing.Size(800, 450);
            this.pnlWinGame.TabIndex = 3;
            // 
            // lblWinGame
            // 
            this.lblWinGame.AutoSize = true;
            this.lblWinGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinGame.Location = new System.Drawing.Point(129, 189);
            this.lblWinGame.Name = "lblWinGame";
            this.lblWinGame.Size = new System.Drawing.Size(543, 73);
            this.lblWinGame.TabIndex = 1;
            this.lblWinGame.Text = "Vous avez Gagne";
            // 
            // pnlLoseGame
            // 
            this.pnlLoseGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoseGame.Controls.Add(this.lblLoseGame);
            this.pnlLoseGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoseGame.Location = new System.Drawing.Point(0, 0);
            this.pnlLoseGame.Name = "pnlLoseGame";
            this.pnlLoseGame.Size = new System.Drawing.Size(800, 450);
            this.pnlLoseGame.TabIndex = 4;
            // 
            // lblLoseGame
            // 
            this.lblLoseGame.AutoSize = true;
            this.lblLoseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoseGame.Location = new System.Drawing.Point(80, 189);
            this.lblLoseGame.Name = "lblLoseGame";
            this.lblLoseGame.Size = new System.Drawing.Size(640, 73);
            this.lblLoseGame.TabIndex = 0;
            this.lblLoseGame.Text = "VOUS AVEZ PERDU";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlGameBoard);
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.pnlWinGame);
            this.Controls.Add(this.pnlLoseGame);
            this.Name = "Game";
            this.Text = "SlamMatch";
            this.Load += new System.EventHandler(this.Game_Load);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlGameBoard.ResumeLayout(false);
            this.pnlGameBoard.PerformLayout();
            this.pnlWinGame.ResumeLayout(false);
            this.pnlWinGame.PerformLayout();
            this.pnlLoseGame.ResumeLayout(false);
            this.pnlLoseGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Panel pnlWinGame;
        private System.Windows.Forms.Panel pnlLoseGame;
        private System.Windows.Forms.Label lblLoseGame;
        private System.Windows.Forms.Label lblWinGame;
        private System.Windows.Forms.Label lblNumLives;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblLevel;
    }
}

