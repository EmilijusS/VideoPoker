using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    public class Scorer
    {
        private List<Card> hand;
        private bool isQuadruple = false;
        private bool isTriple = false;
        private int doubles = 0;
        private bool isJacks = false;
        private bool isStraight = false;
        private bool isFlush = false;

        public Scorer(List<Card> hand)
        {
            this.hand = hand;
            // Makes combination detection easier
            this.hand.Sort();

            countFlush();
            countStraight();
            countMultiples();
        }

        public CardCombinationType GetCombination()
        {
            return IsRoyalFlush() ? CardCombinationType.RoyalFlush :
                   isStraight && isFlush ? CardCombinationType.StraightFlush :
                   isQuadruple ? CardCombinationType.FourOfAKind :
                   isTriple && doubles > 0 ? CardCombinationType.FullHouse :
                   isFlush ? CardCombinationType.Flush :
                   isStraight ? CardCombinationType.Straight :
                   isTriple ? CardCombinationType.ThreeOfAKind :
                   doubles == 2 ? CardCombinationType.TwoPair :
                   isJacks ? CardCombinationType.JacksOrBetter :
                   CardCombinationType.None;
        }

        private bool IsRoyalFlush()
        {
            // Straight flush starting from ten is royal flush
            return isStraight && isFlush && hand.First().Value == CardValueType.Ten;
        }

        private void countFlush()
        {
            foreach (Card card in hand)
            {
                // If at least one suit differs - it's not a flush
                if (card.Suit != hand.First().Suit)
                {
                    isFlush = false;
                    return;
                }
            }

            isFlush = true;
        }

        private void countStraight()
        {
            // Start from second card in sorted hand
            for (int i = 1; i < hand.Count; ++i)
            {
                // Every card in hand must be one higher than previous
                if (hand[i].Value - hand[i - 1].Value != 1)
                {
                    isStraight = false;
                    return;
                }
            }

            isStraight = true;
        }

        // Counts doubles, triples, quintuples
        private void countMultiples()
        {
            int sameValueCount = 1;

            // Start from second card in sorted hand
            for (int i = 1; i < hand.Count; ++i)
            {
                if (hand[i].Value == hand[i - 1].Value)
                {
                    ++sameValueCount;
                }
                else
                {
                    setMultiples(sameValueCount, hand[i - 1].Value);

                    // Start counting from current card
                    sameValueCount = 1;
                }
            }

            // Set again with count after the last card
            setMultiples(sameValueCount, hand.Last().Value);
        }

        private void setMultiples(int sameValueCount, CardValueType lastCardValue)
        {
            if (sameValueCount == 2)
            {
                ++doubles;

                if (lastCardValue >= CardValueType.Jack)
                {
                    isJacks = true;
                }
            }
            else if (sameValueCount == 3)
            {
                isTriple = true;
            }
            else if (sameValueCount == 4)
            {
                isQuadruple = true;
            }
        }
    }
}
