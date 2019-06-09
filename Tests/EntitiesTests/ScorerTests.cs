using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VideoPoker;

namespace Tests
{
    [TestClass]
    public class ScorerTests
    {
        [TestMethod]
        public void DetectNoCombination()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Four));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Six));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Six));

            Assert.AreEqual(CardCombinationType.None, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectJacksOrBetter()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Four));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Jack));

            Assert.AreEqual(CardCombinationType.JacksOrBetter, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectTwoPair()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Jack));

            Assert.AreEqual(CardCombinationType.TwoPair, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectThreeOfAKind()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Jack));

            Assert.AreEqual(CardCombinationType.ThreeOfAKind, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectStraight()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Ten));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Nine));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Queen));

            Assert.AreEqual(CardCombinationType.Straight, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectFlush()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Nine));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Ace));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Queen));

            Assert.AreEqual(CardCombinationType.Flush, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectFullHouse()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Jack));

            Assert.AreEqual(CardCombinationType.FullHouse, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectFourOfAKind()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Two));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Spades, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Diamonds, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Hearts, CardValueType.Jack));

            Assert.AreEqual(CardCombinationType.FourOfAKind, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectStraightFlush()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Ten));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Nine));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Eight));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Queen));

            Assert.AreEqual(CardCombinationType.StraightFlush, new Scorer(hand).GetCombination());
        }

        [TestMethod]
        public void DetectRoyalFlush()
        {
            var hand = new List<Card>();
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.King));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Ace));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Ten));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Jack));
            hand.Add(new Card(CardSuitType.Clubs, CardValueType.Queen));

            Assert.AreEqual(CardCombinationType.RoyalFlush, new Scorer(hand).GetCombination());
        }
    }
}
