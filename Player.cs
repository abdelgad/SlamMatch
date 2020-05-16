
using System;

namespace SlamMatch
{
    class Player
    {
        private int numPoints;
        private int numLives;


        public Player()
        {
            this.numPoints = 0;
            this.numLives = 3;
        }

        /// <summary>
        /// Incrémente le nombre de points appartenant au joeur
        /// </summary>
        /// <param name="num"> Le nombre de points à ajouter </param>
        public void IncrementNumPoints(int num)
        {
            this.numPoints += num;
        }

        /// <summary>
        /// Décrémente le nombre de vies du joueur par 1
        /// </summary>
        /// <returns> true si il reste au moins une vie après la décrémentation false sinon </returns>
        public bool DecrementNumLives()
        {
            Console.WriteLine(numLives);
            return this.numLives-- > 1;
        }

        /// <returns> Le nombre points appartenant au joueur </returns>
        public int GetNumPoints()
        {
            return this.numPoints;
        }

        /// <returns> Le nombre de vies appartenant au joueur </returns>
        public int GetNumLives()
        {
            return this.numLives;
        }
    }
}
