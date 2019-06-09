using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VideoPoker;

namespace Tests
{
    [TestClass]
    public class DealerTests
    {
        [TestMethod]
        public void DealerDealsTheWholeDeck()
        {
            var dealer = new Dealer();
            var cards = new HashSet<Card>();

            // Deck contains 52 cards
            for(int i = 0; i < 52; ++i)
            {
                cards.Add(dealer.Draw());
            }

            Assert.AreEqual(52, cards.Count);
        }

        // There's a miniscule chance that this test fails with correct implementation
        [TestMethod]
        public void DifferentDealersDealDifferently()
        {
            var dealer1 = new Dealer();
            var dealer2 = new Dealer();
            var cards1 = new HashSet<Card>();
            var cards2 = new HashSet<Card>();

            for (int i = 0; i < 5; ++i)
            {
                cards1.Add(dealer1.Draw());
                cards2.Add(dealer2.Draw());
            }

            Assert.IsFalse(cards1.SetEquals(cards2));
        }
    }
}
