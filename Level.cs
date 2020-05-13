using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamMatch
{
    class Level
    {
        private int numCards;
        private Round currentRound;
        private int numPointsRequiredToPass;
        

        public Level(int numCards, int numPointsRequiredToPass)
        {
            this.numPointsRequiredToPass = numPointsRequiredToPass;
            this.numCards = numCards;
            newRound();
        }

        public void newRound()
        {
            this.currentRound = new Round(this.numCards);
        }

        public Round getCurretRound()
        {
            return this.currentRound;
        }

        public int GetNumCards()
        {
            return this.numCards;
        }
    }
}
