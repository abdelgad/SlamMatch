using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamMatch
{
    class Game
    {
        public enum LevelNumCard
        {
            Level1 = 8,
            Level2 = 10,
            Level3 = 12
        }

        private const int numPointsPerPairValidation = 10;
        private const int maximumLevel = 3;


        private Level[] levels;
        private int currentLevel;

        public Game()
        {
            this.currentLevel = 0;
            this.levels = new Level[maximumLevel];
            int numCards = (int)(Enum.GetValues(typeof(LevelNumCard))).GetValue(this.currentLevel);
            int numPointsRequiredToPass = numCards / 2 * numPointsPerPairValidation;

        }

        public void StartGame()
        {
            
            
            
        }

        public Level GetCurrentLevel()
        {
            return this.levels[currentLevel];
        }

        public int GetCurrentLevelNum()
        {
            return this.currentLevel;
        }

        public void NextLevel()
        {
            //TODO: Check if finished max level the show winning pannel
            int numCards = (int)(Enum.GetValues(typeof(LevelNumCard))).GetValue(this.currentLevel+1);
            int numPoints = this.levels[this.currentLevel].GetNumPointsRequiredToPass() + numCards / 2 * numPointsPerPairValidation;
            
            this.currentLevel++;
            this.levels[currentLevel] = new Level(numCards, numPoints);
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
