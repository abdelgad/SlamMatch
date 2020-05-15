
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

        public bool DecrementNumLives()
        {
            return this.numLives-- > 1;
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
