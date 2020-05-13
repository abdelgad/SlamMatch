﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardSymbol = SlamMatch.Round.CardSymbol;
using CardColor = SlamMatch.Round.CardColor;

namespace SlamMatch
{
    class Card
    {

        private CardSymbol symbol;
        private CardColor color;

        public Card(CardSymbol symbol, CardColor color)
        {
            this.symbol = symbol;
            this.color = color;
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
    }
}