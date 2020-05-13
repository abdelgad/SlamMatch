using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamMatch
{
    public partial class Game : Form
    {
        Player player;
        Level[] levels;
        int currentLevel;

        //Visual Attributes
        Random randomizer;
        private PictureBox[] pics;
        private const int CardWidth = 100;
        private const int CardHeight = 150;


        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            levels = new Level[3];
            this.currentLevel = 0;
            pnlWelcome.BringToFront();
        }

        private void LevelLoad(int levelNum)
        {
            this.levels[levelNum] = new Level(8, 8 / 2 * 10);
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
                LevelLoad(this.currentLevel);
                LoadPictureBoxes(this.levels[currentLevel].getCurretRound().getCards());
                ArrangePictureBoxes();
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
            pic.Size = new Size(CardWidth, CardHeight);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Parent = pnlGameBoard;
            pic.MouseClick += card_MouseClick;

            pic.Tag = card;
            pic.Padding = new Padding(5);
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
            int y = (int)(pics[0].Parent.Height - CardHeight * (Math.Ceiling(numCards / (double)numCardsPerLine))) / 2;
            int x = (pics[0].Parent.Width - CardWidth * numCardsPerLine) / 2;
            for (int i = 0; i < numCards; i++)
            {
                pics[i].Location = new Point(x, y);
                x += pics[0].Width + margin;

                if ((i + 1) % numCardsPerLine == 0)
                {
                    x = (pics[0].Parent.Width - CardWidth * numCardsPerLine) / 2;
                    y += pics[0].Height + margin;
                }
            }
        }

        private void Card_MouseClick()
        {

        }
    }
}
