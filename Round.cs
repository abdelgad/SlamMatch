using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamMatch
{
    class Round
    {
        public enum CardSymbol
        {
            Nefertiti,
            Horus,
            Anubis,
            Sphinx
        }

        public enum CardColor
        {
            Red,
            Blue,
            Green,
            Yellow
        }

        private Random randomizer;
        private int numCards;
        private int numCardsValidated;
        private List<Card> cards;

        //TODO: Timer to be Added here 

        public Round(int numCard)
        {
            this.randomizer = new Random();
            this.numCards = numCard;
            this.numCardsValidated = 0;
            this.cards = generatePairsOfCards(this.numCards);
        }


        private List<Card> generatePairsOfCards(int numCardsToBeGenerated)
        {
            List<Card> generatedPairs = new List<Card>();
            CardSymbol tempCardSymbol;
            CardColor tempCardColor;

            for (int i = 0; i < numCardsToBeGenerated; i += 2)
            {
                tempCardSymbol = (CardSymbol)randomizer.Next(Enum.GetNames(typeof(CardSymbol)).Length);
                tempCardColor = (CardColor)randomizer.Next(Enum.GetNames(typeof(CardColor)).Length);
                generatedPairs.Add(new Card(tempCardSymbol, tempCardColor));
                generatedPairs.Add(new Card(tempCardSymbol, tempCardColor));
            }
            return generatedPairs;
        }

        public void PairOfCardsValidated()
        {
            this.numCardsValidated += 2;
        }

        public List<Card> getCards()
        {
            return this.cards;
        }

         
    }
}
