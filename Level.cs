

using System;

namespace SlamMatch
{
    class Level
    {
        private int numCards;
        private int numPointsRequiredToPass;
        private Round currentRound;

        public Level(int numCards, int numPointsRequiredToPass)
        {
            this.numPointsRequiredToPass = numPointsRequiredToPass;
            this.numCards = numCards;
            NewRound();
        }

        public void NewRound()
        {
            this.currentRound = new Round(this.numCards);
        }

        public Round GetCurrentRound()
        {
            return this.currentRound;
        }

        public int GetNumCards()
        {
            return this.numCards;
        }

        public int GetNumPointsRequiredToPass()
        {
            return this.numPointsRequiredToPass;
        }
    }
}
