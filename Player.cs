using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamMatch
{
    class Player
    {
        public event EventHandler OnPointsChange;
        private string nickname;
        private int numPointsPrivate;
        public int NumPoints
        {
            get { return numPointsPrivate; }
            set 
            { 
                numPointsPrivate = value;
                OnPointsChange(this, new EventArgs());
            }
        }
        private int numLives;


        public Player(string nickname)
        {
            this.nickname = nickname;
            this.numPointsPrivate = 0;
            this.numLives = 3;
        }

        public void IncrementNumPoints(int num)
        {
            this.NumPoints += num;
        }

        public int GetNumLives()
        {
            return this.numLives;
        }
    }
}
