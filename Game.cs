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
    public partial class Game : Form
    {
        private const int numPointsPerPairValidation = 10;
        private const int maximumLevel = 3;
        
        private const int PictureBoxWidth = 100;
        private const int PictureBoxHeight = 150;

        private Player player;
        private Level[] levels;
        private int currentLevel;

        //Visual Attributes
        private Random randomizer;
        private PictureBox[] pics;
        private PictureBox firstSelect;


        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            levels = new Level[maximumLevel];
            this.currentLevel = 0;
            pnlWelcome.BringToFront();
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNickname.Text))
            {
                MessageBox.Show(
                    "Entrez un pseudo avant de jouer.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.player = new Player(txtNickname.Text);
                this.levels[this.currentLevel] = new Level(8, 8 / 2 * numPointsPerPairValidation);
                LoadPictureBoxes(this.levels[currentLevel].getCurrentRound().getCards());
                ArrangePictureBoxes();
                lblNumLives.Text = "Nombre de vies: " + this.player.GetNumLives();
                lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.levels[this.currentLevel].GetNumPointsRequiredToPass();
                lblLevel.Text = "Niveau: " + this.currentLevel + " / " + maximumLevel;
                pnlGameBoard.BringToFront();
            }
        }

        private void LoadPictureBoxes(List<Card> cards)
        {
            this.randomizer = new Random();
            pics = new PictureBox[8];
            int randomCardIndex;
            for (int i = 0; i < 8; i++)
            {
                randomCardIndex = randomizer.Next(cards.Count);
                pics[i] = LoadCard(cards[randomCardIndex]);
                cards.RemoveAt(randomCardIndex);
            }
        }
        
        private PictureBox LoadCard(Card card)
        {
            // New PictureBox
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
            int numCards = this.levels[this.currentLevel].GetNumCards();
            // Display the deck.
            const int margin = 10;
            int numCardsPerLine = 4;
            int y = (int)(pics[0].Parent.Height - PictureBoxHeight * (Math.Ceiling(numCards / (double)numCardsPerLine))) / 2;
            int x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
            for (int i = 0; i < numCards; i++)
            {
                pics[i].Location = new Point(x, y);
                x += pics[0].Width + margin;

                if ((i + 1) % numCardsPerLine == 0)
                {
                    x = (pics[0].Parent.Width - PictureBoxWidth * numCardsPerLine) / 2;
                    y += pics[0].Height + margin;
                }
            }
        }
        
        private void Card_MouseClick(object sender, EventArgs e)
        {
            
            PictureBox cardSelected = sender as PictureBox;
            Card card = cardSelected.Tag as Card;
            if (card.GetState() == Card.CardState.Selectable)
            {
                if (this.firstSelect == null)
                {
                    cardSelected.BorderStyle = BorderStyle.Fixed3D;
                    this.firstSelect = cardSelected;
                    ((Card)this.firstSelect.Tag).SetState(Card.CardState.Selected);
                }
                else if(cardSelected != firstSelect && ((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag))
                {
                    ValidatePictureBox(firstSelect);
                    ValidatePictureBox(cardSelected);
                    this.levels[this.currentLevel].getCurrentRound().PairOfCardsValidated();
                    this.player.IncrementNumPoints(numPointsPerPairValidation);
                    lblPoints.Text = "Points: " + this.player.GetNumPoints() + " / " + this.levels[this.currentLevel].GetNumPointsRequiredToPass();
                    this.firstSelect = null;
                }
                else if (cardSelected != firstSelect && !((Card)cardSelected.Tag).Equals((Card)firstSelect.Tag))
                {
                    //Animation
                    ((Card)firstSelect.Tag).SetState(Card.CardState.Selectable);
                    this.firstSelect.BorderStyle = BorderStyle.None;
                    this.firstSelect = null;
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
    }
}
