using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    public enum CardCombinationType
    {
        None = 0, JacksOrBetter = 1, TwoPair = 2, ThreeOfAKind = 3,
        Straight = 4, Flush = 6, FullHouse = 9, FourOfAKind = 25,
        StraightFlush = 50, RoyalFlush = 800
    };
}
