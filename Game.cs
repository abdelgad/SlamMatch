using System;

namespace SlamMatch
{
    class Game
    {
        /// <summary>
        /// Un ensemble de constantes contenant les nombres de cartes pour chaque niveau
        /// </summary>
        public enum LevelNumCards
        {
            Level1 = 8,
            Level2 = 12,
            Level3 = 16
        }

        /// <summary>
        /// Un ensemble de constantes contenant les nombres de points néccessaires pour réussir chaque niveau 
        /// </summary>
        public enum LevelNumPoints
        {
            Level1 = 80,
            Level2 = 260,
            Level3 = 580
        }

        private const int maximumLevel = 3;
        private const int numPointsPerPairValidation = 10;
        
        private Level[] levels;
        private int currentLevel;

        public Game()
        {
            this.currentLevel = 0;
            this.levels = new Level[maximumLevel];
            int numCards = (int)(Enum.GetValues(typeof(LevelNumCards))).GetValue(this.currentLevel);
            int numPoints = (int)(Enum.GetValues(typeof(LevelNumPoints))).GetValue(this.currentLevel);
            this.levels[currentLevel] = new Level(numCards, numPoints);
        }

        /// <summary>
        ///Permet de passer au niveau suivant                                                                                                                                                                                                                                                          
        /// </summary>
        /// <returns> true si le passage au niveau suivant réussie, false si il ne y a plus de niveaux </returns>
        public bool NextLevel()
        {
            bool hasNextLevel = false;
            if(currentLevel < maximumLevel - 1)
            {
                hasNextLevel = true;
                this.currentLevel++;
                int numCards = (int)(Enum.GetValues(typeof(LevelNumCards))).GetValue(this.currentLevel);
                int numPoints = (int)(Enum.GetValues(typeof(LevelNumPoints))).GetValue(this.currentLevel);
                this.levels[currentLevel] = new Level(numCards, numPoints);
            }
            return hasNextLevel;
        }

        /// <returns> Le niveau actuel </returns>
        public Level GetCurrentLevel()
        {
            return this.levels[currentLevel];
        }

        /// <returns> L'index du niveau actuel dans la collection des niveaux </returns>
        public int GetCurrentLevelNum()
        {
            return this.currentLevel;
        }

        /// <returns> Le nombre de niveaux maximal </returns>
        public int GetMaximumLevel()
        {
            return maximumLevel;
        }

        /// <returns> Le nombre de points qu'un joeur gagne en associant deux cartes </returns>
        public int GetNumPointsPerValidation()
        {
            return numPointsPerPairValidation;
        }
    }
}
