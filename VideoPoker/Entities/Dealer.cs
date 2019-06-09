using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    public class Dealer
    {
        private List<Card> deck = new List<Card>();

        public Dealer()
        {
            var suits = Enum.GetValues(typeof(CardSuitType));
            var values = Enum.GetValues(typeof(CardValueType));

            foreach (CardSuitType suit in suits)
            {
                foreach (CardValueType value in values)
                {
                    deck.Add(new Card(suit, value));
                }
            }

            var random = new Random();

            deck = deck.OrderBy(x => random.Next()).ToList();
        }

        public Card Draw()
        {
            if (deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }

            var card = deck[0];
            deck.RemoveAt(0);
            return card;
        }
    }
}
