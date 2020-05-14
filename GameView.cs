using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
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
        private Random randomizer;

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
                this.game.StartGame();
                UpdateStats();
                RefreshGameBoard();
                pnlGameBoard.BringToFront();
            }
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
            this.randomizer = new Random();
            this.pics = new PictureBox[cards.Count];
            Console.WriteLine("LOLOLO " + cards.Count);
            int randomCardIndex;
            for (int i = 0; i < pics.Length; i++){
                randomCardIndex = randomizer.Next(cards.Count);
                pics[i] = LoadCard(cards[randomCardIndex]);
                cards.RemoveAt(randomCardIndex);
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
            const int margin = 10;
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
        
        private void Card_MouseClick(object sender, EventArgs e){
            PictureBox cardSelected = sender as PictureBox;
            Card card = cardSelected.Tag as Card;
            if (card.GetState() == Card.CardState.Selectable){
                if (this.firstSelect == null){
                    cardSelected.BorderStyle = BorderStyle.Fixed3D;
                    this.firstSelect = cardSelected;
                    ((Card)this.firstSelect.Tag).SetState(Card.CardState.Selected);
                }
                else if(cardSelected != firstSelect && ((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag)){
                    ValidatePictureBox(firstSelect);
                    ValidatePictureBox(cardSelected);
                    this.game.GetCurrentLevel().GetCurrentRound().PairOfCardsValidated();
                    this.player.IncrementNumPoints(this.game.GetNumPointsPerValidation());
                    
                    this.firstSelect = null;

                    if(this.game.GetCurrentLevel().GetCurrentRound().roundFinished()){
                        if (this.player.GetNumPoints() == this.game.GetCurrentLevel().GetNumPointsRequiredToPass())
                            this.game.NextLevel();
                        else this.game.GetCurrentLevel().newRound();
                        RefreshGameBoard();
                    }
                    UpdateStats();
                }
                else if (cardSelected != firstSelect && !((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag)){
                    //Animation
                    ((Card)firstSelect.Tag).SetState(Card.CardState.Selectable);
                    this.firstSelect.BorderStyle = BorderStyle.None;
                    this.firstSelect = null;
                }
            }
        }

        private void UpdateStats(){
            lblNumLives.Text = "Nombre de vies: " + this.player.GetNumLives();
            lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.game.GetCurrentLevel().GetNumPointsRequiredToPass();
            lblLevel.Text = "Niveau: " + this.game.GetCurrentLevelNum() + " / " + this.game.GetMaximumLevel();
        }

        private void ValidatePictureBox(PictureBox pic){
            pic.BorderStyle = BorderStyle.None;
            pic.BackColor = Color.FromName("White");
            pic.Image = Properties.Resources.Validated;
            ((Card)pic.Tag).SetState(Card.CardState.Validated);
        }
    }
}
