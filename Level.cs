

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

        /// <summary>
        /// Génère un nouveau tour dans le niveau
        /// </summary>
        public void NewRound()
        {
            this.currentRound = new Round(this.numCards);
        }

        /// <returns> Le tour actuel </returns>
        public Round GetCurrentRound()
        {
            return this.currentRound;
        }

        /// <returns> Retourne le nombre de cartes </returns>
        public int GetNumCards()
        {
            return this.numCards;
        }

        /// <returns> Le nombre de points nécessaire pour terminer le niveau </returns>
        public int GetNumPointsRequiredToPass()
        {
            return this.numPointsRequiredToPass;
        }
    }
}
