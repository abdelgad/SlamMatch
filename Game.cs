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
        
        //Collection of 3 levels here
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            pnlWinGame.BringToFront();
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
            }
            
        }
    }
}
