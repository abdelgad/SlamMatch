using System;
using System.Collections.Generic;
using System.ComponentModel;

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
            Yellow,
        }

        int roundDuration;
        private int numCards;
        private int numCardsValidated;
        private List<Card> cards;
        
        private Random randomizer;

        //TODO: Timer to be Added here 

        public Round(int numCard)
        {
            this.roundDuration = 10;
            this.numCards = numCard;
            this.numCardsValidated = 0;
            this.cards = new List<Card>();
            this.randomizer = new Random();
            GeneratePairsOfCards();
            ShuffleCards();
        }

        private void GeneratePairsOfCards()
        {
            CardSymbol tempCardSymbol;
            CardColor tempCardColor;

            for (int i = 0; i < this.numCards; i += 2)
            {
                tempCardSymbol = (CardSymbol)randomizer.Next(Enum.GetNames(typeof(CardSymbol)).Length);
                tempCardColor = (CardColor)randomizer.Next(Enum.GetNames(typeof(CardColor)).Length);
                this.cards.Add(new Card(tempCardSymbol, tempCardColor));
                this.cards.Add(new Card(tempCardSymbol, tempCardColor));
            }
        }

        private void ShuffleCards()
        {
            Card card;
            for (int i = this.cards.Count - 1; i > 1; i--)
            {
                int rnd = randomizer.Next(i + 1);

                card = cards[rnd];
                this.cards[rnd] = this.cards[i];
                this.cards[i] = card;
            }
        }

        public void PairOfCardsValidated()
        {
            this.numCardsValidated += 2;
        }

        public List<Card> GetCards()
        {
            return this.cards;
        }

        public bool RoundFinished()
        {
            return this.numCardsValidated == this.numCards; 
        }

        public void DecrementDuration()
        {
            this.roundDuration--;
        }

        public int GetDuration()
        {
            return this.roundDuration;
        }
    }
}
