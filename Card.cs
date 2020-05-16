using System;
using CardSymbol = SlamMatch.Round.CardSymbol;
using CardColor = SlamMatch.Round.CardColor;

namespace SlamMatch
{
    class Card
    {
        //Un ensemble de constantes qui forment les différentes états d'une carte
        public enum CardState
        {
            Selectable,
            Selected,
            Validated
        }

        private CardSymbol symbol;
        private CardColor color;
        private CardState state;

        public Card(CardSymbol symbol, CardColor color)
        {
            this.symbol = symbol;
            this.color = color;
            this.state = 0;
        }
        
        /// <summary>
        /// Permet de comparer l'objet this et l'objet récu en paramètre en fonction de la couleur et le symbole
        /// </summary>
        /// <param name="obj"> l'objet à comparer avec l'objet this </param>
        /// <returns> true si les deux objets (this et obj) sont égaux, false sinon</returns>
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Card card = (Card)obj;
                return (this.symbol.Equals(card.symbol)) && (this.color.Equals(card.color));
            }
        }

        /// <returns> Le symbole de la carte </returns>
        public CardSymbol GetSymbol()
        {
            return this.symbol;
        }

        /// <returns> La couleur de la carte </returns>
        public CardColor GetColor()
        {
            return this.color;
        }

        /// <returns> L'état de la carte </returns>
        public CardState GetState()
        {
            return this.state;
        }

        /// <param name="newState"> Le nouveau état de la carte </param>
        public void SetState(CardState newState)
        {
            this.state = newState;
        }
    }
}
