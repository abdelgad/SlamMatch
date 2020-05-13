using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamMatch
{
    class Player
    {
        private string nickname;
        private int numPoints;
        private int numLives;


        public Player(string nickname)
        {
            this.nickname = nickname;
            this.numPoints = 0;
            this.numLives = 3;
        }

        public void IncrementNumPoints(int num)
        {
            this.numPoints += num;
        }

        public int GetNumPoints()
        {
            return this.numPoints;
        }

        public int GetNumLives()
        {
            return this.numLives;
        }
    }
}
