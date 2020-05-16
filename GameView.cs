using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SlamMatch
{
    public partial class GameView : Form
    {
        private Player player;
        private Game game;

        private const int PictureBoxWidth = 100;
        private const int PictureBoxHeight = 150;
        private PictureBox[] pics;
        private PictureBox firstPicClicked;

        public GameView() {
            InitializeComponent();
        }

        private void GameView_Load(object sender, EventArgs e) {
            pnlWelcome.BringToFront();   
        }

        private void BtnGameRules_Click(object sender, EventArgs e){
            lblGameRules.Visible = !(lblGameRules.Visible);
        }

        private void BtnPlay_Click(object sender, EventArgs e) {
                this.player = new Player();
                this.game = new Game();
                RefreshGameBoard();
                pnlGameBoard.BringToFront();
        }

        private void UpdateStats() {
            lblNumLives.Text = "Nombre de vies: " + this.player.GetNumLives();
            lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.game.GetCurrentLevel().GetNumPointsRequiredToPass();
            lblLevel.Text = "Niveau: " + (this.game.GetCurrentLevelNum() + 1) + " / " + this.game.GetMaximumLevel();
        }

        private void RefreshGameBoard() {
            firstPicClicked = null;
            if(this.pics != null) {
                for(int i = 0; i < pics.Length; i++) {
                    pnlGameBoard.Controls.Remove(pics[i]); 
                }
            }
            LoadPictureBoxes(this.game.GetCurrentLevel().GetCurrentRound().GetCards());
            ArrangePictureBoxes();
            StartRoundTimer();
            UpdateStats();
        }

        private void LoadPictureBoxes(List<Card> cards) {
            this.pics = new PictureBox[cards.Count];
            for (int i = 0; i < cards.Count; i++) {
                pics[i] = LoadCard(cards[i]);
            }
        }
        
        private PictureBox LoadCard(Card card) {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(PictureBoxWidth, PictureBoxHeight);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Parent = pnlGameBoard;
            pic.MouseClick += Card_MouseClick;

            pic.Tag = card;
            pic.Padding = new Padding(7);
            pic.BackColor = Color.FromName(card.GetColor().ToString());
            pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(card.GetSymbol().ToString());

            return pic;
        }

        private void ArrangePictureBoxes() {
            int numPics = this.pics.Length;
            int numCardsPerLine = 4;
            int margin = 10;
            int y = (int)(pics[0].Parent.Height - PictureBoxHeight * (Math.Ceiling(numPics / (double)numCardsPerLine))) / 2;
            int x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
            for (int i = 0; i < numPics; i++) {
                pics[i].Location = new Point(x, y);
                x += pics[0].Width + margin;

                if ((i + 1) % numCardsPerLine == 0) {
                    x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
                    y += pics[0].Height + margin;
                }
            }
        }

        private void ValidatePictureBox(PictureBox pic) {
            pic.BorderStyle = BorderStyle.None;
            pic.BackColor = Color.FromName("White");
            pic.Image = Properties.Resources.Validated;
            ((Card)pic.Tag).SetState(Card.CardState.Validated);
        }

        private void AnimatePictureBox(PictureBox pic) {
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
            for (int i = 0; i < 10; i++) { pic.Location = new Point(pic.Location.X - 2, pic.Location.Y - 2); Thread.Sleep(10); }
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
        }

        private void Card_MouseClick(object sender, EventArgs e) {
            PictureBox picClicked = sender as PictureBox;
            Card cardSelected = picClicked.Tag as Card;
            
            if (cardSelected.GetState() == Card.CardState.Selectable) {
                if (this.firstPicClicked == null){
                    picClicked.BorderStyle = BorderStyle.Fixed3D;
                    this.firstPicClicked = picClicked;
                    ((Card)this.firstPicClicked.Tag).SetState(Card.CardState.Selected);
                }
                else if (picClicked != firstPicClicked && !((Card)picClicked.Tag).Equals((Card)firstPicClicked.Tag)) {
                    AnimatePictureBox(firstPicClicked);
                    ((Card)firstPicClicked.Tag).SetState(Card.CardState.Selectable);
                    this.firstPicClicked.BorderStyle = BorderStyle.None;
                    this.firstPicClicked = null;
                }
                else if(picClicked != firstPicClicked && ((Card)picClicked.Tag).Equals((Card)firstPicClicked.Tag)) {
                    ValidatePictureBox(firstPicClicked);
                    ValidatePictureBox(picClicked);
                    this.game.GetCurrentLevel().GetCurrentRound().PairOfCardsValidated();
                    this.player.IncrementNumPoints(this.game.GetNumPointsPerValidation());
                    this.firstPicClicked = null;

                    if(this.game.GetCurrentLevel().GetCurrentRound().RoundFinished()) {
                        tmrRound.Stop();
                        if (this.player.GetNumPoints() < this.game.GetCurrentLevel().GetNumPointsRequiredToPass()) {
                            this.game.GetCurrentLevel().NewRound();
                            RefreshGameBoard();
                        }
                        else {
                            if (this.game.NextLevel()) RefreshGameBoard();
                            else pnlWinGame.BringToFront();        
                        }
                    }
                    UpdateStats();
                }
            }
            else if (cardSelected.GetState() == Card.CardState.Selected && cardSelected == (Card)firstPicClicked.Tag) {
                ((Card)firstPicClicked.Tag).SetState(Card.CardState.Selectable);
                firstPicClicked.BorderStyle = BorderStyle.None;
                firstPicClicked = null;
            }
        }

        private void StartRoundTimer() {
            lblTimerRound.Text = "00: " + this.game.GetCurrentLevel().GetCurrentRound().GetDuration();
            tmrRound.Start();
        }

        private void RoundTimerTick(object sender, EventArgs e) {
            this.game.GetCurrentLevel().GetCurrentRound().DecrementDuration();
            lblTimerRound.Text = "00: " + this.game.GetCurrentLevel().GetCurrentRound().GetDuration().ToString("D2");
            if (this.game.GetCurrentLevel().GetCurrentRound().GetDuration() == 0) {
                tmrRound.Stop();
                if (!this.player.DecrementNumLives()) pnlLoseGame.BringToFront();
                else {
                    this.game.GetCurrentLevel().NewRound();
                    RefreshGameBoard();
                }
            }
        }
    }
}
