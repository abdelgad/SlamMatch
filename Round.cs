using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SlamMatch
{
    class Round
    {
        /// <summary>
        /// Un ensemble de constantes contentant tous les symboles possibles d'une carte
        /// </summary>
        public enum CardSymbol
        {
            Nefertiti,
            Horus,
            Anubis,
            Sphinx
        }

        /// <summary>
        /// Un ensemble de constantes contenant toutes les couleurs possibles d'une carte
        /// Il suffit de simplement ajouter le nom d'une couleur à cette enum
        /// pour que des cartes aient cette couleur
        /// </summary>
        public enum CardColor
        {
            Red,
            Blue,
            Green,
            Yellow,
        }

        private const int roundDuration = 10;
        
        private int numCards;
        private int numCardsValidated;
        private List<Card> cards;
        private int roundTimer;
        private Random randomizer;

        public Round(int numCard)
        {
            this.roundTimer = roundDuration;
            this.numCards = numCard;
            this.numCardsValidated = 0;
            this.cards = new List<Card>();
            this.randomizer = new Random();
            GeneratePairsOfCards();
            ShuffleCards();
        }

        /// <summary>
        /// Génère un ensemble de paires de cartes aléatoirement et l'ajoute
        /// à la collection de cartes du tour
        /// </summary>
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

        /// <summary>
        /// Mélange la collection de carte du tour
        /// </summary>
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

        /// <summary>
        /// Incrémente le nombre de cartes validées pendant le tour par 2
        /// càd une paire de cartes à été associée
        /// </summary>
        public void PairOfCardsValidated()
        {
            this.numCardsValidated += 2;
        }

        /// <summary>
        /// Vérifie si le tour est terminé 
        /// (càd toutes les paires de cartes on été associées) ou pas
        /// </summary>
        /// <returns> true si le tour est terminé, false sinon </returns>
        public bool RoundFinished()
        {
            return this.numCardsValidated == this.numCards; 
        }

        /// <summary>
        /// Décremente le timer du tour
        /// </summary>
        public void DecrementTimer()
        {
            this.roundTimer--;
        }

        /// <returns> la collection de cartes du tour </returns>
        public List<Card> GetCards()
        {
            return this.cards;
        }

        /// <returns> Le temps restant du tour </returns>
        public int GetTimeLeft()
        {
            return this.roundTimer;
        }
    }
}
