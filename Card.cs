using System;
using CardSymbol = SlamMatch.Round.CardSymbol;
using CardColor = SlamMatch.Round.CardColor;

namespace SlamMatch
{
    class Card
    {
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

        public CardSymbol GetSymbol()
        {
            return this.symbol;
        }

        public CardColor GetColor()
        {
            return this.color;
        }

        public CardState GetState()
        {
            return this.state;
        }

        public void SetState(CardState newState)
        {
            this.state = newState;
        }
    }
}
