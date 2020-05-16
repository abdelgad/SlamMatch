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

        //Affiche le label contenant les règles du jeu lorsque l'utilisateur clique sur le bouton btnGameRules
        private void BtnGameRules_Click(object sender, EventArgs e) {
            lblGameRules.Visible = !lblGameRules.Visible;
        }

        //Initialise le joueur et le jeu et met à jour le plateau de jeu (pannel = pnlGameBoard) et affiche ce panneau 
        private void BtnPlay_Click(object sender, EventArgs e) {
                this.player = new Player();
                this.game = new Game();
                RefreshGameBoard();
                pnlGameBoard.BringToFront();
        }

        //Met à jour les information de la partie (niveau actuel/niveau maximal) et les informations de joueur (nombre de vies / nombre de points)
        private void UpdateStats() {
            lblNumLives.Text = "Nombre de vies: " + this.player.GetNumLives();
            lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.game.GetCurrentLevel().GetNumPointsRequiredToPass();
            lblLevel.Text = "Niveau: " + (this.game.GetCurrentLevelNum() + 1) + " / " + this.game.GetMaximumLevel();
        }

        //Génère + Organise les pictureboxes sur le plateau et commence le timer et met à jour les informations du joueur
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

        //Génère des pictureboxes à partir d'une collection de cartes
        private void LoadPictureBoxes(List<Card> cards) {
            this.pics = new PictureBox[cards.Count];
            for (int i = 0; i < cards.Count; i++) {
                pics[i] = LoadCard(cards[i]);
            }
        }
        
        //Génère un picturebox à partir d'une carte
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

        //Organise l'ensemble de pictureboxes sur le plateau de jeu
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

        //Met à jour l'aspect visuel d'un picturebox pour correspondre à une carte validée 
        private void ValidatePictureBox(PictureBox pic) {
            pic.BorderStyle = BorderStyle.None;
            pic.BackColor = Color.FromName("White");
            pic.Image = Properties.Resources.Validated;
            ((Card)pic.Tag).SetState(Card.CardState.Validated);
        }

        //Anime un picturebox pour signaler une erreur de séléction à l'utilisateur
        private void AnimatePictureBox(PictureBox pic) {
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
            for (int i = 0; i < 10; i++) { pic.Location = new Point(pic.Location.X - 2, pic.Location.Y - 2); Thread.Sleep(10); }
            for (int i = 0; i < 5; i++) { pic.Location = new Point(pic.Location.X + 2, pic.Location.Y + 2); Thread.Sleep(10); }
        }

        //Lorsque le joueur clique sur une carte (qui est representée par un picturebox) et si cette carte est sélectionnable :
        //Si aucune autre carte est selectionnée => définie comme la première carte séléctionnée + Màj visuel
        //Si le joueur séléctionne deux cartes différéntes => Animation + retour à l'état initiale
        //Si le joeur associe une paire => màj visuel des deux cartes comme cartes validées
        //Si le joueur clique deux fois sur la même carte => la carte est déselectionnée 
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

        //Met à jour le label qui affiche le timer + Commence le timer
        private void StartRoundTimer() {
            lblTimerRound.Text = "00: " + this.game.GetCurrentLevel().GetCurrentRound().GetTimeLeft();
            tmrRound.Start();
        }

        //Met à jour le label qui affiche le timer
        //Arrête le timer lorsque le temps restant dans le tour = 0 et décrémente le nombre de vies du joueur
        //Si le joueur possède au moins 1 vie après la décrémentation, génère un noveau tour et met à jour le plateu de jeu
        //Sinon elle affiche le panneau (pnlLoseGame)
        private void RoundTimerTick(object sender, EventArgs e) {
            this.game.GetCurrentLevel().GetCurrentRound().DecrementTimer();
            lblTimerRound.Text = "00: " + this.game.GetCurrentLevel().GetCurrentRound().GetTimeLeft().ToString("D2");
            if (this.game.GetCurrentLevel().GetCurrentRound().GetTimeLeft() == 0) {
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
