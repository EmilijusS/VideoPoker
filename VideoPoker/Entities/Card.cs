using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    public class Card : IComparable
    {
        public CardSuitType Suit { get; }
        public CardValueType Value { get; }

        public Card(CardSuitType suit, CardValueType value)
        {
            Suit = suit;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = obj as Card;

            return other.Suit == Suit && other.Value == Value;
        }

        public override int GetHashCode()
        {
            // https://stackoverflow.com/questions/9009760/implementing-gethashcode-correctly
            return Suit.GetHashCode() * 17 + Value.GetHashCode();
        }

        public override string ToString()
        {
            // TODO: maybe should do something more similar to 5♠, J♣ etc.
            // Can't use ♣♠♦♥ symbols though, as they wouldn't work in Windows 7 terminal
            return Value.ToString() + " of " + Suit.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var other = obj as Card;
            var valueComparison = Value.CompareTo(other.Value);

            if (valueComparison != 0)
            {
                return valueComparison;
            }

            return Suit.CompareTo(other.Suit);
        }
    }
}
