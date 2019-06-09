using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Card
    {
        public SuitType Suit { get; private set; }
        public ValueType Value { get; private set; }

        public Card(SuitType suit, ValueType value)
        {
            Suit = suit;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = obj as Card;

            return other.Suit == Suit && other.Value == Value;
        }

        public override int GetHashCode()
        {
            // Probably not a good implementation, but should be enough if necessary
            return Suit.GetHashCode() + Value.GetHashCode();
        }

        public override string ToString()
        {
            // TODO: maybe should do something more similar to 5♠, J♣ etc.
            // Can't use ♣♠♦♥ symbols though, as they wouldn't work in Windows 7 terminal
            return Value.ToString() + " of " + Suit.ToString();
        }
    }
}
