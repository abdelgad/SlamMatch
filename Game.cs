using System;

namespace SlamMatch
{
    class Game
    {
        public enum LevelNumCards
        {
            Level1 = 8,
            Level2 = 12,
            Level3 = 16
        }

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

        public Level GetCurrentLevel()
        {
            return this.levels[currentLevel];
        }

        public int GetCurrentLevelNum()
        {
            return this.currentLevel;
        }

        public int GetMaximumLevel()
        {
            return maximumLevel;
        }

        public int GetNumPointsPerValidation()
        {
            return numPointsPerPairValidation;
        }
    }
}
