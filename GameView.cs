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
        private PictureBox firstSelect;

        public GameView(){
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e){
            pnlWelcome.BringToFront();
        }

        private void btnPlay_Click(object sender, EventArgs e){
            if(string.IsNullOrEmpty(txtNickname.Text)){
                MessageBox.Show("Entrez un pseudo avant de jouer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else{
                this.player = new Player(txtNickname.Text);
                this.game = new Game();
                UpdateStats();
                RefreshGameBoard();
                pnlGameBoard.BringToFront();
            }
        }

        private void UpdateStats()
        {
            lblNumLives.Text = "Nombre de vies: " + this.player.GetNumLives();
            lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.game.GetCurrentLevel().GetNumPointsRequiredToPass();
            lblLevel.Text = "Niveau: " + (this.game.GetCurrentLevelNum() + 1) + " / " + this.game.GetMaximumLevel();
        }

        private void RefreshGameBoard(){
            if(this.pics != null){
                for(int i = 0; i < pics.Length; i++){
                    pnlGameBoard.Controls.Remove(pics[i]); 
                }
            }
            LoadPictureBoxes(this.game.GetCurrentLevel().GetCurrentRound().GetCards());
            ArrangePictureBoxes();
        }

        private void LoadPictureBoxes(List<Card> cards){
            this.pics = new PictureBox[cards.Count];
            for (int i = 0; i < cards.Count; i++){
                pics[i] = LoadCard(cards[i]);
            }
        }
        
        private PictureBox LoadCard(Card card){
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

        private void ArrangePictureBoxes()
        {
            int numCards = this.game.GetCurrentLevel().GetNumCards();
            int margin = 10;
            int numCardsPerLine = 4;
            int y = (int)(pics[0].Parent.Height - PictureBoxHeight * (Math.Ceiling(numCards / (double)numCardsPerLine))) / 2;
            int x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
            for (int i = 0; i < numCards; i++){
                pics[i].Location = new Point(x, y);
                x += pics[0].Width + margin;

                if ((i + 1) % numCardsPerLine == 0){
                    x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
                    y += pics[0].Height + margin;
                }
            }
        }

        private void ValidatePictureBox(PictureBox pic)
        {
            pic.BorderStyle = BorderStyle.None;
            pic.BackColor = Color.FromName("White");
            pic.Image = Properties.Resources.Validated;
            ((Card)pic.Tag).SetState(Card.CardState.Validated);
        }

        private void AnimatePictureBox(PictureBox pic)
        {
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
            for (int i = 0; i < 10; i++) { pic.Location = new Point(pic.Location.X - 2, pic.Location.Y - 2); Thread.Sleep(10); }
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
        }

        private void Card_MouseClick(object sender, EventArgs e){
            PictureBox cardSelected = sender as PictureBox;
            Card card = cardSelected.Tag as Card;
            if (card.GetState() == Card.CardState.Selectable){
                if (this.firstSelect == null){
                    cardSelected.BorderStyle = BorderStyle.Fixed3D;
                    this.firstSelect = cardSelected;
                    ((Card)this.firstSelect.Tag).SetState(Card.CardState.Selected);
                }
                else if (cardSelected != firstSelect && !((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag))
                {
                    AnimatePictureBox(firstSelect);
                    ((Card)firstSelect.Tag).SetState(Card.CardState.Selectable);
                    this.firstSelect.BorderStyle = BorderStyle.None;
                    this.firstSelect = null;
                }
                else if(cardSelected != firstSelect && ((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag)) {
                    ValidatePictureBox(firstSelect);
                    ValidatePictureBox(cardSelected);
                    this.game.GetCurrentLevel().GetCurrentRound().PairOfCardsValidated();
                    this.player.IncrementNumPoints(this.game.GetNumPointsPerValidation());
                    this.firstSelect = null;

                    if(this.game.GetCurrentLevel().GetCurrentRound().RoundFinished()) {
                        if (this.player.GetNumPoints() < this.game.GetCurrentLevel().GetNumPointsRequiredToPass()) {
                            this.game.GetCurrentLevel().newRound();
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
        }
    }
}
