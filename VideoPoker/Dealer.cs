using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Dealer
    {
        private List<Card> deck;

        public Dealer()
        {
            deck = new List<Card>();

            var suits = Enum.GetValues(typeof(SuitType));
            var values = Enum.GetValues(typeof(ValueType));

            foreach (SuitType suit in suits)
            {
                foreach(ValueType value in values)
                {
                    deck.Add(new Card(suit, value));
                }
            }
        }

        public Card Draw()
        {
            if(deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }

            throw new NotImplementedException();
        }
    }
}
